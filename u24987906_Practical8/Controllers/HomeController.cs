using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using u24987906_Practical8.Data;
using u24987906_Practical8.Models;
using Microsoft.EntityFrameworkCore;

namespace u24987906_Practical8.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _context;

        public HomeController(HospitalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var equipmentList = _context.Equipments.ToList();

            return View(equipmentList);
        }

        public IActionResult MonitoringEquipment()
        {
            var monitoringList = _context.Equipments.Where(e => e.equipmentType == "Monitoring").OrderBy(e => e.equipmentName).ToList();
            return View(monitoringList);
        }

        public IActionResult EagerLoading(int id = 1)
        {
            var equipment = _context.Equipments.Include(m => m.MaintenanceRecords).FirstOrDefault(e => e.equipmentID == id);
            return View(equipment);
        }

        public IActionResult ExplicitLoading(int id = 2)
        {
            var equipment = _context.Equipments.FirstOrDefault(e => e.equipmentID == id);

            if (equipment != null)
            {
                _context.Entry(equipment).Collection(m => m.MaintenanceRecords).Load();
            }
            return View(equipment);
        }

        public IActionResult LazyLoading(int id = 3)
        {
            var equipment = _context.Equipments.FirstOrDefault(e => e.equipmentID == id);

            return View(equipment);
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
