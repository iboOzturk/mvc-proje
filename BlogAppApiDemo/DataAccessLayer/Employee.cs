using System.ComponentModel.DataAnnotations;

namespace BlogAppApiDemo.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
