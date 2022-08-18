using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoApplication.Model
{
    class ExcelParser
    {
        private readonly WorkBook workbook;
        private readonly WorkSheet sheet;
        public ExcelParser(string FilePath)
        {
            workbook = WorkBook.Load(FilePath);
            sheet = workbook.WorkSheets.First();
        }

        public List<ProjectData> GetDataFromExcelFile()
        {
            List<ProjectData> ProjectDataList = new List<ProjectData>();
            string RowNumber = "A";
            string RowDateTime = "P";
            string RowBoreHole = "Q";
            string RowResponseTime = "AO";


            for (int i = 3; i < sheet.RowCount - 3; i++)
            {
                try
                {
                    IronXL.Range temp1 = sheet[RowNumber + i];
                    IronXL.Range temp2 = sheet[RowDateTime + i];
                    IronXL.Range temp3 = sheet[RowBoreHole + i];
                    IronXL.Range temp4 = sheet[RowResponseTime + i];

                    ProjectDataList.Add(new ProjectData (sheet[RowNumber + i].Int32Value, sheet[RowDateTime + i].DateTimeValue.Value, sheet[RowBoreHole + i].StringValue, sheet[RowResponseTime + i].StringValue));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
               
            }

            return ProjectDataList;
        }
    }
}
