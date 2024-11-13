using B05ASPC22_w01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B05ASPC22_w01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetDisease()
        {
            var model = applicationDbContext.Diseases.OrderBy(s => s.Name).ToList();
            return Json(model);
        }
        public IActionResult Save([FromBody]  Diseases diseases)
        {
            if(diseases.Id>0)
            {
                applicationDbContext.Entry(diseases).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                applicationDbContext.Diseases.Add(diseases);
            }
           
            if(applicationDbContext.SaveChanges()>0)
            {
                return Json(new { Issucess = true }); 
            }
            return Json(new { Issucess = false });
        }
        public IActionResult Update(Diseases diseases)
        {
            applicationDbContext.Entry(diseases).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (applicationDbContext.SaveChanges() > 0)
            {
                return Json(new { Issucess = true });
            }
            return Json(new { Issucess = false });
        }
        public IActionResult Delete(int id)
        {
          var obj=  applicationDbContext.Diseases.Find(id);
            applicationDbContext.Diseases.Remove(obj);
            if (applicationDbContext.SaveChanges() > 0)
            {
                return Json(new { Issucess = true });
            }
            return Json(new { Issucess = false });
        }
        public IActionResult Edit(int id)
        {
            var obj = applicationDbContext.Diseases.Find(id);
            
                return Json(obj);
            
             
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
