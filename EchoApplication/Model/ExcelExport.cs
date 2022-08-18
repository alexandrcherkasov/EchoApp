using IronXL;
using IronXL.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoApplication.Model
{
    public static class ExcelExport
    {
        static WorkBook xlsxWorkbook;
        static WorkSheet xlsSheet;


        public static void ExportSelectedBoreHole(BoreHoleData SelectedBoreHoleData)
        {
            xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsSheet = xlsxWorkbook.CreateWorkSheet("EchoData");
            CreateHeader(SelectedBoreHoleData);
            SaveDoc();
        }

        public static void ExportSelectedProject(Project SelectedProject)
        {
            xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsSheet = xlsxWorkbook.CreateWorkSheet("EchoData");
            int i = 1;
            foreach(var BoreHoleItem in SelectedProject.BoreHoleCollection)
            {
                HeaderStyle("B" + i, BoreHoleItem.BoreHoleName.Replace('/', '_'), 4000);
                xlsSheet.Merge("B" + i + ":" + "E" + i);
                HeaderStyle("B" + (i + 1), "Время замера", 4000);
                HeaderStyle("C" + (i + 1), "Время отклика", 4000);
                HeaderStyle("D" + (i + 1), "Скорость звука", 4000);
                HeaderStyle("E" + (i + 1), "Дистанция", 4000);
                i++;
                foreach (var BoreHoleData in BoreHoleItem.ProjectDataCollection)
                {
                    i++;
                    CreateValue("B" + i, BoreHoleData.MeasureTime);
                    CreateValue("C" + i, BoreHoleData.ResponseTime);
                    CreateValue("D" + i, BoreHoleData.SpeedOfSound);
                    CreateValue("E" + i, BoreHoleData.Distance);
                }
                i++;
            }
            SaveDoc();
        }

        private static void CreateHeader(BoreHoleData SelectedBoreHoleData)
        {
            HeaderStyle("B1", SelectedBoreHoleData.BoreHoleName.Replace('/','_'), 4000);
            xlsSheet.Merge("B1:E1");
            HeaderStyle("B2", "Время замера", 4000);
            HeaderStyle("C2", "Время отклика", 4000);
            HeaderStyle("D2", "Скорость звука", 4000);
            HeaderStyle("E2", "Дистанция", 4000);
        }

        private static void HeaderStyle(string ArrayIndex, string Text, int CellWidth)
        {
            xlsSheet[ArrayIndex].Value = Text;
            xlsSheet[ArrayIndex].Columns[0].Width = CellWidth;
            xlsSheet[ArrayIndex].Rows[0].Height = 800;
            xlsSheet[ArrayIndex].Style.Font.Bold = true;
            xlsSheet[ArrayIndex].Style.WrapText = true;
            CreateBorder(ArrayIndex);
            AligmentTextToCenter(ArrayIndex);
        }

        private static void CreateBorder(string ArrayIndex)
        {
            xlsSheet[ArrayIndex].Style.LeftBorder.Type = IronXL.Styles.BorderType.Thin;
            xlsSheet[ArrayIndex].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;
            xlsSheet[ArrayIndex].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;
            xlsSheet[ArrayIndex].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;
        }
        private static void AligmentTextToCenter(string ArrayIndex)
        {
            xlsSheet[ArrayIndex].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            xlsSheet[ArrayIndex].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
        }

        private static void CreateValue(string ArrayIndex, object Text)
        {
            xlsSheet[ArrayIndex].Value = Text;
            xlsSheet[ArrayIndex].Style.WrapText = true;
            CreateBorder(ArrayIndex);
            AligmentTextToCenter(ArrayIndex);
        }

        private static bool SaveDoc()
        {
            try
            {
                xlsxWorkbook.SaveAs("NewExcelFile.xlsx");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
