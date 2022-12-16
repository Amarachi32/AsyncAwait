using System;
using System.Threading.Tasks;

namespace Async_Task
{
    internal class ProChef
    {
        private readonly string _name;
        public ProChef(string name)
        {
            _name = name;
        }
        public async Task MakeBreakFast()
        { 
            Console.WriteLine($"{_name} Performs Task Asynchronously-----------------"); 
            await Async_Task.BreakFast.PrepareAsync();
        }
    }
}