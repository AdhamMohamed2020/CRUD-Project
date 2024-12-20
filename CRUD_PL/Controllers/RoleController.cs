﻿using CRUD_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace CRUD_PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public IActionResult Index(string SearchValue)
        {
            var roles = Enumerable.Empty<IdentityRole>().ToList();


            if (string.IsNullOrEmpty(SearchValue))
                roles.AddRange(_roleManager.Roles);
            else
            {
                var role = _roleManager.Roles.Where(R => R.Name.Contains(SearchValue));
                roles.AddRange(role);
            }

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return BadRequest();

            return View(viewName, role);
        }

        public async Task<IActionResult> Edit(string id)
        {

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, IdentityRole updatedRole)
        {

            if (id != updatedRole.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);

                    role.Name = updatedRole.Name;

                    await _roleManager.UpdateAsync(role);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(updatedRole);
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, IdentityRole deletedRole)
        {
            if (id != deletedRole.Id)
                return BadRequest();
            try
            {
                var role = await _roleManager.FindByIdAsync(id);

                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message); 
            }
            return View(deletedRole);

        }


    }
}
