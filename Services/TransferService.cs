using System.Threading.Tasks;
using TransferApi.Models;
using TransferApi.Repositories;
using TransferApi.Services;

public class TransferService : ITransferService
{

    private readonly IUserRepository _userRepository;


    public TransferService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<TransferResult> TransferAsync(TransferRequest request)
    {

        var sender = await _userRepository.GetUserByIdAsync(request.SenderId);
        var receiver = await _userRepository.GetUserByIdAsync(request.ReceiverId);


        if (sender == null || receiver == null)
        {
            return new TransferResult { Success = false, Message = "Gönderen veya alıcı bulunamadı." };
        }


        if (sender.Balance < request.Amount)
        {
            return new TransferResult { Success = false, Message = "Yetersiz bakiye." };
        }


        sender.Balance -= request.Amount;
        receiver.Balance += request.Amount;


        await _userRepository.UpdateUserAsync(sender);
        await _userRepository.UpdateUserAsync(receiver);


        return new TransferResult { Success = true, Message = "Para transferi başarılı." };
    }


}

