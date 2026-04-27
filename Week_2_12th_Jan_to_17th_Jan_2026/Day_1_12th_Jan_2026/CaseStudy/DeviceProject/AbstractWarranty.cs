using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal abstract class AbstractWarranty
    {
        protected int warrantyYears;
        protected bool extendedWarranty;

        public abstract void SetWarranty(int years);

        public virtual void ExtendWarranty()
        {
            extendedWarranty = true;
            warrantyYears += 1;
        }

        public int GetWarrantyPeriod()
        {
            return warrantyYears;
        }
    }
}
