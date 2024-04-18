using BlogTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogTask.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogContext _context;

        public BlogsController()
        {
            _context = new BlogContext();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);

                _context.SaveChanges();
                return Redirect("/Home/Index"); 
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return Redirect("/Home/Index");
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Update(blog);
                _context.SaveChanges();
                return Redirect("/Home/Index");
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(string query)
        {
            var result = _context.Blogs
                                 .Where(b => b.Url.Contains(query) || (b.Name != null && b.Name.Contains(query)))
                                 .ToList();
            return View("Index", result); 
        }


    }
}