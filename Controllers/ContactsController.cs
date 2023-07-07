using Contacts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContactsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Contacts> Contact_List = _db.MyContacts;
            return View(Contact_List);
        }
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Contacts obj)
        {
            if(obj.Name == obj.Phone_Number)
            {
                ModelState.AddModelError("name", "The Phone Number Cannot Exactly Match The Name.");
            }
            if (ModelState.IsValid)
            {
                _db.MyContacts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Contact Created Successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Edit(int ?id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var ContactsFromDb = _db.MyContacts.Find(id);
            if(ContactsFromDb == null)
            {
                return NotFound();
            }
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Contacts obj)
        {
            if (obj.Name == obj.Phone_Number)
            {
                ModelState.AddModelError("name", "The Phone Number Cannot Exactly Match The Name.");
            }
            if (ModelState.IsValid)
            {
                _db.MyContacts.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Contact Updated Successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ContactsFromDb = _db.MyContacts.Find(id);
            if (ContactsFromDb == null)
            {
                return NotFound();
            }
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deleting(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Myobj = _db.MyContacts.Find(id);
            if (Myobj == null)
            {
                return NotFound();
            }
                _db.MyContacts.Remove(Myobj);
                _db.SaveChanges();
            TempData["success"] = "Contact Deleted Successfuly";
            return RedirectToAction("Index");
        }

    }
}
