﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextChar.Model;


namespace TheNextChar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool poweIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }
        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Close the door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }
            if (!poweIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power avaliable");
                return;
            }
            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void toggleThePowerButton()
        {
            if (!doorIsClosed())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }

    }
    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }

}
