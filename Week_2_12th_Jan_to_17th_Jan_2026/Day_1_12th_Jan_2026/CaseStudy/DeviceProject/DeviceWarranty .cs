using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal class DeviceWarranty : AbstractWarranty
    {
        public override void SetWarranty(int years)
        {
            warrantyYears = years;
            extendedWarranty = false;
        }

        public void PrintWarrantyDetails()
        {
            Console.WriteLine("Warranty Period : " + warrantyYears + " years");
            Console.WriteLine("Extended Warranty : " + (extendedWarranty ? "Yes" : "No"));
        }
    }
}
