﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        private IProductRepository repository;
        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Menu(string category=null)
        {

            ViewBag.SelectedCategory = category;
            IEnumerable<string> categorys = repository.Products.Select(x => x.Category).Distinct().OrderBy(x=>x); 
            return PartialView(categorys);

        }

       

    }
}
