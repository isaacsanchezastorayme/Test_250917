using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business = BelatrixTest.Business;
using NL = NLog;
using LT = log4net;
using System.Security.Principal;

namespace BelatrixTest.UI
{
    /// <summary>
    /// ===============================================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: LoggerFrm.aspx.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class to support the user interface web form.
    /// ===============================================================================================================================================
    /// </summary>
    public partial class LoggerFrm : System.Web.UI.Page
    {
        private static readonly LT.ILog Logger4Net = LT.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            StartOfDay();
        }
        
        private void StartOfDay() {
            int numberOfModules = 0;

            try
            {
                using (business.BusinessRulesOne obj = new business.BusinessRulesOne())
                {
                    numberOfModules = obj.ListModules(1).Rows.Count;
                }

                if (numberOfModules > 0) { txtConexion.Text = "Conexión exitosa"; }
            }
            catch (Exception ex) { 
            //Logger can be added also here.
            }
        }

        protected void btnLoggerFileInDisk_Click(object sender, EventArgs e)
        {
            int zero = 0;
            string errorMessage = string.Empty;
            int result = 0;
            try
            {                
                errorMessage = txtLoggerFileInDisk.Text;
                result = 5 / zero;                
            }
            catch (DivideByZeroException ex) { 
                //Using Logger to write a file in disk:
                NL.Logger logger = NL.LogManager.GetCurrentClassLogger();
                logger.ErrorException(errorMessage, ex);
                txtLoggerFileInDisk.Text = "¡Log escrito OK en archivo de disco!";
            }

        }

        protected void btnLoggerDB_Click(object sender, EventArgs e)
        {
            int zero = 0;
            string errorMessage = string.Empty;
            int result = 0;
            try
            {
                errorMessage = txtLoggerDBMessage.Text;
                result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {
                //Using Logger to write add a row into a database table:
                NL.Logger logger = NL.LogManager.GetLogger("databaseLogger");
                logger.ErrorException(errorMessage, ex);
                txtLoggerDBMessage.Text = "¡Log escrito OK en Base de Datos!";
            }
        }
     
        protected void btnLoggerConsole_Click(object sender, EventArgs e)
        {            
            int zero = 0;
            string errorMessage = string.Empty;
            int result = 0;
            try
            {
                errorMessage = txtLoggerConsoleMessage.Text;
                result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {                
                Logger4Net.InfoFormat("Running as {0}", WindowsIdentity.GetCurrent().Name);
                Logger4Net.Error("This will appear in red in the console and still be written to file!");
                txtLoggerConsoleMessage.Text = "¡Log escrito OK en Consola!";
            }
        }

    }
}