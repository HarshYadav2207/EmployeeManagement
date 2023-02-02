using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private IUnitOfWork _UnitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employee =  _UnitOfWork._employeeRepo.GetAll();
            _UnitOfWork.save();
            return View(employee);
        }

        [HttpGet]
        public IActionResult add()
        {
            List<Department> departmentList = _UnitOfWork._departmentRepo.GetAll();
            ViewBag.Department = new SelectList(departmentList,"DepartmentId","DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult add(Employee employee)
        {
            List<Department> departmentList = _UnitOfWork._departmentRepo.GetAll();
            ViewBag.Department = new SelectList(departmentList, "DepartmentId", "DepartmentName");
            _UnitOfWork._employeeRepo.Add(employee);
            _UnitOfWork.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult view(int Id)
        {
            List<Department> departmentList = _UnitOfWork._departmentRepo.GetAll();
            ViewBag.Department = new SelectList(departmentList, "DepartmentId", "DepartmentName");
            var employee = _UnitOfWork._employeeRepo.GetById(x => x.Id == Id);

            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult view(int Id, Employee updateRequest)
        {
            List<Department> departmentList = _UnitOfWork._departmentRepo.GetAll();
            ViewBag.Department = new SelectList(departmentList, "DepartmentId", "DepartmentName");
            _UnitOfWork._employeeRepo.UpdateEmployee(Id, updateRequest);
            _UnitOfWork.save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult delete(int Id)
        {
            var employee = _UnitOfWork._employeeRepo.GetById(x => x.Id == Id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            _UnitOfWork._employeeRepo.delete(employee);
            _UnitOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
