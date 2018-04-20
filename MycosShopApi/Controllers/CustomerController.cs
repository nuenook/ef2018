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
            var item = _context.Products.Select(p => new { p.ProductId, p.ProductName, p.UnitPrice, VAT = ((float)p.UnitPrice * 0.07 + (float)p.UnitPrice) }).ToList();

            return Ok(item);
        }


        [HttpGet("getmax")]
        public ActionResult GetMax()
        {
            var max = _context.OrderDetails
                .Include(c => c.Order.Customer)
                .Include(b => b.Product).Max(m => m.UnitPrice * m.Quantity);
            return Ok(max);
        }

        [HttpGet("getmin")]
        public ActionResult GetMin()
        {            
            return Ok(0);
        }

        [HttpGet("getavg")]
        public ActionResult GetAVG()
        {            
            return Ok(0);
        }

        [HttpGet("getsum")]
        public ActionResult GetSum()
        {
            return Ok(0);
        }

    }
}
