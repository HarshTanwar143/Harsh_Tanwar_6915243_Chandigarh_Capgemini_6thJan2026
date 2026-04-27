using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal interface IDeviceSpecification
    {
        void SetCategory(string category);
        void SetDeviceType(string type);
        void SetRam(int ram);
        int GetRam();
        string GetDeviceType();
        string GetCategory();
    }
}
