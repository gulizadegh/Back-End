using Console_project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_project.Service.Interfaces;
using Console_project.Service.Implementations;

namespace Console_project.Service.Implementations
{
    internal class GroupS : IGroup
    {
        public void CreateGroup(string categoryName, int groupNo, bool isOnline)
        {
            if (categoryName != null && groupNo != 0)
            {
                bool hasGroup = false;
                foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                {
                    if (categoryName == group.No.Substring(0, 1) && groupNo.ToString() == group.No.Substring(1))
                    {
                        hasGroup = true;
                        break;
                    }
                }
                if (!hasGroup)
                {
                    Group group = new Group();
                    group.No = categoryName + groupNo;
                    group.IsOnline = isOnline;
                    if (isOnline)
                    {
                        group.Limit = 15;
                    }
                    else
                    {
                        group.Limit = 10;
                    }
                    Console_project.Service.Implementations.AppLists.Groups.Add(group);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Bu adda qrup artiq movcuddur.");
                }
            }
        }
        public void CreateStudent(string name, string groupName, bool? isGuarantee)
        {
            if (name != null && groupName != null && isGuarantee != null)
            {
                bool hasGroup = false;
                if (Console_project.Service.Implementations.AppLists.Groups.Count != 0)
                {
                    foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                    {
                        if (group.No.ToLower() == groupName.ToLower())
                        {
                            if (group.IsOnline)
                            {
                                if (Console_project.Service.Implementations.AppLists.Students.Count < 15)
                                {
                                    Student student = new Student();
                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;
                                    Console_project.Service.Implementations.AppLists.Students.Add(student);
                                    group.Students.Add(student);
                                    hasGroup = true;
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Qrup doludur.");
                                    return;
                                }
                            }
                            else
                            {
                                if (Console_project.Service.Implementations.AppLists.Students.Count < 10)
                                {
                                    Student student = new Student();
                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;
                                    Console_project.Service.Implementations.AppLists.Students.Add(student);
                                    group.Students.Add(student);
                                    hasGroup = true;
                                    Console.WriteLine(Console_project.Service.Implementations.AppLists.Students.Count);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Qrup doludur.");
                                    return;
                                }
                            }
                        }
                    }
                }
                if (!hasGroup)
                {
                    Console.Clear();
                    Console.WriteLine($"Qrup: {groupName} tapilmadi, zehmet olmasa yaradin.");
                }
            }
            Console.Clear();
        }
        public void EditGroup(string groupName)
        {
            if (Console_project.Service.Implementations.AppLists.Groups.Count != 0)
            {
                foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                {
                    if (group.No.ToLower().Trim() == groupName.ToLower().Trim())
                    {
                        Console.WriteLine("Yeni qrup adi daxil edin");
                        int newGroupNo;
                    CheckIsNumberGroupNo:
                        bool isNumber = int.TryParse(Console.ReadLine(), out newGroupNo);
                        if (!isNumber)
                        {
                            Console.WriteLine("Eded daxil edin");
                            goto CheckIsNumberGroupNo;
                        }
                        foreach (var qrup in Console_project.Service.Implementations.AppLists.Groups)
                        {
                            if ((group.No.Substring(0, 1) + newGroupNo.ToString()).ToLower() == qrup.No.ToString().ToLower())
                            {
                                Console.Clear();
                                Console.WriteLine("Bu qrup artiq movcuddur");
                                return;
                            }
                        }
                        Console.Clear();
                        group.No = group.No.Substring(0, 1) + newGroupNo.ToString();
                        Console.WriteLine("Ugurla evezlendi");
                        return;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Qrup yaradin");
                return;
            }
            Console.Clear();
            Console.WriteLine("Duzgun daxil edin");
        }
        public void ShowAllStudents()
        {
            if (Console_project.Service.Implementations.AppLists.Groups.Count > 0)
            {
                foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                {
                    if (Console_project.Service.Implementations.AppLists.Students.Count > 0)
                    {
                        if (group.Students.Count > 0)
                        {
                            foreach (var student in group.Students)
                            {
                                Console.WriteLine($"Ad Soyad: {student.FullName}, Qrup adi: {student.GroupNo}, Nov: {group.IsOnline}");

                            }
                        }
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Telebe tapilmadi");
                        return;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Qrup yaradin");
                return;
            }
        }
        public void ShowAllGroups()
        {
            if (Console_project.Service.Implementations.AppLists.Groups.Count != 0)
            {
                Console.Clear();
                foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                {
                    string groupType = "";
                    if (group.IsOnline)
                    {
                        groupType = "Onlayn";
                    }
                    else
                    {
                        groupType = "Eyani";

                    }
                    Console.WriteLine($"Qrup nomresi: {group.No}, Qrup novu: {groupType}, Telebelerin sayi: {group.Students.Count}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Qrup yoxdur");
                return;
            }
        }

        public void ShowStudentsInGroup(string groupName)
        {
            if (Console_project.Service.Implementations.AppLists.Groups.Count != 0)
            {
                foreach (var group in Console_project.Service.Implementations.AppLists.Groups)
                {
                    if (group.No.Trim().ToLower() == groupName.Trim().ToLower())
                    {
                        if (group.Students.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Qeyd etdiyiniz qrup bosdur.");
                            return;
                        }
                        foreach (var student in group.Students)
                        {
                            string studentStatus = "";
                            if (student.Type)
                            {
                                studentStatus = "Zemanetli";
                            }
                            else
                            {
                                studentStatus = "Zemanetsiz";
                            }
                            Console.WriteLine($"Telebenin ad soyadi: {student.FullName}, Tedris tipi: {studentStatus}");
                        }
                        continue;
                    }
                    else if (Console_project.Service.Implementations.AppLists.Groups.Count == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Qrup tapilmadi");
                        return;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Qrup yaradin");
                return;
            }
        }
    }
}