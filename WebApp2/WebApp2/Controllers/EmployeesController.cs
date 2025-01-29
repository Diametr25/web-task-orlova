using Microsoft.AspNetCore.Mvc;
using WebApp2.BLL.Services;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            try 
            {
                var employees = employeeService.GetEmployeeList();
                return Json(employees, jsonOptions);
            }

            catch 
            {
                return Json(null);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Guid = Guid.NewGuid(),
                Surname = addEmployeeRequest.Surname,
                Name = addEmployeeRequest.Name,
                Patronymic = addEmployeeRequest.Patronymic,
                Phone = addEmployeeRequest.Phone,
                Email = addEmployeeRequest.Email,
                Birthdate = addEmployeeRequest.Birthdate,
                EmploymentDate = addEmployeeRequest.EmploymentDate,
                PostId = addEmployeeRequest.postId,
                DepartmentId = addEmployeeRequest.departmentId

            };

            employeeService.Add(employee);
            return Json(employee);
        }

        [HttpGet("View/{id}")]
        public IActionResult View(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Guid = employee.Guid,
                    Surname = employee.Surname,
                    Name = employee.Name,
                    Patronymic = employee.Patronymic,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Birthdate = employee.Birthdate,
                    EmploymentDate = employee.EmploymentDate,
                    PostId = employee.PostId,
                    DepartmentId = employee.DepartmentId
                };
                return View("View", viewModel);
            }

            return Json(employee);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateEmployeeViewModel model)
        {
            var employee = employeeService.GetEmployee(model.Id);

            if (employee != null) 
            {
                employee.Surname = model.Surname;
                employee.Name = model.Name;
                employee.Patronymic = model.Patronymic;
                employee.Phone = model.Phone;
                employee.Email = model.Email;
                employee.Birthdate = model.Birthdate;
                employee.EmploymentDate = model.EmploymentDate;
                employee.PostId = model.Id;
                employee.DepartmentId = model.Id;

                employeeService.Save();
            }

            return Json(employee);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] UpdateEmployeeViewModel model)
        {
            employeeService.Delete(model.Id);
            return Json(employeeService.GetEmployeeList());
        }
    }
}
