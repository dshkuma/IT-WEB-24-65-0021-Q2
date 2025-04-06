using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInfoWebApp.Data;
using StudentInfoWebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace StudentInfoWebApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> StudentList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var students = _context.Students.Include(s => s.Course).AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Name.Contains(SearchString));
            }

            StudentList = await students.ToListAsync();
        }
    }


}
