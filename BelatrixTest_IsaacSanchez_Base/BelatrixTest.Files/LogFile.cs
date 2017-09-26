using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace BelatrixTest.Files
{
    /// <summary>
    /// ===============================================================================================================================================
    /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
    /// File: LogFile.cs
    /// Date Created: 25/09/17
    /// Date Modified: 
    /// Description: Class used to save error log manually, it is an old-habit for audit programming. The newest .NET tools like NLog could replace it.
    /// ===============================================================================================================================================
    /// </summary>
    public sealed class LogFile {
 
    public static void SaveErrorLog(string metodoError, Exception excepcion){
        bool SiUsaLogError =   Convert.ToBoolean(ConfigurationManager.AppSettings["UsaLogError"]);

        if (SiUsaLogError)
        {
            string strRutaLog = ConfigurationManager.AppSettings["RutaLogError"];                      
            string archivoLog = strRutaLog + DateTime.Today.ToString("ddMMyyyy") + ".log";
            FileStream archivoFileStream = null;

            if (File.Exists(archivoLog) == false)
            {
                archivoFileStream = File.Open(archivoLog, FileMode.Create, FileAccess.Write);
            }
            else
            {
                archivoFileStream = File.Open(archivoLog, FileMode.Append, FileAccess.Write);
            }

            StreamWriter escritorStream = new StreamWriter(archivoFileStream);
            escritorStream.WriteLine(DateTime.Now.ToLongTimeString() + " - " + metodoError + " - " + excepcion.Message + " - " + excepcion.StackTrace);
            escritorStream.Close();

            archivoFileStream.Close();

        }
    }
    }
  }
