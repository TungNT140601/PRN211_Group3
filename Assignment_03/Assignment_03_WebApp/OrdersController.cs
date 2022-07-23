using Assignment_03_Library.DataAccess;
using Assignment_03_Library.Repositories;
<<<<<<< HEAD
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using Assignment_03_WebApp.Helpers;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_03_WebApp.Models;
=======
using Assignment_03_WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

>>>>>>> main
namespace Assignment_03_WebApp
{
    public class OrdersController : Controller
    {
<<<<<<< HEAD
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        IOrderRepository orderRepository = null;
        public OrdersController() => orderRepository = new OrderRepository();
        // GET OrdersController
       

        public ActionResult Index()
        {
           var orderList = orderRepository.GetOrderList();
            return View(orderList);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrdersController/Create
        public ActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.Addnew(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET : OrdersControllers/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    orderRepository.Update(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id.Value);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                orderRepository.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}// end class
=======
       
    }
}
>>>>>>> main
