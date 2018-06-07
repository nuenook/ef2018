using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MycosShopApi.Models;
using Microsoft.AspNetCore.Cors;

namespace MycosShopApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly NORTHWNDContext _context;
        public ProductController(NORTHWNDContext context)
        {
            _context = context;
        }
        //GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var item = _context.Products.Select(p => new { p.ProductId, p.ProductName, p.UnitPrice, VAT = ((float)p.UnitPrice * 0.07 + (float)p.UnitPrice) }).ToList();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // GET api/values/5
        [HttpGet("getmax")]
        public ActionResult GetMax()
        {
            try
            {
                var max = _context.Products.Max(m => m.UnitPrice);
                return Ok(max);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("getmin")]
        public ActionResult GetMin()
        {
            try
            {
                var min = _context.Products.Min(m => m.UnitPrice);
                return Ok(min);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("getavg")]
        public ActionResult GetAvg()
        {
            try
            {
                var avg = _context.Products.Average(m => m.UnitPrice);
                return Ok(avg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
