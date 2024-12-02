using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.IRepo;
using EmployeeAdminPortal.Moddels.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EmployeeAdminPortal.Repository
{
    public class DispatchRepoImpl : IDispatchRepo   
    {
        private readonly ApplicationDbContext _dbContext;

        public DispatchRepoImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dispatch> AddDispatchAsync(Dispatch dispatch)
        {
            _dbContext.Dispatchs.Add(dispatch);
            await _dbContext.SaveChangesAsync();
            return dispatch;
        }

        public async Task<byte[]> ExportDispatchToExcel()
        {
            var employees = await _dbContext.Dispatchs.ToListAsync();



            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Dispatchs");


                worksheet.Cells[1, 1].Value = "Dispatch Detail(Date:- 02-12-2024)";

                using (var range = worksheet.Cells[1, 1, 3, 12])
                {
                    range.Merge = true;
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 14;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; 
                    // Horizontal Alignment ke lie use kiya hai
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center; 
                    // center align kiya hia vertically ke liye
                }

                // Add header 
                worksheet.Cells[4, 1].Value = "Serial No";
                worksheet.Cells[4, 2].Value = "Company";
                worksheet.Cells[4, 3].Value = "Branch";
                worksheet.Cells[4, 4].Value = "Fedration";
                worksheet.Cells[4, 5].Value = "FPC";
                worksheet.Cells[4, 6].Value = "DispatchDate";
                worksheet.Cells[4, 7].Value = "DispatchStatus";
                worksheet.Cells[4, 8].Value = "TruckNumber";
                worksheet.Cells[4, 9].Value = "BagCount";
                worksheet.Cells[4, 10].Value = "DriverName";
                worksheet.Cells[4, 11].Value = "DriverNumber";
                worksheet.Cells[4, 12].Value = "NetWeight";


                // Add data rows
                int row = 5;
                int SerialNo = 1;
                decimal totalNetWeight = 0;


                foreach (var employee in employees)
                {
                    worksheet.Cells[row, 1].Value = SerialNo++; // Serial Number
                    worksheet.Cells[row, 2].Value = employee.Company;
                    worksheet.Cells[row, 3].Value = employee.Branch;
                    worksheet.Cells[row, 4].Value = employee.Fedration;
                    worksheet.Cells[row, 5].Value = employee.FPC;
                    worksheet.Cells[row, 6].Value = employee.DispatchDate;
                    worksheet.Cells[row, 7].Value = employee.DispatchStatus;
                    worksheet.Cells[row, 8].Value = employee.TruckNumber;
                    worksheet.Cells[row, 9].Value = employee.BagCount;
                    worksheet.Cells[row, 10].Value = employee.DriverName;
                    worksheet.Cells[row, 11].Value = employee.DriverNumber;
                    worksheet.Cells[row, 12].Value = employee.NetWeight;


                    totalNetWeight += employee.NetWeight;

                    row++;
                }

                int totalRow = row;
                worksheet.Cells[totalRow, 1].Value = "Total NetWeight:";

                using (var totalRange = worksheet.Cells[totalRow, 1, totalRow, 11])
                {
                    totalRange.Merge = true;
                    totalRange.Style.Font.Bold = true;
                    totalRange.Style.Font.Size = 14;
                    totalRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    totalRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                
                worksheet.Cells[totalRow, 12].Value = totalNetWeight;

                using (var valueCell = worksheet.Cells[totalRow, 12])
                {
                    valueCell.Style.Font.Bold = true;
                    valueCell.Style.Font.Size = 14;
                    valueCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right; 
                    valueCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }




                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }

        }


    }
}
