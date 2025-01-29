using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.DAL.Data;
using WebApp2.DAL.Models;

namespace WebApp2.DAL.Interfaces
{
    public class EmployeeRepository
    {
        private readonly AccountingDbContext mvcAccountingDbContext;
        public EmployeeRepository(AccountingDbContext mvcAccountingDbContext)
        {
            this.mvcAccountingDbContext = mvcAccountingDbContext;
        }
        public IEnumerable<Employee> GetEmployeeList()
        {
            return mvcAccountingDbContext.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            return mvcAccountingDbContext.Employees.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Employee employee)
        {
            mvcAccountingDbContext.Employees.Add(employee);
            mvcAccountingDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                mvcAccountingDbContext.Remove(employee);
                mvcAccountingDbContext.SaveChanges();
            }
        }
        public void Save()
        {
            mvcAccountingDbContext.SaveChanges();
        }
        
    }
}
