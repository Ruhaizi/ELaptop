using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELaptop.Data;
using ELaptop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ELaptop.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleMng;

        public RoleController(RoleManager<IdentityRole> roleMng)
        {
            this.roleMng = roleMng;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleModel role)
        {
            var existRole = await roleMng.RoleExistsAsync(role.RoleName);
            if (!existRole)
            {
                var result = await roleMng.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }
    }
}
