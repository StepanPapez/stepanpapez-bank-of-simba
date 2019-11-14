using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankOfSimba.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankOfSimba.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public static List<BankAccount> Accounts { get; set; } = new List<BankAccount>
        {
            new BankAccount("Timon", 30.25, "Meerkat", false, true),
            new BankAccount("Pumbaa", 1.5, "Warthog", false, true),
            new BankAccount("Mufasa", 10000, "Lion", true, true),
            new BankAccount("Rafiki", 115.3, "Mandrill", false, true)
        };

        [HttpGet("show")]
        public IActionResult Show()
        {
            var simba = new BankAccount("Simba", 2000, "Lion");
            // ViewBag.Item = simba;
            // return View();

            // or using Model as follows:
            return View(simba);
        }

        [HttpGet("htmlception")]
        public IActionResult Htmlception()
        {
            ViewData["string"] = "This is an <em>HTML</em> text. <b>Enjoy yourself!</b>"; // will be shown as a string including html tags
            return View();
        }

        [HttpGet("accounts")]
        public IActionResult GetAllAccounts()
        {
            return View(Accounts);
        }

        [HttpPost("accounts")]
        public IActionResult CreateNewAccount(string name, double balance, string animalType, bool isKing, bool isGood)
        {
            Accounts.Add(new BankAccount(name, balance, animalType, isKing, isGood));
            return RedirectToAction("GetAllAccounts");
        }

        [HttpPost("raise-balance")]
        public IActionResult RaiseBalance(string name)
        {
            var accountToRaise = Accounts.Find(a => a.Name.Equals(name));
            if (accountToRaise.IsKing)
            {
                accountToRaise.Balance += 100;
            }
            else
            {
                accountToRaise.Balance += 10;
            }
            //return View(accounts);
            return RedirectToAction("GetAllAccounts");
        }
    }
}