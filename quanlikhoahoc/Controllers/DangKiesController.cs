using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using quanlikhoahoc.Models;

namespace quanlikhoahoc.Controllers
{
    public class DangKiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangKiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DangKies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DangKys.Include(d => d.KhoaHoc).Include(d => d.SinhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DangKies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys
                .Include(d => d.KhoaHoc)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.DangKyId == id);
            if (dangKy == null)
            {
                return NotFound();
            }

            return View(dangKy);
        }

        // GET: DangKies/Create
        public IActionResult Create()
        {
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "KhoaHocId", "TenKhoaHoc");
            ViewData["SinhVienId"] = new SelectList(_context.SinhViens, "SinhVienId", "HoTen");
            return View();
        }

        // POST: DangKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DangKyId,SinhVienId,KhoaHocId")] DangKy dangKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "KhoaHocId", "TenKhoaHoc", dangKy.KhoaHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhViens, "SinhVienId", "HoTen", dangKy.SinhVienId);
            return View(dangKy);
        }

        // GET: DangKies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys.FindAsync(id);
            if (dangKy == null)
            {
                return NotFound();
            }
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "KhoaHocId", "TenKhoaHoc", dangKy.KhoaHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhViens, "SinhVienId", "HoTen", dangKy.SinhVienId);
            return View(dangKy);
        }

        // POST: DangKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DangKyId,SinhVienId,KhoaHocId")] DangKy dangKy)
        {
            if (id != dangKy.DangKyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyExists(dangKy.DangKyId))
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
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "KhoaHocId", "TenKhoaHoc", dangKy.KhoaHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhViens, "SinhVienId", "HoTen", dangKy.SinhVienId);
            return View(dangKy);
        }

        // GET: DangKies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys
                .Include(d => d.KhoaHoc)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.DangKyId == id);
            if (dangKy == null)
            {
                return NotFound();
            }

            return View(dangKy);
        }

        // POST: DangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dangKy = await _context.DangKys.FindAsync(id);
            if (dangKy != null)
            {
                _context.DangKys.Remove(dangKy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyExists(int id)
        {
            return _context.DangKys.Any(e => e.DangKyId == id);
        }
    }
}
