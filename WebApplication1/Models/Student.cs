using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        [Display(Name = "Id")]
        public Int32 Id { get; set; }

        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Surname")]
        public String Surname { get; set; }


        [Display(Name = "Age")]
        public Int32 Age { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Employed")]
        public Boolean? IsWorking { get; set; }

        [Display(Name = "Marital status")]
        public MaritalStatus? MaritalStatus { get; set; }

        public List<Student> Children { get; set; }

        public Student()
        {
            Children = new List<Student>();
        }
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced,
        Widowed
    }
}
