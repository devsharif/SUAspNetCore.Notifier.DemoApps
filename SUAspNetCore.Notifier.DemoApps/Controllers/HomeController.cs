using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SUAspNetCore.Notifier.DemoApps.Models;
using SU.AspNetCore.Notifier.Services;
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
                    _notifier.Success("This is a Success Notification", 3);
                    _notifier.Info("This is a Info Notification", 4);
                    _notifier.Warning("This is a Warning Notification", 6);
                    _notifier.Error("This is a Error Notification", 7);
                    break;
            }

            return RedirectToAction("Index");
        }

    }
}
