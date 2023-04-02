using kudapoyti.Service.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Entities;
using utf_task.Service.Common.Utils;
using utf_task.Service.Dtos.CreateDtos;
using utf_task.Service.Dtos.UpdateDtos;
using utf_task.Service.ViewModels;

namespace utf_task.Service.Interfaces.Main
{
    public interface IEmployeeService
    {
        public Task<EmployeeViewModel> GetById(long id);
        public Task<PagedList<EmployeeViewModel>> GetAllAsync(PaginationParams @Params);
        public Task<bool> CreateAsync(EmployeeCreateDto dto);
        public Task<bool> UpdateAsync(long id, EmployeeUpdateDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
