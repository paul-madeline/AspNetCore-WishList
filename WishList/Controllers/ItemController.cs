using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        ItemController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        // GET: ItemController
        public IActionResult Index()
        {
            return View("Index", _context.Items);
        }

        // GET: ItemController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: ItemController/Create
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ItemController/Delete/5
        public IActionResult Delete(int Id)
        {
            Item item = _context.Items.SingleOrDefault(x => x.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
