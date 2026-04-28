using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentAdd.Models;
using System.Data.OleDb;

namespace StudentAdd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\C#\\Students.accdb";
        public string AddStudent(string name, string surname, double average)
        {
            using (OleDbConnection c = new OleDbConnection(cs)) { 
            c.Open();
                string query = "INSERT INTO Students (Name, Surname, Average) VALUES (?,?,?)";
                OleDbCommand cmd=new OleDbCommand(query, c);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", surname);
                cmd.Parameters.AddWithValue("@a", average);
                cmd.ExecuteNonQuery();
                return "Add student";
            }
            
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
    }
}
