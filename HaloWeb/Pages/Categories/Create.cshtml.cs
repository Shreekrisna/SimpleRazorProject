using HaloWeb.Data;
using HaloWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HaloWeb.Pages.Categories
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

        //public async Task<IActionResult> OnPost(Category category)

        //If we use bind property then
        public  async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString()) //Custom Validation--server side validation
            {
                ModelState.TryAddModelError("Category.Name", "The DisplayOrder cannot match the Name");
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
