using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIConsoleApp
{
    internal class BMI
    {
        float height;
        float weight;

        public BMI(float height, float weight = 45)
        {
            this.height = height;
            this.weight = weight;
        }

        public float Index()
        {
            return this.weight / (this.height * this.height);
        }

        public string Status()
        {
            var id = Index();
            if (id < 18.5) return "Underweight";
            else if (id <= 24.9) return "Normal";
            else if (id <= 29.9) return "Overweight";
            else if (id <= 34.9) return "Obese";
            else return "Extremly Obese";

        }
    }
}

