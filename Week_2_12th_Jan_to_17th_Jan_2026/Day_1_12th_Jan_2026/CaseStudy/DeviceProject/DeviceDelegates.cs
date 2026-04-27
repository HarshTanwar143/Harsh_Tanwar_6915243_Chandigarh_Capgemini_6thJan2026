using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal delegate void DeviceAction(string message);

    internal class DeviceNotifier
    {
        public DeviceAction Notify;

        public void Trigger(string message)
        {
            Notify?.Invoke(message);
        }
    }
}
