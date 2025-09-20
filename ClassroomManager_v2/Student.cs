namespace ClassroomManager_v2
{
    public class Student // defines properties that should apply to every student
    {
        public string Name; // public string, int, bool, list of (student's) tools from class Tools
        public int ProgrammingLVL;
        public bool IsPresent;
        public List<Tool> Tools;

        public void LearnTool(Tool tool) // when calling method, add argument from Tool, named tool
        {
            bool hasTool = false;

            foreach (Tool t in Tools)
            {
                if(t.Name == tool.Name)
                {
                    hasTool = true;
                    break;
                }
            }

            if(!hasTool) // exclamation means !caution hasTool set to false; == doesn't have it -- so Add it!
            {
                Tools.Add(tool);
            }
        }
    }
}
