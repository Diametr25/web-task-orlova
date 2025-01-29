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
    public class DepartmentRepository
    {
        private readonly AccountingDbContext mvcAccountingDbContext;
        public DepartmentRepository(AccountingDbContext mvcAccountingDbContext)
        {
            this.mvcAccountingDbContext = mvcAccountingDbContext;
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return mvcAccountingDbContext.Departments.ToList();
        }
        public Department GetDepartment(int id)
        {
            return mvcAccountingDbContext.Departments.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Department department)
        {
            mvcAccountingDbContext.Departments.Add(department);
            mvcAccountingDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var department = GetDepartment(id);
            if (department != null)
            {
                mvcAccountingDbContext.Remove(department);
                mvcAccountingDbContext.SaveChanges();
            }
        }
        public void Save()
        {
            mvcAccountingDbContext.SaveChanges();
        }
    }
}
