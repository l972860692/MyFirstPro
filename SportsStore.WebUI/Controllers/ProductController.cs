using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        private IProductRepository repository;
        public ActionResult Index()
        {

            return View();
        }

        public int pageSize = 4;
        public ActionResult List(string category,int page=1)
        {
           ProductsListViewModel model = new ProductsListViewModel();
           model.PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = pageSize, TotalItems = repository.Products.Where(x => x.Category == null || x.Category == category).Count() };
           model.Products = repository.Products.Where(x=>x.Category==null || x.Category==category).OrderBy(p => p.ProductID).Skip((page - 1) * pageSize).Take(pageSize);
           model.CurrentCategory = category;
           return View(model);


        }











        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
    }
}
