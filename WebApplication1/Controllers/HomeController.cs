using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository<Employee> _dataRepository;
        public HomeController(ILogger<HomeController> logger, IDataRepository<Employee> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {

            List<Employee> lst = _dataRepository.GetAll().ToList();

            return View();
        }
        [HttpGet]
        public IActionResult Student()
        {
            int count = StudentsData.GetAllStudent().Count();
            return View(StudentsData.GetAllStudent());
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student obj)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
                _dataRepository.Add(emp);
            return View();
        }

        [HttpGet]
        public IActionResult EmployeeDetails()
        {

            return View(GetAllEmployee());
        }

        private List<Employee> GetAllEmployee()
        {
            List<Employee> lst = _dataRepository.GetAll().ToList();
            return lst;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GridPaging()
        {
            int pagecount = 1;
            int skipcount = 0;
            int prowcount  = 3;
            if (HttpContext.Request.QueryString.HasValue)
            {
                string page = HttpContext.Request.QueryString.Value.ToString().Remove(0, 1);
                string[] arr = page.Split('&');
                pagecount = Convert.ToInt32(arr[0].Split("=")[1]);

                prowcount = Convert.ToInt32(arr[1].Split("=")[1]);
                if (prowcount == 0)
                {
                    prowcount = 3;
                }
                if (pagecount>1)
                {
                    skipcount = (pagecount-1) * prowcount;
                } 
            }
            int rowcount = _dataRepository.RecordCountEmployee();

            int page_nocount = Convert.ToInt32(rowcount / prowcount);

            if(rowcount%3 >1)
            {
                page_nocount = page_nocount + 1;
            }

            ViewBag.TP = page_nocount;
            ViewBag.CP = pagecount;


            return View(_dataRepository.GetAll(skipcount, prowcount));  //.Skip(skipcount).Take(3));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
