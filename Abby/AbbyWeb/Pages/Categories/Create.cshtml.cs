using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exactly Same as Name");
            }
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
