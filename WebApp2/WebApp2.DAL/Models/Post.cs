using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp2.DAL.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        //[Required(ErrorMessage = "Не указан код должности")]
        public int Code { get; set; }
        //[Required(ErrorMessage = "Не указано название должности")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
