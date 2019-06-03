using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyAPP.Models;
using CompanyAPP.Dto;

namespace CompanyAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        public CustomersController(CompanyDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public PagedResult<Customer> FilterAndPage([FromQuery]UrlQuery urlQuery)
        {
            PagedResult<Customer> returnModel = new PagedResult<Customer>();
            try
            {

                // For Best Perfomance, I have created a SP : "exec FilterCustomers 'lee','',0,1,10"

                var customers = _context.Customer.Where(c =>
                                                c.Firstname.Contains(urlQuery.Search) ||
                                                c.Lastname.Contains(urlQuery.Search) ||
                                                c.Email.Contains(urlQuery.Search) ||
                                                c.CellNo.Contains(urlQuery.Search) ||
                                                c.Address.Contains(urlQuery.Search) ||
                                                c.City.Contains(urlQuery.Search) ||
                                                c.Region.Contains(urlQuery.Search) ||
                                                c.Country.Contains(urlQuery.Search) ||
                                                c.PostalCode.Contains(urlQuery.Search) ||
                                                c.Status.Contains(urlQuery.Search) ||
                                                c.PassportNo.Contains(urlQuery.Search));

                switch (urlQuery.SortField)
                {

                    //asc
                    case "Firstname":
                        customers = customers.OrderBy(s => s.Firstname);
                        break;
                    case "Lastname":
                        customers = customers.OrderBy(s => s.Lastname);
                        break;
                    case "Email":
                        customers = customers.OrderBy(s => s.Email);
                        break;
                    case "CellNo":
                        customers = customers.OrderBy(s => s.CellNo);
                        break;
                    case "Status":
                        customers = customers.OrderBy(s => s.Status);
                        break;
                    case "PassportNo":
                        customers = customers.OrderBy(s => s.PassportNo);
                        break;

                    //desc
                    case "Firstname_desc":
                        customers = customers.OrderByDescending(s => s.Firstname);
                        break;
                    case "Lastname_desc":
                        customers = customers.OrderByDescending(s => s.Lastname);
                        break;
                    case "Email_desc":
                        customers = customers.OrderByDescending(s => s.Email);
                        break;
                    case "CellNo_desc":
                        customers = customers.OrderByDescending(s => s.CellNo);
                        break;
                    case "Status_desc":
                        customers = customers.OrderByDescending(s => s.Status);
                        break;
                    case "PassportNo_desc":
                        customers = customers.OrderByDescending(s => s.PassportNo);
                        break;

                    default:
                        customers = customers.OrderBy(s => s.Firstname);
                        break;
                }

                returnModel = customers.Include(c => c.FkStatus).GetPaged(urlQuery.PageNumber ?? 1, urlQuery.PageSize);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnModel;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customerList = await _context.Customer.ToListAsync();

            return Ok(customerList);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customer.Include(c => c.FkStatus).SingleOrDefaultAsync(i => i.PkCustomerId == id);

            customer.Note = await _context.Note.Where(c => c.FkCustomerId == customer.PkCustomerId)
                .Select(n => new Note{
                    Note1 = n.Note1
                    , PkNoteId = n.PkNoteId
                    , FkCustomerId = n.FkCustomerId
                }).ToListAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.PkCustomerId)
            {
                return BadRequest();
            }

            //remove all notes
            //customer.Note.Remove()
            _context.Note.RemoveRange(_context.Note.Where(c => c.FkCustomerId == customer.PkCustomerId));
            _context.SaveChanges();

            _context.Entry(customer).State = EntityState.Modified;

            if (customer.Note.Count() > 0)
            {


                //add current notes
                foreach (var note in customer.Note)
                {
                    note.PkNoteId = 0;
                    await _context.Note.AddAsync(note);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.PkCustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.PkCustomerId == id);
        }
    }
}