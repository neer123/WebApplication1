using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StudentsData
    {

        public static IQueryable<Student> GetAllStudent()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Joe",
                    Surname = "Crosswave",
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = false,

                    Children = new List<Student>
                    {
                        new Student
                        {
                            Id = 11,
                            Name = "Katy",
                            Surname = "Crosswave",

                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        },
                        new Student
                        {
                            Id = 12,
                            Name = "Kate",
                            Surname = "Crosswave",

                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        }
                    }
                },
                new Student
                {
                    Id = 2,
                    Name = "Merry",
                    Surname = "Lisel",
                    MaritalStatus = MaritalStatus.Widowed,

                    Age = (Int32)(DateTime.Now - new DateTime(1978, 05, 06)).TotalDays / 365,
                    Birthday = new DateTime(1978, 05, 06)
                },
                new Student
                {
                    Id = 3,
                    Name = "Henry",
                    Surname = "Crux",
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1990, 11, 19)).TotalDays / 365,
                    Birthday = new DateTime(1990, 11, 19),
                    IsWorking = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Cody",
                    Surname = "Jurut",

                    Age = (Int32)(DateTime.Now - new DateTime(1970, 08, 11)).TotalDays / 365,
                    Birthday = new DateTime(1970, 08, 11),
                    IsWorking = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Simon",
                    Surname = "Scranton",
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1985, 10, 10)).TotalDays / 365,
                    Birthday = new DateTime(1985, 10, 10)
                }
            }.AsQueryable();
        }
    }
}
