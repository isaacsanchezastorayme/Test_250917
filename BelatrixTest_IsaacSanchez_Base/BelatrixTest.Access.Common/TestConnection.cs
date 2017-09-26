using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace BelatrixTest.Access.Common
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: TestConnection.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class used to control functions to test database connections.
    /// =============================================================================================================================
    /// </summary>
    public class TestConnection: Access.Core.DbHelper
    {

        #region Constructor
        public TestConnection()
            : this(null)
        {
        }

        // Call the base constructor
        public TestConnection(DbConnection connection)
            : base(connection)
        {
        }      
        #endregion

        #region Destructor
            ~TestConnection()
            {
            }
        #endregion

        #region Functions
        public DataTable GetModules(short codModulo)
            {
                DbParameter[] parameters = new DbParameter[1];
                parameters[0] = CreaNuevoParametro("codModulo", DbType.Int32, 1, codModulo);
                return ObtenerDatatable("uspObtenerModulos", parameters, "MODULOS");
            }
        #endregion
                     
    }
}
