using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextChar.Model;

namespace TheNextChar.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callBackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callBackOnPowerChanged)
        {
            this.callBackOnPowerChanged = callBackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callBackOnPowerChanged.OnPowerChangedStatus("ON", "power is on");
        }
        public void turnOff()
        {
            this.accubattery.trunOff();
            this.callBackOnPowerChanged.OnPowerChangedStatus("OFF", "power is off");
        }
        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
    }
    interface OnPowerChanged
    {
        void OnPowerChangedStatus(string value, string message);
    }
}
