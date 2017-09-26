using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace BelatrixTest.Access.Core
{
    /// <summary>
    /// =============================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: DbInstance.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Disposable Instance Object.
    /// =============================================================================================================================
    /// </summary>
   public class DbInstance : IDisposable
    {
        private DbConnection _connection = null;

        public DbConnection Connection
        {
            get { return _connection; }          
        }

        public DbInstance()
        {
            _connection = DbBaseConnection.GetConnection();
        }
        public DbInstance(DbConnection connection)
        {
            _connection = connection;
        }

        #region IDisposisable Support
         private bool disposedValue = false;
              
         protected virtual void Dispose(bool disposing)
         {
             
             if (this.disposedValue == false) {
                 if (disposing) {                  
                  // TODO: dispose managed state (managed objects).
                 }
             }
             disposedValue = true;
             // Clear all property values that maybe have been set
             // when the class was instantiated             
         }

         public void Dispose()
         {
             DbBaseConnection.CloseConnection(ref _connection);
             Dispose(true);
             GC.SuppressFinalize(this);
         }
        #endregion

    }
}
