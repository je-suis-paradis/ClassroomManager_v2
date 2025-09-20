namespace ClassroomManager_v2
{
    // ClassroomHelper is a helper class, only runs method
    public static class ClassroomHelper
    {
        // case 1
        public static void AddStudent(List<Student> students)
        {
            Console.Write("Enter student's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter start level: ");
            int level = int.Parse(Console.ReadLine());

            Student s = new Student() // s == studentToAdd
            {
                Name = name,
                ProgrammingLVL = level,
                IsPresent = false,
                Tools = new List<Tool>()
            };

            students.Add(s);
            Console.WriteLine($"Student: {name} added for roll call. Press any key...");
            Console.ReadKey();

        }

        // case 2
        public static void RollCall(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("The list is currently empty. Now, key outta' here!");                                            
                Console.ReadKey();
                return;
            }  

            Console.WriteLine("Is student present? -- Yes | No");
            for (int i = 0; i < students.Count; i++)
            {
                Console.Write($"{i + 1}. {students[i].Name}: ");
                string response = Console.ReadLine();
                students[i].IsPresent = (response == "yes" || response == "Yes" || response == "YES" || response == "y");
                // either || or "eller"
            }

            Console.WriteLine("Roll call over; press any key to proceed.");
            Console.ReadKey();
        }

        // case 3
        public static void RunLecture(List<Student> students, Tool[] toolBox) // **2.1 parameter
        {
            if(students.Count == 0)
            {
                Console.WriteLine("No students found. Press a key --BOOM! To Start Menu again.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Pick a tool, then master it.");
            for(int i = 0; i <toolBox.Length; i++)
            {
                Tool tool  = toolBox[i];
                Console.WriteLine($"[{i + 1}]. {tool.Name} {tool.Description} {tool.Difficulty}");
            }

            Console.Write("Choose one (1-5:) ");
            int choice = int.Parse(Console.ReadLine());

            Tool t  = toolBox[choice - 1];

            // minus 1 pga en array startar på noll,
            // men normies vet inte, så de trycker på 1

            Tool tOfChoice = toolBox[choice - 1];
            int level = 5;
            int rollCall = 0;

            foreach(Student s in students)
            {
                if(s.IsPresent)
                {
                    rollCall++;
                    s.ProgrammingLVL += level;
                    s.LearnTool(tOfChoice);                }
            }

            if (rollCall < 0)
            {
                Console.WriteLine($"Lecture finished! We added {tOfChoice.Name} to {rollCall} student's toolboxes, and updated their programming level.");
            }
            else
            {
                Console.WriteLine("No students in class. Robin is BEYOND furious.");
            }

            Console.WriteLine("Smash keyboard to face to continue.");
            Console.ReadKey();
        }

        // case 4
        public static void PrintRoster(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students on this list yet. \nGo to Start Menu and press 1 to add student.\n");
                return;
            }

            Console.WriteLine("*-*-* Class list *-*-*");
            for (int i = 0; i < students.Count; i++)
            {
                // robin would for (var s = students[i]; s.ProgrammingLVL; s.IsPresent} int i = students.Count; i++) #godmode
                Console.WriteLine($"{i + 1} {students[i].Name} \n| Level: {students[i].ProgrammingLVL}/100 \n| Presence: {students[i].IsPresent}\n");
            }

            Console.WriteLine("Move forward -- press any key.");
            Console.ReadKey();
        }

        // case 5
        public static void StudentData(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students in attendance. High five key to move on.");
                Console.ReadKey();
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]. {students[i].Name}");
            }

            Console.WriteLine("Pick a student: ");
            int pick = int.Parse(Console.ReadLine());
            return;

            Student s = students[pick - 1];

            Console.WriteLine("=== STUDENT DATA | TOOLBOX CONTENTS ===");
            Console.WriteLine($"Student: {s.Name}");
            Console.WriteLine($"Programming level: {s.ProgrammingLVL}/100"); 
            Console.WriteLine($"Tools: ");

            if(s.Tools.Count == 0)
            {
                Console.WriteLine("Toolbox currently empty.");
            }
            else
            {
                foreach(Tool t in s.Tools)
                {
                    Console.WriteLine($" {t.Name} | Points/Course Credits: {t.Difficulty} | Description: {t.Description}");
                }                
            }

            Console.WriteLine(" # # # # # # # # # # ");
            Console.WriteLine("Press a key to proceed!");
            return;
        }

        // case 6
        public static void ResetClassList(List<Student> students)
        {
            foreach (Student student in students)
            {
                student.IsPresent = false;
            }
            Console.WriteLine("Class list reset. Press any key for start menu.");
            Console.ReadKey();
        }
    }
}

