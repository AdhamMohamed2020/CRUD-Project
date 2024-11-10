using AutoMapper;
using CRUD_BLL.Interfaces;
using CRUD_DAL.Entities;
using CRUD_PL.Helpers;
using CRUD_PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(string SearchValue)
        {
            var employees = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(SearchValue))
                employees = await _unitOfWork.EmployeeRepository.GetAll();

            else
                employees = _unitOfWork.EmployeeRepository.SearchEmployeesByName(SearchValue);

            var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);

            return View(mappedEmps);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["Departments"] = await _unitOfWork.DepartmentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeVM.ImageName = await DocumentSettings.UploadFile(employeeVM.Image, "Images");
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                await _unitOfWork.EmployeeRepository.Add(mappedEmp);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }


        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();

            var employee =await _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null)
                return BadRequest();

            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(viewName, mappedEmp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Departments"] = await _unitOfWork.DepartmentRepository.GetAll();

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingEmployee = await _unitOfWork.EmployeeRepository.Get(employeeVM.Id);
                    if (existingEmployee == null)
                    {
                        return NotFound();
                    }

                    var oldEmpImageName = existingEmployee.ImageName;

                    if (!string.IsNullOrEmpty(oldEmpImageName))
                        DocumentSettings.DeleteFile(oldEmpImageName, "Images");

                    employeeVM.ImageName = await DocumentSettings.UploadFile(employeeVM.Image, "Images");

                    _mapper.Map(employeeVM, existingEmployee);

                   await _unitOfWork.EmployeeRepository.Update(existingEmployee);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);  
                }
            }
            return View(employeeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var employee = await _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null)
                return BadRequest();

            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(mappedEmp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                int count = await _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                if (count > 0 && employeeVM.ImageName != null)
                    DocumentSettings.DeleteFile(employeeVM.ImageName, "Images");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message); 
            }
            return View(employeeVM);

        }
   
    }
}
