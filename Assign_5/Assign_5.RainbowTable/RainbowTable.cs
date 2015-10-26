//-----------------------------------------------------------------------
// <copyright file="RainbowTable.cs" company="LakeheadU">
//     Copyright ENGI-3675. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Assign_5.RainbowTable
{
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Implements Lookup table through its "Lookup" method. Also has method "byteToString" to convert 
    /// a byte array to a string of hex digits.
    /// </summary>
    public class RainbowTable
    {
        /// <summary>
        /// Takes a username and hashed password, and compares to rainbow table of hashed values
        /// Returns matched string, if found. If not, throws Application Exception.
        /// </summary>
        /// <param name="username"> The username of the user we are trying to hack</param>
        /// <param name="md5_pass"> The hashed password of the user</param>
        /// <returns> string of matched password</returns>
        public string Lookup(string username, string md5_pass)
        {
            string[] tableEntries = File.ReadAllLines("./TableTextFile/RainbowTable2.txt");
            using (MD5 encoder = MD5.Create())
            {
                foreach (string entry in tableEntries)
                {
                    byte[] encoded;
                    encoded = encoder.ComputeHash(Encoding.UTF8.GetBytes(entry));
                    if (byteToString(encoded) == md5_pass)
                    {
                        return entry;
                    }
                }
            }
            return "Password Not Found";
        }

        /// <summary>
        /// Used to convert byte array encoded MD5 hash into a string of hex numbers
        /// </summary>
        /// <param name="input"> byte array created by MD5 hash</param>
        /// <returns> string of hex numbers representing MD5 hash</returns>
        public string byteToString(byte[] input)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sBuilder.Append(input[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
