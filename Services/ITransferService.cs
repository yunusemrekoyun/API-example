using System;
using System.Threading.Tasks;
using TransferApi.Models;

namespace TransferApi.Services
{
    public interface ITransferService
    {
        Task<TransferResult> TransferAsync(TransferRequest request);
    }

}

