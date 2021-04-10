using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SUAspNetCore.Notifier.DemoApps.Models;
using SUAspNetCore.Notifier.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SUAspNetCore.Notifier.DemoApps.Controllers
{
    public class HomeController : Controller
    {
        // Dependency for SUAspNetCore.Notifier
        public INotifierService _notifier { get; }
        public HomeController(INotifierService notifier)
        {
            _notifier = notifier;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notifier(string type)
        {
            switch (type)
            {
                case "success":
                    _notifier.Success("This is a Success Notification");
                    break;

                case "info":
                    _notifier.Info("This is a Info Notification");
                    break;
                case "warning":
                    _notifier.Warning("This is a Warning Notification");
                    break;
                case "error":
                    _notifier.Error("This is a Error Notification");
                    break;

                default:
                    _notifier.Success("This is a Success Notification", 5);
                    _notifier.Info("This is a Info Notification", 7);
                    _notifier.Warning("This is a Warning Notification", 9);
                    _notifier.Error("This is a Error Notification", 10);
                    break;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Success()
        {
            _notifier.Success("This is a Success Notification");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Info()
        {
            _notifier.Info("This is a Info Notification");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Warning()
        {
            _notifier.Warning("This is a Warning Notification");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Error()
        {
            _notifier.Error("This is a Error Notification");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult All()
        {
            _notifier.Success("This is a Success Notification");
            _notifier.Info("This is a Info Notification");
            _notifier.Warning("This is a Warning Notification");
            _notifier.Error("This is a Error Notification");
            return RedirectToAction("Index");
        }

    }
}
