using bArtTest.Context;
using bArtTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace bArtTest.Controllers
{
    public class ApiController : Controller
    {
        MVCContext _db;
        public ApiController(MVCContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult accounts()
        {
            return Json(_db.Accounts.Select(a => a.name).ToList());
        }


        [HttpGet]
        public IActionResult contacts(string? id)
        {          
            List<Contact> contacts = _db.Accounts.Where(a => a.name == id).SelectMany(a => a.contacts).ToList();
            if(!contacts.Any())
            {
                return NotFound();
            }
            return Json(contacts);
        }
    }
}
