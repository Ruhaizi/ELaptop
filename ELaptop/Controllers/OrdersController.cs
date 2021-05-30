using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using ModelLayer;
using Microsoft.AspNetCore.Authorization;

namespace ELaptop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly DataLayer.WebAppContext _context;

        public OrdersController(DataLayer.WebAppContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdersModel.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdOrder,OrderTotal")] OrdersModel ordersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersModel);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }
            return View(ordersModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ProdOrder,OrderTotal")] OrdersModel ordersModel)
        {
            if (id != ordersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersModelExists(ordersModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordersModel);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.OrdersModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ordersModel = await _context.OrdersModel.FindAsync(id);
            _context.OrdersModel.Remove(ordersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersModelExists(string id)
        {
            return _context.OrdersModel.Any(e => e.Id == id);
        }
    }
}
