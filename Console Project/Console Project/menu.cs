using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_project.Enum;

namespace Console_project.Service.Implementations
{
    internal static class MenuS
    {
        private static GroupS groupservice = new GroupS();
        public static void MenuCreateGroup()
        {
            Console.Clear();
            Console.WriteLine("Kateqoriya sechin");
        CheckIsNumberCategoryNo:
            CategoryRepeat();
        NotFoundError:
            int categoryNo;
            bool isNumberCategoryNo = int.TryParse(Console.ReadLine(), out categoryNo);
            int EnumMin = Console_project.Enum.Category.GetValues(typeof(Category)).Cast<int>().Min();
            int EnumMax = Console_project.Enum.Category.GetValues(typeof(Category)).Cast<int>().Max();
            if ((categoryNo < EnumMin || categoryNo > EnumMax))
            {
                Console.Clear();
                Console.WriteLine("Kateqoriya tapilmadi, duzgun sechim edin.");
                CategoryRepeat();
                goto NotFoundError;
            }
            else
            {
                if (!isNumberCategoryNo)
                {
                    Console.Clear();
                    Console.WriteLine("Eded daxil edin");
                    goto CheckIsNumberCategoryNo;
                }
                else if (categoryNo == 0)
                {
                    Console.Clear();
                    Console.WriteLine("0 dan boyuk qrup nomresi daxil edin");
                    goto CheckIsNumberCategoryNo;
                }
                string NewCategoryName = "";
                foreach (Category category in Console_project.Enum.Category.GetValues(typeof(Category)))
                {
                    if (categoryNo == (int)category)
                    {
                        NewCategoryName = category.ToString().Substring(0, 1);
                    }
                }
                Console.WriteLine("Qrup nomresini daxil edin");
                int groupNo;
            CheckIsNumberGroupNo:
                bool isNumber = int.TryParse(Console.ReadLine(), out groupNo);
                if (!isNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Eded daxil edin");
                    goto CheckIsNumberGroupNo;
                }
                else if (groupNo == 0)
                {
                    Console.Clear();
                    Console.WriteLine("0dan boyuk eded daxil edin");
                    goto CheckIsNumberGroupNo;
                }
                bool IsOnline;
                int IntCreateGroup;
                Console.Clear();
                Console.WriteLine($"Onlayn yoxsa eyani qrup yaradirsiniz?");
            CheckIsNumberIsOnline:
                Console.WriteLine($"Onlayn ucun 0 klikleyin");
                Console.WriteLine($"Eyani ucun 1 klikleyin");
                bool CreateCheckStatus = int.TryParse(Console.ReadLine(), out IntCreateGroup);
                if (CreateCheckStatus)
                {
                    if (IntCreateGroup == 1)
                    {
                        IsOnline = false;
                    }
                    else if (IntCreateGroup == 0)
                    {
                        IsOnline = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("0 ve ya 1 daxil edin");
                        goto CheckIsNumberIsOnline;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Eded daxil edin");
                    goto CheckIsNumberIsOnline;
                }
                groupservice.CreateGroup(NewCategoryName, groupNo, IsOnline);
                Console.Clear();
                return;
            }
        }
        public static void MenuCreateStudent()
        {
            Console.Clear();
            string FullName = "";
        namecheck:
        fullcheck:
            Console.WriteLine("Adinizi daxil edin: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Soyadinizi daxil edin: ");
            string Surname = Console.ReadLine();
            while (true)
            {
                bool namestatus = int.TryParse(Name, out int namecheck);
                bool surnamestatus = int.TryParse(Surname, out int surnamecheck);
                if (namestatus && surnamestatus)
                {
                    Console.WriteLine("Eded daxil etmeyin");
                    goto namecheck;
                }
                else if (Name.Length >= 3 && Name.Length <= 15 && Surname.Length <= 15 && Surname.Length >= 3)
                {
                    Name.Trim();
                    Console.WriteLine("");
                    Surname.Trim();
                    Console.WriteLine("");
                    FullName = Name + " " + Surname;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Tam adinizin uzunlugu 3 ile 15 herf arasinda olmalidir.");
                    goto fullcheck;
                }
            }
            Console.WriteLine("Qrup nomrenizi daxil edin: ");
            string groupName = Console.ReadLine();
            Console.WriteLine("Zemanetli tehsil isteyirsiniz?");
            bool isGuarantee;
            int IntCreateStudent;
        CheckIsNumberIsGuarantee:
            Console.WriteLine("Zemanetli ucun 1 klikleyin");
            Console.WriteLine("Zemanetsiz ucun 0 klikleyin");
            bool CreateStudentStatus = int.TryParse(Console.ReadLine(), out IntCreateStudent);
            if (CreateStudentStatus)
            {
                if (IntCreateStudent == 0)
                {
                    isGuarantee = false;
                }
                else if (IntCreateStudent == 1)
                {
                    isGuarantee = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("0 ve ya 1 daxil edin");
                    goto CheckIsNumberIsGuarantee;
                }
            }
            else
            {
                Console.WriteLine("Eded daxil edin");
                goto CheckIsNumberIsGuarantee;
            }
            groupservice.CreateStudent(FullName, groupName, isGuarantee);
        }
        public static void MenuShowAllStudents()
        {
            groupservice.ShowAllStudents();
        }
        public static void MenuShowAllGroups()
        {
            groupservice.ShowAllGroups();
        }
        public static void MenuShowStudentsInGroup()
        {
            Console.WriteLine("Qrup adi daxil edin: ");
        namecheckempty:
            string groupName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(groupName))
            {
                Console.Clear();
                Console.WriteLine("Bos ola bilmez, yeniden daxil edin: ");
                goto namecheckempty;
            }
            groupservice.ShowStudentsInGroup(groupName);
        }
        public static void MenuEditGroup()
        {
            Console.WriteLine("Qrup adi daxil edin: ");
        editgrroup:
            string groupName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(groupName))
            {
                Console.Clear();
                Console.WriteLine("Bos ola bilmez, yeniden daxil edin: ");
                goto editgrroup;
            }
            groupservice.EditGroup(groupName);
        }
        public static void Info()
        {
            Console.WriteLine("Birini sechin: ");
            Console.WriteLine("1. Yeni qrup yarat");
            Console.WriteLine("2. Butun qruplarin siyahisi");
            Console.WriteLine("3. Qrup redaktesi");
            Console.WriteLine("4. Qrupdaki telebeleri goster");
            Console.WriteLine("5. Butun telebelerin siyahisi");
            Console.WriteLine("6. Yeni telebe yarat");
        }
        public static int MenuInput()
        {
            bool status = true;
            while (status)
            {
                status = int.TryParse(Console.ReadLine(), out int result);
                if (result > 0 && result < 7 && status == true)
                {
                    status = false;
                    return result;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Duzgun daxil edin");
                    break;
                }
            }
            return 0;
        }
        static void CategoryRepeat()
        {
            foreach (Category category in Console_project.Enum.Category.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{category} ucun {(int)category} klikleyin");
            }
        }
    }
}