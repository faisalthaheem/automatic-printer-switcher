using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PrinterSwitcher
{
    class PSDB
    {
        public string mAppDataDir = string.Empty;
        public string mMapFilePath = string.Empty;

        public PSDB()
        {
            mAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\APS";
            mMapFilePath = mAppDataDir + @"\processPrinterMap.dat";
        }

        public bool saveProcesses(PSProcessCollection collection)
        {
            bool bRet = true;

            //ensure the directory exists

            try
            {
                if (!Directory.Exists(mAppDataDir))
                {
                    Directory.CreateDirectory(mAppDataDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error saving mapping to disk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                formatter.Serialize(ms, collection);
                File.WriteAllBytes(mMapFilePath, ms.GetBuffer());
               
            }
            catch (Exception ex)
            {
                bRet = false;
            }

            return bRet;
        }

        public PSProcessCollection loadProcesses()
        {
            PSProcessCollection ret = null;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(mMapFilePath));
                ret = (PSProcessCollection)formatter.Deserialize(ms);

            }
            catch (Exception ex)
            {
                ret = null;
            }

            return ret;
        }

    }
}
