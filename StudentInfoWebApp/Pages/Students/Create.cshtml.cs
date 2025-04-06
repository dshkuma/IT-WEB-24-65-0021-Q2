using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentInfoWebApp.Data;
using StudentInfoWebApp.Models;

namespace StudentInfoWebApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public SelectList CourseList { get; set; }

        public void OnGet()
        {
            CourseList = new SelectList(_context.Courses.ToList(), "CourseId", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CourseList = new SelectList(_context.Courses.ToList(), "CourseId", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
