using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
           
                int?[] licenses = { 1, 4, 2, 3, 0 };

                Computer defaultPrototype = new Computer(true, 8.0, licenses, 8);
                Computer userPrototype = null;

                Computer[] computers = new Computer[10];

                Computer mine;

                int upTo = -1;
                int choice = -1;

                do
                {

                    choice = menu();

                    switch (choice)
                    {
                        case 1:
                            mine = addComputer();
                            computers[++upTo] = mine;
                            break;
                        case 2:
                            userPrototype = addComputer();
                            Console.Out.WriteLine("Your computer Prototype is:");
                            Console.Out.WriteLine(userPrototype.ToString());
                            break;
                        case 3:
                            Console.Out.WriteLine("Enter the array index you would like to view");
                            int index = Int32.Parse(Console.ReadKey().ToString());
                            if (computers[index] == null)
                            {
                                Console.Out.WriteLine(defaultPrototype);
                            }
                            else
                            {
                                Console.Out.WriteLine(computers[index]);
                            }
                            break;
                        case 4:
                            Console.Out.WriteLine("Average Ram: " + averageRam(computers, 0, 9, true, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Percent of Devices with a Cellular Antenna: " + percentCellularAntenna(computers, 0, 9, true, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Hard Drive Capacity: " + avgHDCapacity(computers, 0, 9, true, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Number of Software Licenses Per Machine: " + avgLicenses(computers, 0, 9, true, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Number of Licenses per Program: ");
                            int[] avgLicensesForEachProgram4 = avgLicensesPerProgram(computers, 0, 9, true, userPrototype, defaultPrototype);
                            for (int i = 0; i < avgLicensesForEachProgram4.Length; i++)
                            {
                                Console.Out.WriteLine("Program " + i + ": " + avgLicensesForEachProgram4[i]);
                            }
                            break;
                        case 5:
                            Console.Out.WriteLine("Please specify a start index.");
                            int start = Int32.Parse(Console.ReadKey().ToString());
                            Console.Out.WriteLine("Please specify an end index.");
                            int stop = Int32.Parse(Console.ReadKey().ToString());
                            Console.Out.WriteLine("Average Ram: " + averageRam(computers, start, stop, false, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Percent of Devices with a Cellular Antenna: " + percentCellularAntenna(computers, start, stop, false, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Hard Drive Capacity: " + avgHDCapacity(computers, start, stop, false, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Number of Software Licenses Per Machine: " + avgLicenses(computers, start, stop, false, userPrototype, defaultPrototype));
                            Console.Out.WriteLine("Average Number of Licenses Per Program: ");
                            int[] avgLicensesForEachProgram5 = avgLicensesPerProgram(computers, start, stop, false, userPrototype, defaultPrototype);
                            for (int j = 0; j < avgLicensesForEachProgram5.Length; j++)
                            {
                                Console.Out.WriteLine("Program " + j + ": " + avgLicensesForEachProgram5[j]);
                            }
                            break;
                        case 6:
                            Console.Out.WriteLine("Thank you for using our application! Have a nice day!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Out.WriteLine("Please enter a number between 1 and 6.");
                            break;
                    }
                } while (choice != 6);


            }

        public static int menu()
        {
            Console.Out.WriteLine("Enter the number of your choice:");
            Console.Out.WriteLine("1. Add a Computer");
            Console.Out.WriteLine("2. Specify Prototype Computer");
            Console.Out.WriteLine("3. Find Computer Summary by Array Index");
            Console.Out.WriteLine("4. View Summary of all Computers");
            Console.Out.WriteLine("5. View Summary of Specific Computers");
            Console.Out.WriteLine("6. Exit Application");

            return int.Parse(Console.ReadLine());
        }

        public static Computer addComputer()
        {
            bool ca = false;
            Console.Out.WriteLine("Does your computer have a cellular antenna?");
            if (Console.ReadKey().Equals('y') || Console.ReadKey().Equals('Y'))
            {
                ca = true;
            }

            Double hds;
            Console.Out.WriteLine("How much hard drive storage does your computer have?");
            hds = double.Parse(Console.ReadLine());

            int?[] licenses;
            Console.Out.WriteLine("How many pieces of software are on your computer?");
            int numSoftware = int.Parse(Console.ReadLine());
            if (numSoftware == 0)
            {
                licenses = null;
            }
            else
            {
                licenses = new int?[5];
                for (int i = 0; i < numSoftware; i++)
                {
                    Console.Out.WriteLine("How many licenses do you have for software number {0}?", i);
                    licenses[i] = int.Parse(Console.ReadLine());
                }
            }

            int ram;
            Console.Out.WriteLine("How much ram does your computer have?");
            ram = int.Parse(Console.ReadLine());

            Computer newComputer = new Computer(ca, hds, licenses, ram);
            return newComputer;
        }

        public static double averageRam(Computer[] computers, int start, int stop, bool entireArray, Computer userPrototype, Computer defaultPrototype)
        {
            int totalRam = 0;
            int numComputers = 0;
            Computer theComputer = null;

            for (int i = start; i <= stop; i++)
            {
                theComputer = (computers[i] ?? userPrototype ?? defaultPrototype);

                if (entireArray)
                {
                    totalRam += (computers[i]?.Ram ?? 0);
                    numComputers += (computers[i] != null ? 1 : 0);
                }
                else
                {
                    theComputer = (computers[i] ?? userPrototype ?? defaultPrototype);

                    totalRam += theComputer.Ram;
                    numComputers++;



                }//end else
            }//end for
            try
            {
                if (numComputers != 0)
                {
                    return totalRam / numComputers;
                }
                else
                {
                    return 0;
                }
            }
            catch (DivideByZeroException dbze) {
                throw dbze;
            }
            
        }//end method

        public static double percentCellularAntenna(Computer[] computers, int start, int stop, bool entireArray, Computer userPrototype, Computer defaultPrototype)
        {
            int cellularAntenna = 0;
            int numComputers = 0;
            Computer theComputer = null;

            for (int i = start; i <= stop; i++)
            {
                theComputer = (computers[i] ?? userPrototype ?? defaultPrototype);
                if (entireArray)
                {
                    if (computers[i]?.Antenna ?? false)
                    {
                        cellularAntenna++;
                        numComputers++;
                    }
                    // numComputers++;

                }
                else //not entire array
                {
                    // if (!entireArray)
                    // {
                    //     if (userPrototype != null)
                    //     {
                    //             if (userPrototype.Antenna != null)
                    //             {
                    //                 if ((bool)userPrototype.Antenna)
                    //                 {
                    //                     cellularAntenna++;
                    //                 }
                    //                 numComputers++;
                    //             }
                    //     }
                    if (theComputer?.Antenna ?? false)
                    {
                        cellularAntenna++;
                        numComputers++;
                    }
                    //else
                    //    {
                    //            if (defaultPrototype.Antenna != null)
                    //            {
                    //                if ((bool)defaultPrototype.Antenna)
                    //                {
                    //                    cellularAntenna++;
                    //                }
                    //                numComputers++;
                    //            }
                    //    }//end else
                    //}//end if
                }//end else
            }//end for
            if (numComputers != 0)
            {

                return cellularAntenna * 100 / numComputers;
            }
            else
            {
                return 0;
            }
        }//end method

        public static double avgHDCapacity(Computer[] computers, int start, int stop, bool entireArray, Computer userPrototype, Computer defaultPrototype)
        {
            double totalHDCapacity = 0;
            int numComputers = 0;
            Computer theComputer = null;

            for (int i = start; i <= stop; i++)
            {
                if (entireArray)
                {
                    totalHDCapacity += (computers[i]?.HardDrive ?? 0.0);
                    numComputers += (computers[i] != null ? 1 : 0);
                }
                else //not entire array
                {
                    theComputer = (computers[i] ?? userPrototype ?? defaultPrototype);
                    totalHDCapacity += theComputer?.HardDrive ?? 0.0;
                    numComputers += theComputer != null ? 1 : 0;
                }//end else
            }//end for

            return totalHDCapacity / numComputers;
        }//end method

        public static int avgLicenses(Computer[] computers, int start, int stop, bool entireArray, Computer userPrototype, Computer defaultPrototype)
        {
            int numLicenses = 0;
            int numComputers = 0;
            Computer theComputer = null;

            for (int i = start; i <= stop; i++)
            {
                if (entireArray)
                {
                    
                        for (int j = 0; j < computers?[i].Licenses?.Length; j++)
                        {
                            numLicenses += computers[i]?.Licenses?[j] ?? 0;
                            numComputers += computers[i] != null ? 1 : 0;
                        }
                    
                }

                else //specific indexes
                {
                    theComputer = computers[i] ?? userPrototype ?? defaultPrototype;
                    for (int j = 0; j < theComputer.Licenses?.Length; j++)
                    {
                        numLicenses += theComputer?.Licenses?[j] ?? 0;
                        numComputers += theComputer != null ? 1 : 0;
                    }
                }
            }
            return numLicenses / numComputers;
        }

        //next - average num of licenses for each program on each machine that has that program
        //loop through computers
        //have an array of average licenses which has a length of 5
        //for each computer, add their licenses for licenses[i] to an array - totals[i]
        //for each license on each computer, if it's not null software[i]++ (this array stores how many computers have this software)
        //return avgs[] which is for each i, totals[i]/software[i]
        public static int[] avgLicensesPerProgram(Computer[] computers, int start, int stop, bool entireArray, Computer userPrototype, Computer defaultPrototype)
        {
            int[] avgLicenses = new int[5];
            int[] totals = new int[5];
            int[] software = new int[5];
            Computer theComputer = null;

            for (int i = start; i <= stop; i++)
            {
                if (entireArray)
                {
                    for (int j = 0; j < computers[i].Licenses?.Length; j++)
                    {
                        totals[j] += computers[i]?.Licenses?[j] ?? 0;
                        software[j] += computers[i]?.Licenses?[j] != null ? 1 : 0;
                    }
                }

                else //specific indices
                {
                    theComputer = computers[i] ?? userPrototype ?? defaultPrototype;
                    for (int j = 0; j < theComputer.Licenses?.Length; j++)
                    {
                        totals[j] += theComputer?.Licenses?[j] ?? 0;
                        software[j] += theComputer?.Licenses?[j] != null ? 1 : 0;
                    }


                }//end else
            }//end for

            for (int i = 0; i < avgLicenses.Length; i++)
            {
                avgLicenses[i] = totals[i] / software[i];
            }

            return avgLicenses;
        }//end method
    
    }
}
