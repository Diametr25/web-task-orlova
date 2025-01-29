using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp2.DAL.Models
{
    public class Employee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        //[Required(ErrorMessage = "Не указана фамилия")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Surname { get; set; }
        //[Required(ErrorMessage = "Не указано имя")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Name { get; set; }
        public string Patronymic { get; set; }

        //[Required(ErrorMessage = "Не указан номер телефона")]
        public int Phone { get; set; }
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthdate { get; set; }
        //[Required(ErrorMessage = "Не указана дата принятия на работу")]
        public DateTime EmploymentDate { get; set; }


        public int PostId { get; set; }

        [JsonIgnore]
        public Post post { get; set; }
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department department { get; set; }
    }
}
