using HaloWeb.Data;
using HaloWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HaloWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
            
        }

        
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        //public async Task<IActionResult> OnPost(Category category)

        //If we use bind property then
        public  async Task<IActionResult> OnPost(int id)
        {
           
            
                var categoryFromDB = _db.Categories.Find(Category.Id);
                if (categoryFromDB != null)
                {
                    _db.Categories.Remove(categoryFromDB);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";
                    return RedirectToPage("Index");


                }

            return Page();
        }
    }
}
