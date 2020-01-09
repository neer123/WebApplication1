using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository<Employee> _dataRepository;
        private HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger, IDataRepository<Employee> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }
        [AcceptVerbs(new string[] {"Get","Post"})]
        public IActionResult Index()
        {


          //  var token = client.GetAsync("http://localhost:62136/api/login?UserName=Test1&Password=12");
          //  var res =  client.GetAsync("http://localhost:5000/api/login/GetValue");
         //   client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
            client.BaseAddress = new Uri("http://localhost:62136/api/");
            //HTTP GET
            var responseTask = client.GetAsync("login?UserName=Test1&Password=12");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("http://localhost:62136/api/Login/");
                client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Content.ReadAsStringAsync().Result);
                var responseTask1 = client1.GetAsync("GetValue");
                responseTask1.Wait();
                var result1 = responseTask1.Result;
            }


                // List<Employee> lst = _dataRepository.GetAll().ToList();

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


            return View(_dataRepository.GetAll(skipcount, prowcount));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
