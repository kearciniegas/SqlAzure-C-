using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectSQLAzure.Models;

namespace ProjectSQLAzure.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ContactController : Controller {
        private ContactsContext contactsContext;
        public ContactController (ContactsContext context) {
            contactsContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get () {
            return contactsContext.ContactSet.ToList ();
        }

        [HttpGet ("{id}")]
        public ActionResult<Contacts> Get (int id) {
            var selectedContact = (from c in contactsContext.ContactSet where c.Identificador == id select c).FirstOrDefault ();
            return selectedContact;
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Contacts value) {
            Contacts newContact = value;
            contactsContext.ContactSet.Add (newContact);
            contactsContext.SaveChanges();
            return Ok("Tu contacto esta listo");
        }
        ~ContactController () {
            contactsContext.Dispose ();
        }
    }
}