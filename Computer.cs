using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Computer
    {
        //fields
        readonly string id;

        private bool? antenna;
        public bool? Antenna
        {
            get { return antenna; }
            set { antenna = value; }
        }

        private double? hardDrive;
        public double? HardDrive
        {
            get { return hardDrive; }
            set { if (value >= 0) hardDrive = value; }
        }

        private int?[] licenses;

        public int?[] Licenses { get { return licenses; } }

        private int ram;
        public int Ram
        {
            get
            {
                int RAM = this.ram;
                if (this.Antenna == true)
                {
                    RAM -= 100;
                }
                else
                {
                    RAM -= 50;
                }
                for (int i = 0; i < this.licenses?.Length; i++)
                {
                    if (this.licenses?[i] != 0)
                    {
                        RAM -= 10;
                    }
                }
                return RAM;
            }
            set { if (value >= 1000) ram = value; }
        }

        private int nextInt;

        //constructor
        public Computer(bool? hasCellularAntenna, Double? hardDriveStorage, int?[] licenses,
                int RAM)
        {
            this.nextInt = 0;
            this.id = "C" + nextInt.ToString();
            this.nextInt++;
            this.Antenna = hasCellularAntenna;
            this.HardDrive = hardDriveStorage;
            //if (licenses != null)
            //{
            for (int i = 0; i < this.licenses?.Length; i++)
            {
                //if (licenses[i] != null)
                //{
                this.licenses[i] = (licenses?[i] ?? null);
                //}
            }
            // }
            //  else
            //{
            //  this.licenses = null;
            //}
            this.Ram = RAM;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + this.id);


            String toAppend = (this.Antenna.ToString() ?? "not present");
            sb.Append("\nCellular Antenna: " + toAppend);

            // if (this.hardDrive != null)
            // {
            toAppend = (this.HardDrive.ToString() ?? "n/a");
            sb.Append("\nHard drive storage: " + toAppend);

            // }
            if (this.licenses != null)
            {
                sb.Append("\nNumber of licenses per each software installed:");
                for (int i = 0; i < this.licenses?.Length; i++)
                {
                    sb.Append("\n\tSoftware " + (i + 1) + ": " + this.licenses[i]);
                }
            }
            sb.Append("\nRAM: " + this.Ram);
            return sb.ToString();
        }
    }
}
