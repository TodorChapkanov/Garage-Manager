using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GM.Services.Contracts
{
    public interface ICustomerServices
    {
        Task Create(string firstName, string lastName, string email, string phoneNumber);
    }
}
