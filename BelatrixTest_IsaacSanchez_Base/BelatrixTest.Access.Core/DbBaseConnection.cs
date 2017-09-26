using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BelatrixTest.Files;
using System.Data.Common;
using System.Data;

namespace BelatrixTest.Access.Core
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: DbBaseConnection.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class used to manage the database connections.
    /// =============================================================================================================================
    /// </summary>
    public sealed class DbBaseConnection
    {

        private static DbConnection dbConn = null; 

        private static DbConnection connectionDB = null;
        public static DbConnection GetConnection()
        {
            ConnectionStringSettings Settings = ConfigurationManager.ConnectionStrings["BelatrixTest.IsaacSanchez"];
            DbProviderFactory providerFactoryDB = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BelatrixTest.IsaacSanchez"].ProviderName);
                     
            string connectionString = string.Empty;  
            
            connectionString = DbConnectionString.ConnectionString;
            connectionString = Settings.ConnectionString;

                 try {
                    connectionDB = providerFactoryDB.CreateConnection();
                    connectionDB.ConnectionString = connectionString;
                    connectionDB.Open();                    
                }
                catch(Exception e) {
                    LogFile.SaveErrorLog("DbBaseConnection.GetConnection", e);                    
                }

                 return connectionDB;
        }

        public static void CloseConnection(ref  DbConnection _connection)
        {
        if (_connection != null){
            if (_connection.State == ConnectionState.Open){
                _connection.Close();
                _connection = null;
            }
        }

        } 

    }
}
