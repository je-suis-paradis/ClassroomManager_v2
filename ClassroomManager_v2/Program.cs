namespace ClassroomManager_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // lists every tool in this course
            Tool[] toolBox = new Tool[] 
            {
                new Tool { Name = "C#", Description = "Basic programming with C#", Difficulty = 5},
                new Tool { Name = "Git", Description = "Source and version control", Difficulty = 5},
                new Tool { Name = "SQL", Description = "Relation database", Difficulty = 5},
                new Tool { Name = "Debugging", Description = "Solve problems", Difficulty = 5},
                new Tool { Name = "Javascript", Description = "Web development", Difficulty = 5}
            };
            // added mock students for swift testing -- you are welcome
            List<Student> students = new List<Student>
            { 
                new Student { Name = "p-nut", IsPresent = false, ProgrammingLVL = 0, Tools = new List<Tool>() },
                new Student { Name = "code-Conny", IsPresent = false, ProgrammingLVL = 2, Tools = new List<Tool>()},
                new Student { Name = "Malin", IsPresent = false, ProgrammingLVL = 0, Tools = new List<Tool>() },
                new Student { Name = "Po-Po Potateis", IsPresent =  false, ProgrammingLVL = 0, Tools = new List<Tool>() },
                new Student { Name = "Bårert", IsPresent = false, ProgrammingLVL = 2, Tools = new List<Tool>() },
            };

            List<Student> oneOhOne = new List<Student>
            {
                new Student { Name = "Baholo", IsPresent = false, ProgrammingLVL = 3, Tools = new List<Tool>()},
                new Student { Name = "Mahalo", IsPresent = false, ProgrammingLVL = 1, Tools = new List<Tool>()},
            };

            bool running = true;
            while (running)
            {
                Console.Clear(); // clears previous menus and choices upon retturn to menu
                
                Console.WriteLine(" |*| CLASSROOM MANAGER |*| \n What would you like to do? ");
                Console.WriteLine("[1] Add student");
                Console.WriteLine("[2] Roll call");
                Console.WriteLine("[3] Today's lecture");
                Console.WriteLine("[4] Students in attendence");
                Console.WriteLine("[5] Check individual student data");
                Console.WriteLine("[6] Reset attendance");
                Console.WriteLine("[7] Exit");
                Console.Write("Choose task (1 - 6): "); 
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        ClassroomHelper.AddStudent(students); // **1:1 (students), (students, toolCatalog) är argument
                        break;

                    case 2:
                        ClassroomHelper.RollCall(students);
                        break;
                    case 3:
                        ClassroomHelper.RunLecture(students, toolBox);
                        break;
                    case 4:
                        ClassroomHelper.PrintRoster(students);
                        break;
                    case 5:
                        ClassroomHelper.StudentData(students);
                        break;
                    case 6:
                        ClassroomHelper.ResetClassList(students);
                        break;
                    case 7:
                        Console.WriteLine("7 Exit");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Sharpen up now, 'kay!?");
                        break;
                }
            }
        }
    }
}
