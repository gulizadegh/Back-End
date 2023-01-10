using Console_project.Service.Implementations;

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.BackgroundColor = ConsoleColor.White;

do
{
    MenuS.Info();

    switch (MenuS.MenuInput())
    {
        case 1:
            MenuS.MenuCreateGroup();

            break;
        case 2:
            MenuS.MenuShowAllGroups();
            break;
        case 3:
            MenuS.MenuEditGroup();
            break;
        case 4:
            MenuS.MenuShowStudentsInGroup();
            break;
        case 5:
            MenuS.MenuShowAllStudents();
            break;
        case 6:
            MenuS.MenuCreateStudent();
            break;
    }
} while (true);