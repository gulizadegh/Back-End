using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_project.Model
{
    internal class Student
    {
        public Student()
        {
            Id = _id;
            _id++;
        }
        private static int _id = 1;
        public int Id { get; set; }
        public string FullName { get; set; }
        public string GroupNo { get; set; }
        public bool Type { get; set; }
    }
}