using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextChar.Model
{
    class Accubattery
    {
        private int voltage;
        private bool stateOn = false;

        public Accubattery(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }

        public void trunOff()
        {
            this.stateOn = false;
        }
        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
