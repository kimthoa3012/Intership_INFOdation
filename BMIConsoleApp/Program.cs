using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIConsoleApp
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var h = 1.6f;
            var w = 45f;
            var bmiObj = new BMI(h, w);

            Console.WriteLine("Height: {0} m", h);
            Console.WriteLine("weight: {0} kg", w);

            Console.WriteLine("Result: {0} (kg/m2) - {1}", bmiObj.Index(), bmiObj.Status());

        }
    }
}