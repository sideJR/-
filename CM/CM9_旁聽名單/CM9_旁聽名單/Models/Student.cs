using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CM9_旁聽名單.Models
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Sex;
        public string Department;
        public Student(int Id, string Name, string Sex, string Department)
        {
            this.Id = Id;
            this.Name = Name;
            this.Sex = Sex;
            this.Department = Department;
        }
    }
}