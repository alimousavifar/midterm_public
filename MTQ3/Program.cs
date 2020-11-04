using System;

namespace MTQ3
{
    class Program
    {
        static void Main(string[] args)
        {

            User user1 = new User("Joe", "Biden", 100, 1);
            HDMI[] user1HDMIArray = { new HDMI(2.1, "INPUT1", 1), new HDMI(2.1, "INPUT2", 2), new HDMI(2.1, "INPUT3", 3) };
            Monitor[] user1Monitors = { new Monitor(user1HDMIArray.Length, user1HDMIArray, new Button()) };
            Console.WriteLine("User name {0}, User Age {1}", user1._firstName+ user1._lastName , user1.GetOwnedMonitors());
            for (int i = 0; i < user1Monitors.Length; i++)
            {
                if (user1Monitors[i].GetMonitorStatus()) user1Monitors[i].TurnOnMonitor(user1Monitors[i]._powerButton);

                for (int j = 0; j < user1HDMIArray.Length; j++)
                    Console.WriteLine("MonitorStatus: {0}, HDMI name: {1}, HDMI version: {2}", user1Monitors[i].GetMonitorStatus(), user1HDMIArray[j].GetHDMIName(), user1HDMIArray[j].GetVersion());

            }


            User user2 = new User("Donold", "Trump", 99, 2);
            HDMI[] user2HDMIArray = { new HDMI(2.1, "INPUT1", 1), new HDMI(3.1, "INPUT2", 2)};
            Monitor[] user2Monitors = { new Monitor(user2HDMIArray.Length, user2HDMIArray, new Button()),
                                        new Monitor(user2HDMIArray.Length, user2HDMIArray, new Button()) };
            Console.WriteLine("User name {0}, User Age {1}", user2._firstName + user2._lastName, user2.GetOwnedMonitors());
            for (int i = 0; i < user1Monitors.Length; i++)
            {
                if (user2Monitors[i].GetMonitorStatus()) user1Monitors[i].TurnOnMonitor(user1Monitors[i]._powerButton);
                for (int j = 0; j < user2HDMIArray.Length; j++)
                    Console.WriteLine("MonitorStatus{0}, HDMI name: {1}, HDMI version: {2}", user1Monitors[i].GetMonitorStatus(), user2HDMIArray[j].GetHDMIName(), user2HDMIArray[j].GetVersion());
            }

        }

    }

    public class Monitor
    {
        protected int _NumberOfHDMIConnections;
        public HDMI[] _Hdmi;
        public Button _powerButton;

        public Monitor(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton)
        {
            this._NumberOfHDMIConnections = NumberOfHDMIConnections;
            this._Hdmi = Hdmi;
            this._powerButton = powerButton;
        }
        public void TurnOnMonitor(Button powerButton)
        {
            powerButton.SetStatus(true);
        }
        public bool GetMonitorStatus()
        {
            if (_powerButton.GetStatus()) return true;
            else return false;
        }

    }

    class User
    {
        public string  _firstName;
        public string _lastName;
        public int _age;
        public int _ownedMonitors;

        public User(string fName, string lName, int age, int ownedMonitors) {
            this._firstName = fName;
            this._lastName = lName;
            this._age = age;
            this._ownedMonitors = ownedMonitors;
        }

        public  int GetOwnedMonitors() {
            return this._ownedMonitors;

        }

    }

    public class Monitor4k : Monitor
    {
        public Monitor4k(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton) {

        }

    }

    public class MonitorOLED : Monitor
    {
        public MonitorOLED(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton)
        {

        }

    }

    public class MonitorLCD : Monitor
    {
        public MonitorLCD(int NumberOfHDMIConnections, HDMI[] Hdmi, Button powerButton) : base(NumberOfHDMIConnections, Hdmi, powerButton)
        {

        }

    }

    public class Button
    {
        private bool _status;
        public Button() {
            this._status = false;
        }
        public bool GetStatus()
        {
            return this._status;

        }
        public void SetStatus(bool myStatus)
        {
            this._status = myStatus;

        }

    }

    public class HDMI
    {
        private double _version;
        private string _HDMIName;
        protected int _HDMIInputNumber;

        public HDMI(double version, string HDMIName, int HDMIInputNumber)
        {
            this._version = version;
            this._HDMIName = HDMIName;
            this._HDMIInputNumber = HDMIInputNumber;
        }
        public double GetVersion()
        {
            return this._version;
        }
        public void SetVersion(double _version)
        {
            this._version = _version;
        }
        public string GetHDMIName()
        {
            return this._HDMIName;
        }
    }
}
