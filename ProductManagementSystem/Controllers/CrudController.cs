using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    public class CrudController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CrudController(ApplicationDBContext db)
        {
            _db = db;
        }
       public class CategotyD
        {
            public string CategoryName { get; set; }
        }
        
        public IActionResult CrudOperation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetCrudDetails()
        {
            List<CateProd> list = new List<CateProd>();
            var displaydata = (from ct in _db.CategoryTable
                               join pt in _db.ProductTable on ct.Id equals pt.CategoryId
                               select new
                               {
                                   pt.Id,
                                   ct.Name,
                                   pt.Title,
                                   pt.Quantity,
                                   pt.Price,
                                   pt.Description
                               }).ToList();
            foreach (var item in displaydata)
            {
                list.Add(new CateProd
                {
                    Sno=item.Id,
                    CategoryName=item.Name,
                    Title=item.Title,
                    Quantity=item.Quantity,
                    Price=item.Price,
                    Description=item.Description

                });
            }

            return Json(list);
        }
        [HttpPost]
        public IActionResult AddProduct(CateProd user)
        {
            
            var Obj = new Category { Name = user.CategoryName,IsActive=false };
            _db.CategoryTable.Add(Obj);
            _db.SaveChanges();
            var maxCatId= _db.CategoryTable.Max(x => x.Id);
            var product = new Product { CategoryId = maxCatId, Title = user.Title, Quantity = user.Quantity, Price = user.Price, Description = user.Description };
            _db.ProductTable.Add(product);
            _db.SaveChanges();
            return Json("Product Created Sucessfully");
        }

        [HttpPost]
        public IActionResult UpdateProduct(CateProd user)
        {
            var Result = _db.CategoryTable.Where(x => x.Id == user.Sno);
            foreach (Category c in Result)
            {
                c.Name = user.CategoryName;
            }
            _db.SaveChanges();
            var Result1 = _db.ProductTable.Where(x => x.Id == user.Sno);
            foreach (Product c in Result1)
            {
                c.Title = user.Title;
                c.Quantity = user.Quantity;
                c.Price = user.Price;
                c.Description = user.Description;
            }
            _db.SaveChanges();
            return Json("Product Updated Sucessfully");
        }
        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {
            var Result = _db.CategoryTable.Where(x => x.Id == id).SingleOrDefault();
            _db.CategoryTable.Remove(Result);
            _db.SaveChanges();
            var Result1 = _db.ProductTable.Where(x => x.Id == id).SingleOrDefault();
            _db.ProductTable.Remove(Result1);
            _db.SaveChanges();
            return Json("Product Delete Successfully");
        }

    }
}
