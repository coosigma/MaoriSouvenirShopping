using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaoriSouvenirShopping.Data;
using MaoriSouvenirShopping.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace MaoriSouvenirShopping.Controllers
{
    public class SouvenirsController : Controller
    {
        private readonly WebShopContext _context;
        private readonly IHostingEnvironment _hostingEnv;

        public SouvenirsController(WebShopContext context, IHostingEnvironment hEnv)
        {
            _context = context;
            _hostingEnv = hEnv;
        }

        // GET: Souvenirs
        public async Task<IActionResult> Index()
        {
            var webShopContext = _context.Souvenirs.Include(s => s.Category).Include(s => s.Supplier);
            return View(await webShopContext.ToListAsync());
        }

        // GET: Souvenirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .Include(s => s.Category)
                .Include(s => s.Supplier)
                .Include(s => s.OrderItems)
                    .ThenInclude(e => e.Order)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }

            return View(souvenir);
        }

        // GET: Souvenirs/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
            return View();
        }

        // POST: Souvenirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SouvenirName,Price,PhotoPath,Description,CategoryID,SupplierID")] Souvenir souvenir, IList<IFormFile> _files)
        {
            var relativeName = "";
            var fileName = "";

            if (_files.Count < 1)
            {
                relativeName = "/Images/Souvenir.svg";
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue
                                      .Parse(file.ContentDisposition)
                                      .FileName
                                      .Trim('"');
                    //Path for localhost
                    relativeName = "/Images/SouvenirImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                    using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }
            souvenir.PhotoPath = relativeName;

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(souvenir);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
            return View(souvenir);
        }

        // GET: Souvenirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs.SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
            return View(souvenir);
        }

        // POST: Souvenirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, IList<IFormFile> _files)
        {
            if (id == null)
            {
                return NotFound();
            }
            var relativeName = "";
            var fileName = "";

            if (_files.Count < 1)
            {
                relativeName = "/Images/Souvenir.svg";
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue
                                      .Parse(file.ContentDisposition)
                                      .FileName
                                      .Trim('"');
                    //Path for localhost
                    relativeName = "/Images/SouvenirImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                    using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }
            //souvenir.PhotoPath = relativeName;
            var souvenirToUpdate = await _context.Souvenirs.SingleOrDefaultAsync(s => s.SouvenirID == id);
            if (await TryUpdateModelAsync<Souvenir>(
                souvenirToUpdate,
                "",
                s => s.SouvenirName, s => s.Price, s => s.PhotoPath,
                s => s.PhotoPath, s => s.Description, s => s.CategoryID,
                s => s.SupplierID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
            //ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
            return View(souvenirToUpdate);
        }

        // GET: Souvenirs/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .Include(s => s.Category)
                .Include(s => s.Supplier)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(souvenir);
        }

        // POST: Souvenirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var souvenir = await _context.Souvenirs
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Souvenirs.Remove(souvenir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool SouvenirExists(int id)
        {
            return _context.Souvenirs.Any(e => e.SouvenirID == id);
        }
    }
}
