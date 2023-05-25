using HelloRHOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRHOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            using (MySqlConnection con = new MySqlConnection(Configuration["ConnectionStrings:Default"]))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Employee;",con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var employe = new Employee
                    {
                        EmployeeCode = reader["EmployeeCode"].ToString(),
                        Name = reader["EmployeeName"].ToString()

                    };
                    emp.Add(employe);
                }
            }
                return View(emp);
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
