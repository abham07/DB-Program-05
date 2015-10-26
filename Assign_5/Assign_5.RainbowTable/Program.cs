//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="LakeheadU">
//     Copyright ENGI-3675. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Assign_5.RainbowTable
{
    using System;

    /// <summary>
    /// A simple driver class to implement the Rainbow Table class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method that takes input, executes all methods, and prints results to console.
        /// Loops until empty string is entered for username.
        /// </summary>
        static void Main()
        {
            string names = "";
            string passwds = "";
            RainbowTable tabler = new RainbowTable();
            string result = "";

            do
            {
                Console.Write("Username: ");
                names = Console.ReadLine();
                if (names == "") break;
                Console.Write("Password Hash: ");
                passwds = Console.ReadLine();
                result = tabler.Lookup(names, passwds);
                Console.WriteLine(names + "'s password is: " + result + "\n");
            } while (true);
        }
    }
}
