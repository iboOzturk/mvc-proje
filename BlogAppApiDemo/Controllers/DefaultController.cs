using BlogAppApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        public class Deneme
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string KullaniciAdi { get; set; }
        }
        [HttpGet("[action]")]
        public IActionResult MarketList()
        {
            using var c = new Context();
            var query = (from market in c.Market
                        join employe in c.Employees on market.Price equals employe.Id
                        select new Deneme
                        {
                            Id = market.Id,
                            Name = market.Name,
                            KullaniciAdi = employe.Name,                      
                        }).ToList();

            return Ok(query); 
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeByID(int id)
        {
            using var c = new Context();
            var emp = c.Employees.Find(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
           var emp=c.Employees.Find(id);
            if (emp != null)
            {
                c.Remove(emp);
                c.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

    }
}
