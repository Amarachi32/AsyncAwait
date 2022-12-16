using System;

namespace Async_Task
{
    internal class ArmatureChef
    {
        private readonly string _name;

        public ArmatureChef( string name)
        {
            _name = name;
        }
        public void MakeBreakFast()
        {
            
            Console.WriteLine($"{_name} Performs Task Synchronously-----------------");
            BreakFast.Prepare();
        }
    }
}
