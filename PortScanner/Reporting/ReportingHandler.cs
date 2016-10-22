using System.Windows.Forms;

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
    }
}
