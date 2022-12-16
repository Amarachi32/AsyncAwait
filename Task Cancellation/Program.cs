using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Cancellation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await BVNService.BeginBackUp(timeout: 3000);
        }
    }
}
