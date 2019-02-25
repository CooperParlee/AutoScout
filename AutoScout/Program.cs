using HttpsApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScout
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HttpsApiManager.InitApiClient();

            BasicDataCall test = new BasicDataCall(Obfiscation.GetApiKey());

            test.GetTeamData(4564);
            Console.Read();
        }
    }
}
