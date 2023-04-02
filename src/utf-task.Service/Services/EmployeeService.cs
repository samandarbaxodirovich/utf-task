using kudapoyti.Service.Common.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.Interfaces.Common;
using utf_task.Domain.Entities;
using utf_task.Service.Common.Exceptions;
using utf_task.Service.Common.Helpers;
using utf_task.Service.Common.Utils;
using utf_task.Service.Dtos.CreateDtos;
using utf_task.Service.Dtos.UpdateDtos;
using utf_task.Service.Interfaces.Common;
using utf_task.Service.Interfaces.Main;
using utf_task.Service.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace utf_task.Service.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _work;
        private readonly IPaginatorService _paginator;

        public EmployeeService(IUnitOfWork work,IPaginatorService paginator)
        {
            _work = work;
            _paginator = paginator;
        }
        public async Task<EmployeeViewModel> GetById(long id)
        {
            var employee = await _work.Employees.FindByIdAsync(id);
            if (employee is not null)
            {
                return new EmployeeViewModel()
                {
                    Id = employee.Id,
                    FullName=employee.FullName,
                    PhoneNumber = employee.PhoneNumber,
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                    UpdatedAt = TimeHelper.GetCurrentServerTime()
                };
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Employee is not found");

        }
        public async Task<bool> CreateAsync(EmployeeCreateDto dto)
        {
            var stat = await CheckLegacy(dto.PhoneNumber);
            if (!stat.Item1)
                throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, $"ID{stat.Item2} employee already exists with this PhoneNumber");
            _work.Employees.Add(new Employee()
            {
                FullName = dto.FullName,
                PhoneNumber= dto.PhoneNumber,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime()
            });
            if (await _work.SaveChangesAsync() != 0)
                return true;
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Something went wrong");
        }
        public async Task<bool> UpdateAsync(long id, EmployeeUpdateDto dto)
        {
            var stat = await CheckLegacy(dto.PhoneNumber);
            var targetEmployee = await _work.Employees.FindByIdAsync(dto.Id);

            if (targetEmployee == null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Employee not found");

            _work.Employees.TrackingDeteched(targetEmployee);

            if(stat.Item2 == 0||stat.Item2 == dto.Id)
            {
                _work.Employees.Update(dto.Id,
                    new Employee()
                    {
                        FullName = dto.FullName,
                        PhoneNumber = dto.PhoneNumber,
                        CreatedAt = targetEmployee.CreatedAt,
                        UpdatedAt = TimeHelper.GetCurrentServerTime(),
                    });
                if (await _work.SaveChangesAsync() != 0)
                    return true;
                else throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "Something went error");
            }
            throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, $"ID{stat.Item2} employee already exists with this PhoneNumber");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            if (await _work.Employees.FirstOrDefaultAsync(x => x.Id == id) == null)
                throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Employee with this ID not found");
            _work.Employees.Delete(id);
            if (await _work.SaveChangesAsync() != 0)
                return true;
            throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "Something went error");
        }
        public async Task<PagedList<EmployeeViewModel>> GetAllAsync(PaginationParams @params)
        {
            var employees = from employee in _work.Employees.GetAll().OrderBy(x => x.Id)
                            select new EmployeeViewModel()
                            {
                                Id = employee.Id,
                                FullName = employee.FullName,
                                PhoneNumber = employee.PhoneNumber,
                                CreatedAt = employee.CreatedAt,
                                UpdatedAt = employee.UpdatedAt
                            };
            return await PagedList<EmployeeViewModel>.ToPagedListAsync(employees, @params);
        }
        private async Task<(bool,long)> CheckLegacy(string phoneNumber)
        {
            var employee = await _work.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            if (employee == null)
                return (true,0);
            else
                return (false,employee.Id);
        }
    }
}
