
using EmployeeAdminPortal.Models;

namespace EmployeeAdminPortal.IRepo
{
    public interface IDispatchRepo
    {
        Task<Dispatch> AddDispatchAsync(Dispatch dispatch);
        Task<byte[]> ExportDispatchToExcel();
    }
}
