using Console_project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_project.Service.Implementations
{
    internal static class AppLists
    {
        static AppLists()
        {
            Groups = new List<Group>();
            Students = new List<Student>();
        }
        public static List<Group> Groups { get; set; }
        public static List<Student> Students { get; set; }
    }
}