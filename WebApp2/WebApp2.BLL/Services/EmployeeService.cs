using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;

namespace WebApp2.BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository) 
        { 
            this.employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetEmployeeList()
        {
           return employeeRepository.GetEmployeeList();
        }
        public Employee GetEmployee(int id)
        {
            return employeeRepository.GetEmployee(id);
        }
        public void Add(Employee employee)
        {
            employeeRepository.Add(employee);
        }
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }
        public void Save()
        {
            employeeRepository.Save();
        }
    }
}
