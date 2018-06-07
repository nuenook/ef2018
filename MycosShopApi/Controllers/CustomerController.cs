using Microsoft.AspNetCore.Mvc;
using MycosShopApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MycosShopApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly NORTHWNDContext _context;
        public CustomerController(NORTHWNDContext context)
        {
            _context = context;
        }

        //get customer detail
        [HttpGet]
        public ActionResult Get()
        {
            var item = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .Include(b => b.Product)        
                .GroupBy(g => new { g.Order.Customer.CustomerId, g.Order.Customer.CompanyName, g.Order.Customer.ContactName })
                .Select(s => new { s.Key.CustomerId, s.Key.CompanyName, s.Key.ContactName, totalSum = s.Sum(t => (float)t.UnitPrice * 0.07 + (float)t.UnitPrice) }).ToList();
               
            return Ok(item);
        }


        [HttpGet("getmax")]
        public ActionResult GetMax()
        {
            var max = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .GroupBy(g => new { g.Order.Customer.CustomerId})
                .Select(s => new { maxSum = s.Sum(t => t.Quantity * t.UnitPrice) }).Max(m => m.maxSum);
          
            return Ok(max);
        }

        [HttpGet("getmin")]
        public ActionResult GetMin()
        {
            var min = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .GroupBy(g => new { g.Order.Customer.CustomerId })
                .Select(s => new { minSum = s.Sum(t => t.Quantity * t.UnitPrice) }).Min(m => m.minSum);

            return Ok(min);
            
        }

        [HttpGet("getavg")]
        public ActionResult GetAVG()
        {
            var avg = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .GroupBy(g => new { g.Order.Customer.CustomerId })
                .Select(s => new { avgSum = s.Sum(t => t.Quantity * t.UnitPrice) }).Average(m => m.avgSum);

            return Ok(avg);
        }

        [HttpGet("getsum")]
        public ActionResult GetSum()
        {
            var sum = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .Include(b => b.Product).Sum(m => m.UnitPrice * m.Quantity);
            return Ok(sum);
        }

    }
}
