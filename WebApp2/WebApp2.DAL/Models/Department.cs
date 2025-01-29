using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp2.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        //[Required(ErrorMessage = "Не указан код отдела")]
        public int Code { get; set; }
        //[Required(ErrorMessage = "Не указано название отдела")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
