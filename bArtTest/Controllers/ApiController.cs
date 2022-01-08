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
            var incident = _db.Accounts.Where(a => a.name == id).Include(a => a.incident).Select(a => a.incident).FirstOrDefault();
            if (incident == null)
            {
                return NotFound();
            }
            return Json(incident);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult createincident([FromBody] CUModel body)
        {
            if(body == null) return BadRequest();
            var account = _db.Accounts.FirstOrDefault(a => a.name == body.account);
            if (account != null) return BadRequest();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    Incident incident = new Incident { description = body.description };
                    _db.Incidents.Add(incident);
                    _db.SaveChanges();
                    account = new Account { name = body.account, Incidentname = incident.name };
                    _db.Accounts.Add(account);
                    _db.SaveChanges();
                    int id = account.id;
                    Contact contact = new Contact { Accountid = id,
                        email = body.email, 
                        firts_name = body.first_name,
                        last_name = body.last_name,
                        account = account
                    };
                    _db.Contacts.Add(contact);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Problem();
                }
            }
            return Ok();
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult addcontact([FromBody] CUModel body)
        {
            var account = _db.Accounts.FirstOrDefault(a => a.name == body.account);
            var contact = _db.Contacts.FirstOrDefault(a => a.email == body.email);
            if (contact != null) return BadRequest();
            if (account == null) return NotFound();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    contact = new Contact
                    {
                        Accountid = account.id,
                        email = body.email,
                        firts_name = body.first_name,
                        last_name = body.last_name,
                        account = account
                    };
                    _db.Contacts.Add(contact);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Problem();
                }
            }
            return Ok();
        }

        [HttpPut]
        [Produces("application/json")]
        public IActionResult editcontact([FromBody] CUModel body)
        {
            var contact = _db.Contacts.FirstOrDefault(a => a.email == body.email);
            if (contact == null) return NotFound();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if(body.first_name != null)
                        contact.firts_name = body.first_name;
                    if (body.last_name != null)
                        contact.last_name = body.last_name;
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Problem();
                }
            }
            return Ok();
        }
        [HttpPut]
        [Produces("application/json")]
        public IActionResult editincident([FromBody] CUModel body)
        {
            var inciden = _db.Accounts.Where(a => a.name == body.account).Include(a => a.incident).Select(a => a.incident).FirstOrDefault();
            if(inciden == null) return NotFound();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    inciden.description = body.description;
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Problem();
                }
            }
            return Ok();
        }
    }
}
