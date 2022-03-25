﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using System.IO;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(DBContext context)
        {
            _context = context;
           
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var empList =  (from emp in _context.Employee
                             join Department d in _context.Department
                             on emp.DepartmentId equals d.DepartmentId
                             select new
                             {
                                 EmployeeId = emp.EmployeeId,
                                 EmployeeName = emp.EmployeeName,
                                 DepartmentName = d.DepartmentName
                             });

            //return await empList.ToListAsync();
            return await _context.Employee.Include(d=>d.Department.DepartmentName).ToListAsync();
        }
        
        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }

    

        //[HttpPost]
        //[Route("Upload")]
        //public async Task<string> SaveFile([FromForm] UploadFile obj)
        //{
        //   if (obj.files.Length)
        //    {
        //        try
        //         {
        //            if(!Directory.Exists(_env.WebRootPath + "\\Images\\"+obj.files.FileName))
        //            {
        //                Directory.CreateDirectory(_env.WebRootPath + "\\Images\\");
        //            }
        //            using (FileStream filestream = System.IO.File.Create(_env.WebRootPath+ "\\Images\\" + obj.files.FileName))
        //            {
        //                obj.file.Copyto(filestream);
        //                filestream.Flush();
        //                return "\\Images\\"+obj.files.FileName;
        //            }            
        //         }
        //        catch(Exception ex)
        //        {
        //            return ex.Message;
        //        }
        //    }

        //}
    }
}
