using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ThissesController : Controller
    {
        private readonly RedBookContext _context;
        public readonly MethodsIterface _interface;
        public ThissesController(RedBookContext context, MethodsIterface iterfaces)
        {
            _context = context;
            
            _interface = iterfaces;
        }

        // GET: Thisses
        public async Task<IActionResult> Index()
        {

            return View();
         
        }
        public async Task<IActionResult> Category()
        {

            return View(_interface.CategoryList1());

            
        }
        public async Task<IActionResult> Thisss()
        {
            return View(_context.Thiss.Include(x => x.Category).Include(x => x.SubClass).ToList());
            //return View(_interface.ThissList1());

            
        }
        public async Task<IActionResult> Kingdoms()
        {
            return View(_interface.KingdomsList1());

            
        }
        public async Task<IActionResult> ClassA()
        {
            return View(_context.ClassA.Include(x => x.Kingdom).Include(x => x.SubClass).ToList());
            //return View(_interface.ClassAList());

            
        }
        //// GET: Thisses/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var thiss = await _context.Thiss
        //        .Include(t => t.Category)
        //        .Include(t => t.SubClass)
        //        .FirstOrDefaultAsync(m => m.ThisId == id);
        //    if (thiss == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(thiss);
        //}

        //// GET: Thisses/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
        //    ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassId");
        //    return View();
        //}

        //// POST: Thisses/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ThisId,Name,Descc,Img,SubClassId,CategoryId")] Thiss thiss)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(thiss);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", thiss.CategoryId);
        //    ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassId", thiss.SubClassId);
        //    return View(thiss);
        //}

        //// GET: Thisses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var thiss = await _context.Thiss.FindAsync(id);
        //    if (thiss == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", thiss.CategoryId);
        //    ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassId", thiss.SubClassId);
        //    return View(thiss);
        //}

        //// POST: Thisses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ThisId,Name,Descc,Img,SubClassId,CategoryId")] Thiss thiss)
        //{
        //    if (id != thiss.ThisId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(thiss);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ThissExists(thiss.ThisId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", thiss.CategoryId);
        //    ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassId", thiss.SubClassId);
        //    return View(thiss);
        //}

        //// GET: Thisses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var thiss = await _context.Thiss
        //        .Include(t => t.Category)
        //        .Include(t => t.SubClass)
        //        .FirstOrDefaultAsync(m => m.ThisId == id);
        //    if (thiss == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(thiss);
        //}

        //// POST: Thisses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var thiss = await _context.Thiss.FindAsync(id);
        //    _context.Thiss.Remove(thiss);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ThissExists(int id)
        //{
        //    return _context.Thiss.Any(e => e.ThisId == id);
        //}
    }
}
