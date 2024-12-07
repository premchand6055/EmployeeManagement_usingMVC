using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            // Retrieve employee data and return the list to the view
            var employees = await _context.EmployeeDetails.ToListAsync();
            return View(employees);
        }

        // POST: Employees/Edit
        // Update employee details via AJAX
        [HttpPost]
        public async Task<IActionResult> Edit(int EmployeeID, string Name, string Designation, DateTime DateOfJoin, decimal Salary, string Gender, string State)
        {
            var employee = await _context.EmployeeDetails.FindAsync(EmployeeID);
            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            // Update employee details
            employee.Name = Name;
            employee.Designation = Designation;
            employee.DateOfJoin = DateOfJoin;
            employee.Salary = Salary;
            employee.Gender = Gender;
            employee.State = State;

            try
            {
                // Save changes to the database
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (DbUpdateException)
            {
                return Json(new { success = false, message = "Error updating the employee" });
            }
        }

        // POST: Employees/Delete
        // Delete employee via AJAX
        [HttpPost]
        public async Task<IActionResult> Delete(int EmployeeID)
        {
            var employee = await _context.EmployeeDetails.FindAsync(EmployeeID);
            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            // Remove employee record from database
            _context.EmployeeDetails.Remove(employee);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        // Private method to check if an employee exists
        private bool EmployeeExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmployeeID == id);
        }
    }
}
