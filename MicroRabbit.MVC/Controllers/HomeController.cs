using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTOs;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroRabbit.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> Transfer(TransferViewModel  transferVM)
        {
            TransferDTO transferDTO = new TransferDTO()
            {
                FromAccount = transferVM.FromAccount,
                ToAccount = transferVM.ToAccount,
                TransferAmount = transferVM.TransferAmount
            };
            await _transferService.Transfer(transferDTO);
            return View("Index");
        }
    }
}
