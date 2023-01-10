using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_project.Model
{
    internal class Group
    {
        static int _id = 1;
        public int Id { get; set; }
        public Group()
        {
            Id = _id;
            _id++;
            Students = new List<Student>();
        }
        public string No { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; set; }
    }
}