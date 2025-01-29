using Microsoft.AspNetCore.Mvc;
using WebApp2.BLL.Services;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            return Json(departmentService.GetDepartmentList(), jsonOptions);
            //try
            //{
            //    var departments = departmentService.GetDepartmentList();
            //    return Json(departments, jsonOptions);
            //}

            //catch
            //{
            //    return Json(null);
            //}
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddDepartmentViewModel addDepartmentRequest)
        {
            var department = new Department()
            {
                Guid = Guid.NewGuid(),
                Code = addDepartmentRequest.Code,
                Name = addDepartmentRequest.Name
            };

            departmentService.Add(department);
            return Json(department);
        }

        [HttpGet("View/{id}")]
        public IActionResult View(int id)
        {
            var department = departmentService.GetDepartment(id);
            if (department != null)
            {
                var viewModel = new UpdateDepartmentViewModel()
                {
                    Id = department.Id,
                    Guid = department.Guid,
                    Code = department.Code,
                    Name = department.Name
                };
                return View("View", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateDepartmentViewModel model)
        {
            var department = departmentService.GetDepartment(model.Id);

            if (department != null)
            {
                department.Code = model.Code;
                department.Name = model.Name;

                departmentService.Save();
            }

            return Json(department);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete ([FromBody] UpdateDepartmentViewModel model)
        {
            departmentService.Delete(model.Id);
            //return RedirectToAction("Index");
            return Json(departmentService.GetDepartmentList());
        }
    }
}
