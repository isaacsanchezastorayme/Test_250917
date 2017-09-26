using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA = BelatrixTest.Access.Common;
using System.Data.Common;
using System.Data;

namespace BelatrixTest.Business
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: BusinessRulesOne.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class used to manage logic business rules.
    /// =============================================================================================================================
    /// </summary>
    public class BusinessRulesOne: BelatrixTest.Access.Core.DbInstance
    {        
        public DataTable ListModules(short codModulo)
        {                      
          DA.TestConnection obj = new DA.TestConnection(Connection);
          try {         
            return obj.GetModules(codModulo);
          }
          finally {
            // To dispose obj object if needed
          }

        }

    } 
    
}


