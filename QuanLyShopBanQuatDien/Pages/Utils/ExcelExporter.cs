using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.Hosting;
using System.IO;
using QuanLyShopBanQuatDien.DTO;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    public class ExcelExporter
    {
        private static string FOLDER_PATH = HostingEnvironment.MapPath("~/Resources/Reports/");
        private static string REVENUE_BY_CUSTOMER_REPORT_PATH = Path.Combine(FOLDER_PATH, "revenue_by_customer_report.xlsx");
        private static string REVENUE_BY_PRODUCT_REPORT_PATH = Path.Combine(FOLDER_PATH, "revenue_by_product_report.xlsx");

        private static void send(HttpResponse response, string tempFilePath)
        {
            response.Clear();
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment; filename=yourfile.xlsx");
            response.WriteFile(tempFilePath);

            response.End();
        }

        public static void export(HttpResponse response, DateTime startDate, DateTime endDate, List<RevenueByCustomerDTO> revenueList)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(REVENUE_BY_CUSTOMER_REPORT_PATH);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            string createdAt = worksheet.Cells[1, 1].Value;
            string fromToTo = worksheet.Cells[3, 1].Value;
            string count = worksheet.Cells[6, 1].Value;

            createdAt = createdAt.Replace("@datetime", TypeConverter.dateToStr(DateTime.Now, TypeConverter.DateTimeConfig.DATE_TIME_PATTERN));
            worksheet.Cells[1, 1].Value = createdAt;

            fromToTo = fromToTo.Replace("@startDate", TypeConverter.dateToStr(startDate, TypeConverter.DateTimeConfig.DATE_PATTERN));
            fromToTo = fromToTo.Replace("@endDate", TypeConverter.dateToStr(endDate, TypeConverter.DateTimeConfig.DATE_PATTERN));
            worksheet.Cells[3, 1].Value = fromToTo;

            count = count.Replace("@count", revenueList.Count.ToString());
            worksheet.Cells[6, 1].Value = count;

            Int64 amountTotal = 0;
            int pos = 7;
            foreach (RevenueByCustomerDTO revenue in revenueList)
            {
                worksheet.Cells[pos, 1].Value = revenue.code;
                worksheet.Cells[pos, 2].Value = revenue.name;

                Excel.Range mergeRange = worksheet.Range[worksheet.Cells[pos, 3], worksheet.Cells[pos, 5]];
                mergeRange.Merge();

                worksheet.Cells[pos, 3].Value = revenue.totalAmount;
                amountTotal += revenue.totalAmount;
                pos++;
            }

            worksheet.Cells[6, 3].Value = amountTotal.ToString();

            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");
            workbook.SaveAs(tempFilePath);

            workbook.Close(false);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            send(response, tempFilePath);

            File.Delete(tempFilePath);
        }

        public static void export(HttpResponse response, DateTime startDate, DateTime endDate, List<RevenueByProductDTO> revenueList)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(REVENUE_BY_PRODUCT_REPORT_PATH);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            string createdAt = worksheet.Cells[1, 1].Value;
            string fromToTo = worksheet.Cells[3, 1].Value;
            string count = worksheet.Cells[6, 1].Value;

            createdAt = createdAt.Replace("@datetime", TypeConverter.dateToStr(DateTime.Now, TypeConverter.DateTimeConfig.DATE_TIME_PATTERN));
            worksheet.Cells[1, 1].Value = createdAt;

            fromToTo = fromToTo.Replace("@startDate", TypeConverter.dateToStr(startDate, TypeConverter.DateTimeConfig.DATE_PATTERN));
            fromToTo = fromToTo.Replace("@endDate", TypeConverter.dateToStr(endDate, TypeConverter.DateTimeConfig.DATE_PATTERN));
            worksheet.Cells[3, 1].Value = fromToTo;

            count = count.Replace("@count", revenueList.Count.ToString());
            worksheet.Cells[6, 1].Value = count;

            Int64 amountTotal = 0;
            int pos = 7;

            foreach (RevenueByProductDTO revenue in revenueList)
            {
                worksheet.Cells[pos, 1].Value = revenue.code;
                worksheet.Cells[pos, 2].Value = revenue.name;
                worksheet.Cells[pos, 3].Value = revenue.quantity;

                Excel.Range mergeRange = worksheet.Range[worksheet.Cells[pos, 4], worksheet.Cells[pos, 6]];
                mergeRange.Merge();

                worksheet.Cells[pos, 4].Value = revenue.totalAmount;
                amountTotal += revenue.totalAmount;
                pos++;
            }

            worksheet.Cells[6, 3].Value = amountTotal.ToString();

            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");
            workbook.SaveAs(tempFilePath);

            workbook.Close(false);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            send(response, tempFilePath);

            File.Delete(tempFilePath);
        }
        
    }
}