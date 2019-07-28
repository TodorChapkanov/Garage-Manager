using GarageManager.Services.DTO.Invoice;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<InvoiceDetails> GetInvoiceDetailsByCarId(string id);
    }
}
