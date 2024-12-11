using System;
using EmployeeAdminPortal.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace EmployeeAdminPortal.Repository
{
    public class RepositoryImpl : EmpRepo
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor for injecting the database context
        public RepositoryImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



       // public async Task<byte[]> ExportEmployeesToExcelAsync()
       //     //var employees = await _dbContext.Employees
                                     //.Include(e => e.Department)
                                     //.Select(e => new
                                     //{
                                     //    e.Id,
                                     //    e.Name,
                                     //    e.Email,
                                     //    e.Phone,
                                     //    DepartmentPosition = e.Department!.Position,
                                     //    DepartmentCode = e.Department.Code
                                     //})
                                     //.ToListAsync();


            //using (var package = new ExcelPackage())
            //{
            //    var worksheet = package.Workbook.Worksheets.Add("Employees");

            //    // Add header row
            //    worksheet.Cells[1, 1].Value = "SNo.";
            //    worksheet.Cells[1, 2].Value = "Name";
            //    worksheet.Cells[1, 3].Value = "Email";
            //    worksheet.Cells[1, 4].Value = "Phone";
            //    worksheet.Cells[1, 6].Value = "Position";
            //    worksheet.Cells[1, 5].Value = "Code";




                // Add data rows
                //int row = 2;
                //int SNo = 1;
                //foreach (var employee in employees)
                //{
                //    //worksheet.Cells[row, 1].Value = employee.Id;
                //    worksheet.Cells[row, 2].Value = employee.Name;
                //    worksheet.Cells[row, 3].Value = employee.Email;
                //    worksheet.Cells[row, 4].Value = employee.Phone;
                //    worksheet.Cells[row, 5].Value = employee.DepartmentCode;
                //    worksheet.Cells[row, 6].Value = employee.DepartmentPosition;

            //        worksheet.Cells[row, 1].Value = SNo++;

            //        row++;
            //    }

            //    // Auto-fit columns for better readability
            //    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            //    // Return the Excel file as a byte array
            //    return package.GetAsByteArray();
            //}
       }
    }
