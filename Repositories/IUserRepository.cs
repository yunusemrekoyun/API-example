using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferApi.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace TransferApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task UpdateUserAsync(User user);

    }
}

