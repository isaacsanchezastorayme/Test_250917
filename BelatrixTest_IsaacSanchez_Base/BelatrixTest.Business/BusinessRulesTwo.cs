using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixTest.Business
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: BusinessRulesTwo.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class used to manage logic business rules.
    /// =============================================================================================================================
    /// </summary>
    public class BusinessRulesTwo
    {
        public string combineArrayStringWithSpace(string[] stringArray)
        {
            string str = default(string);

            foreach (string item in stringArray)
            {
                str += item + " ";
            }
            return str.Trim();
        }
    }  
}
