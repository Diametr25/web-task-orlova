using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.DAL.Data;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;

namespace WebApp2.BLL.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository departmentRepository;
        public DepartmentService(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return departmentRepository.GetDepartmentList();
        }
        public Department GetDepartment(int id)
        {
            return departmentRepository.GetDepartment(id);
        }
        public void Add(Department department)
        {
            departmentRepository.Add(department);
        }
        public void Delete(int id)
        {
            departmentRepository.Delete(id);
        }
        public void Save()
        {
            departmentRepository.Save();
        }
    }
}
