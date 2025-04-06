using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInfoWebApp.Data;
using StudentInfoWebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace StudentInfoWebApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context) => _context = context;

        public IList<Course> CourseList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = "";

        public async Task OnGetAsync()
        {
            var courses = from c in _context.Courses
                          select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                courses = courses.Where(c => c.Name.Contains(SearchString));
            }

            CourseList = await courses.ToListAsync();
        }
    }

}
