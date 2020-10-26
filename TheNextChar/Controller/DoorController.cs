using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextChar.Model;

namespace TheNextChar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackonDoorChanged;

        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.callbackonDoorChanged = onDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackonDoorChanged.OnDoorOpenStateChanged("CLOSED", "dor is closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackonDoorChanged.OnDoorOpenStateChanged("CLOSED", "dor is opend");
        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackonDoorChanged.OnDoorLockeStateChanged("LOCKED", "door is locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackonDoorChanged.OnDoorLockeStateChanged("UNLOCKED", "door is unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }

    interface OnDoorChanged
    {
        void OnDoorLockeStateChanged(string value, string message);
        void OnDoorOpenStateChanged(string value, string message);
    }
}
