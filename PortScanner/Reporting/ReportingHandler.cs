using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace PortScanner.Reporting
{
    public class ReportingHandler
    {
        public static int ReportType = 1;

        public void SetReportType(Enum.ReportType reportType)
        {
            ReportType = (int)reportType;
        }

        public SaveFileDialog GetSaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            switch (ReportType)
            {
                case 1:
                    //configure text
                    saveFileDialog.DefaultExt = ".txt";
                    saveFileDialog.Filter = "Text documents (.txt)|*.txt";
                    break;

                case 2:
                    //configure xls
                    saveFileDialog.DefaultExt = ".xls";
                    saveFileDialog.Filter = "Excel documents (.xls)|*.xls";
                    break;

                case 3:
                    //configure csv
                    saveFileDialog.DefaultExt = ".csv";
                    saveFileDialog.Filter = "CSV documents (.csv)|*.csv";
                    break;
            }
            return saveFileDialog;
        }



        public string BuildTextFile(TextBox mainWindowTextBox)
        {
            return mainWindowTextBox.Text;
        }

        public int GetReportType()
        {
            return ReportType;
        }

        public void BuildWorkBook(TextBox mainWindowTextBox)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Sheet 1 content";

            xlWorkBook.SaveAs("c:\\PortScanReport.xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\PortScanReport.xls");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
    
}