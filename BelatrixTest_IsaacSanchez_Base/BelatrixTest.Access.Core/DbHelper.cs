using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using BelatrixTest.Files;

namespace BelatrixTest.Access.Core
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: DbHelper.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: This Helper class must help the instances for database methods.
    /// =============================================================================================================================
    /// </summary> 
    public class DbHelper
    {       
        private ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["BelatrixTest.IsaacSanchez"];
        private DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["BelatrixTest.IsaacSanchez"].ProviderName);
        private string _proper = ConfigurationManager.AppSettings["Propietario"];
        private DbConnection _connection;
        private Exception _exception = null;
        private bool _addEmptyRow = false;
        
        #region Constructor
        public DbHelper() {} 
        
        public DbHelper(DbConnection connec)
        {
            _connection = connec;
        }            
        #endregion

        #region Properties
        public DbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
 
        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }

        public bool AddEmptyRow
        {
            get { return _addEmptyRow; }
            set { _addEmptyRow = value; }
        }

        public string Proper
        {
            get { return _proper; }
            set { _proper = value; }
        }
        #endregion

        #region Protected methods        
        protected DbParameter CreaNuevoParametro(string nombreParametro, DbType tipoDeDatoDB, short longitud, object valor){
        return GetNewParameter(nombreParametro,tipoDeDatoDB, longitud, valor);
        }

        protected virtual void CreaNuevoParametro()
        {
            
        }

        static void ReadAllSettings() {
            var appSettings = ConfigurationManager.AppSettings;
        }
        #endregion

        #region Private methods
        protected DataTable ObtenerDatatable(string nombreProcedimiento, DbParameter[] parametros, string nombreTabla){
         DbCommand commandDB = providerFactory.CreateCommand(); 
            commandDB.CommandType = CommandType.StoredProcedure;        
            commandDB.CommandTimeout = 0;
            commandDB.CommandText = _proper + nombreProcedimiento;
            commandDB.Parameters.AddRange(parametros);

            DataTable dt = new DataTable(nombreTabla);
            DbDataAdapter dap = providerFactory.CreateDataAdapter();
            dap.SelectCommand = commandDB;
            dap.SelectCommand.Connection = _connection;                
            try
                {                                         
                    dap.Fill(dt);
                }
            catch (Exception e)
            {
                LogFile.SaveErrorLog("DbHelper.ObtenerDataTable", e);            
            }

            /*    If _AgregarFilaVacia Then
                If Not dt Is Nothing Then
                    If dt.Rows.Count = 0 Then
                        Dim drFila As DataRow = dt.NewRow()
                        dt.Rows.Add(drFila)
                    End If
                End If
            End If*/

            return dt;
        }

        private DbParameter GetNewParameter(string nombreParametro, DbType tipoDatoDB, short longitud, object valor) {
            DbParameter nuevoParametro = providerFactory.CreateParameter();
            nuevoParametro.ParameterName = nombreParametro;
            nuevoParametro.DbType = tipoDatoDB;

            if (longitud > 0) { nuevoParametro.Size = longitud; }
            nuevoParametro.Value = DBNull.Value;
            if (valor != null) { nuevoParametro.Value = valor; }

            return nuevoParametro;
        }

        #endregion
    }
}
