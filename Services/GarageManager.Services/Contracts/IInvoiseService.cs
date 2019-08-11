using GarageManager.Services.Models.Invoice;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<InvoiceDetails> GetInvoiceDetailsByCarIdAsync(string id);
    }
}
