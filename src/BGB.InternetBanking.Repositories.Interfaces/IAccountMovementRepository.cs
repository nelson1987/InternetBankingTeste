﻿using System;
using System.Collections.Generic;
using BGB.Core.Repository.Interfaces;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Repositories.Interfaces
{
    public interface IAccountMovementRepository : IRepository<CheckingAccountMovement>
    {
        IEnumerable<CheckingAccountMovement> GetByPeriod(int accountNumber, DateTime startDate, DateTime endDate);
        IEnumerable<CheckingAccountMovement> GetLast(int accountNumber, int quantity);
    }
}