using bArtTest.Context;
using bArtTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
        public IActionResult accounts(string? id)
        {
            var account = _db.Accounts.Include(a => a.incident).Include(a => a.contacts).Single(a => a.name == id);
            if(account == null)
            {
                return NotFound();
            }
            return Json(account);
        }


        [HttpGet]
        public IActionResult contacts(string? id)
        {
            List<Contact> contacts = _db.Contacts.Where(c => c.account.name == id).ToList();
            if(!contacts.Any())
            {
                return NotFound();
            }
            return Json(contacts);
        }
        [HttpGet]
        public IActionResult incidents(string? id)
        {
            var incident = _db.Incidents.Include(i => i.accounts).Single(i => i.name == id);
            if(incident == null)
            {
                return NotFound();
            }
            return Json(incident);
        }
    }
}
