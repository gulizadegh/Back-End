using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_project.Service.Interfaces
{
    internal interface IGroup
    {
        public void CreateGroup(string categoryName, int groupNo, bool isOnline);
        public void CreateStudent(string name, string groupName, bool? isGuaranteed);
        public void EditGroup(string groupName);
        public void ShowAllStudents();
        public void ShowAllGroups();
        public void ShowStudentsInGroup(string groupName);
    }
}