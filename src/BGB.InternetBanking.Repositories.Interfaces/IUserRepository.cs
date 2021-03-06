﻿using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByAccount(int accountNumber, int accountDigit);

    }
}