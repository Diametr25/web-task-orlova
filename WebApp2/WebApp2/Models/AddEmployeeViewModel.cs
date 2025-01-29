using WebApp2.DAL.Models;

namespace WebApp2.Models
{
    public class AddEmployeeViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int postId { get; set; }
        public Post post { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }

    }
}
