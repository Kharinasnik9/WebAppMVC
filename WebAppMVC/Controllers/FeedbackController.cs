﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models.Db;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class FeedbackController : Controller
    {
       
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
