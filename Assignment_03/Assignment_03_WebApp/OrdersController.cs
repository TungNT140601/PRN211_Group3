using Assignment_03_Library.DataAccess;
using Assignment_03_Library.Repositories;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using Assignment_03_WebApp.Helpers;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_03_WebApp.Models;
namespace Assignment_03_WebApp
{
    public class OrdersController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        IOrderRepository orderRepository = null;

        public OrdersController()
        {
            this.orderRepository = new OrderRepository();
        }

        public ActionResult Index(int? id)
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
            catch
            {
                return View();
            }
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

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order order)
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
}
