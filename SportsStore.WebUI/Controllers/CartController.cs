using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities; 

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        } 

        public ActionResult Index()
        {
            return View();
        }

    }
}
