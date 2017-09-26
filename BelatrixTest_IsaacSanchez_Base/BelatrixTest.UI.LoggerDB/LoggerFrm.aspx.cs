using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business = BelatrixTest.Business;
using NLog;

namespace BelatrixTest.UI
{
    public partial class LoggerFrm : System.Web.UI.Page
    {
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
                    numberOfModules = obj.ListarModulos(1).Rows.Count;
                }

                if (numberOfModules > 0) { txtConexion.Text = "Conexión exitosa"; }
            }
            catch (Exception ex) { 
            //Usando Logger ...

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
                //Usando Logger hacia archivo en disco:
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException(errorMessage, ex);
                txtLoggerFileInDisk.Text = "Se escribió el log. ¡OK!";
            }

        }

    }
}