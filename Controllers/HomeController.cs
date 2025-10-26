using System.Diagnostics;
using ElinnovTechAssessment_EricaDominguez.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElinnovTechAssessment_EricaDominguez.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        // --> POST endpoint to check if a number is prime
        [HttpPost]
        public JsonResult CheckPrime(int number)
        {
            // --> checks if the number is greater than 1 and has no divisors other 1 and itself
            bool isPrime = number > 1 && !Enumerable.Range(2, (int)Math.Sqrt(number) - 1).Any(i => number % i == 0);

            // --> generates the result whether the number inputted is prime or not
            string result = isPrime ? $"{number} is a prime number." : $"{number} is not a prime number.";

            // --> returns result as a JSON response
            return Json(result);
        }

        // --> POST endpoint to calculate the factorial of a number
        [HttpPost]
        public JsonResult CalculateFactorial(int number)
        {
            // --> initialize the factorial result as 1 (as factorial of 0 and 1 is 1)
            long factorial = 1;

            // --> calculate the factorial iteratively from 2 to the given number
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            // --> generates the result with the factorial value
            string result = $"{number}! = {factorial}";

            // --> returns result as a JSON response
            return Json(result);
        }
    }
}
