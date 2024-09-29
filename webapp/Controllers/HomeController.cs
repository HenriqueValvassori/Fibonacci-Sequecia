using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp.Models;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int? numero)
        {
            if (numero.HasValue)
            {
                bool pertence = PertenceASequenciaFibonacci(numero.Value);
                ViewBag.Mensagem = pertence ? $"{numero} pertence à sequência de Fibonacci" : $"{numero} não pertence à sequência de Fibonacci";
            }

            return View();
        }

        private bool PertenceASequenciaFibonacci(int numero)
        {
            int a = 0, b = 1, c = 0;
            while (c <= numero)
            {
                if (c == numero)
                {
                    return true;
                }
                c = a + b;
                a = b;
                b = c;
            }
            return false;
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
    }
}
