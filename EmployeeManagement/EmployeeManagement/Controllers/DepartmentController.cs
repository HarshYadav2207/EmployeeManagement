using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Departmentlist()
        {
            var departments = _unitOfWork._departmentRepo.GetAll();
            _unitOfWork.save();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department AddRequest)
        {
            _unitOfWork._departmentRepo.Add(AddRequest);
            _unitOfWork.save();
            return RedirectToAction("DepartmentList");
        }
    }
}
