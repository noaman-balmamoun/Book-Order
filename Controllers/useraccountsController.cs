using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Order.Data;
using Book_Order.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Book_Order.Controllers
{
    public class useraccountsController : Controller
    {
        private readonly BookDbContext _context;

        public useraccountsController(BookDbContext context)
        {
            _context = context;
        }

        // GET: useraccounts
        public async Task<IActionResult> Index()
        {
              return View(await _context.useraccounts.ToListAsync());
        }
        
        public IActionResult login()
        {
            return View();
        }
        [HttpPost, ActionName("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string na, string pa)
        {
            SqlConnection conn1 = new SqlConnection("Server=.;Database=Books;Trusted_Connection=true;Encrypt=false");
            string sql;
            sql = "SELECT * FROM useraccounts where name ='" + na + "' and  pass ='" + pa + "' ";
            SqlCommand comm = new SqlCommand(sql, conn1);
            conn1.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {

                string role = (string)reader["role"];
                string id = Convert.ToString((int)reader["Id"]);
                string name=(string)reader["name"];

                HttpContext.Session.SetString("Name", na);
                HttpContext.Session.SetString("Client", name);
                
               
                ViewBag.Name= HttpContext.Session.GetString("Client");




                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetString("userid", id);

                reader.Close();
               
                conn1.Close();

                if (role == "customer")
                    return RedirectToAction("catalogue", "books");
                else if (role == "admin")
                    
                return RedirectToAction("Index", "orders");

                else
                    return RedirectToAction("Users", "login");

            }
            else
            {
                ViewData["Message"] = "wrong user name password";
                return View();
            }
        }

        // GET: useraccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.useraccounts == null)
            {
                return NotFound();
            }

            var useraccounts = await _context.useraccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useraccounts == null)
            {
                return NotFound();
            }

            return View(useraccounts);
        }

        // GET: useraccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: useraccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,pass,email")] useraccounts useraccounts)
        {

            useraccounts.role = "customer";
           
             
                _context.Add(useraccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction("login");
            
            
        }

        // GET: useraccounts/Edit/5
       
        // POST: useraccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: useraccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.useraccounts == null)
            {
                return NotFound();
            }

            var useraccounts = await _context.useraccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useraccounts == null)
            {
                return NotFound();
            }

            return View(useraccounts);
        }

        // POST: useraccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.useraccounts == null)
            {
                return Problem("Entity set 'BookDbContext.useraccounts'  is null.");
            }
            var useraccounts = await _context.useraccounts.FindAsync(id);
            if (useraccounts != null)
            {
                _context.useraccounts.Remove(useraccounts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool useraccountsExists(int id)
        {
          return _context.useraccounts.Any(e => e.Id == id);
        }
    }
}
