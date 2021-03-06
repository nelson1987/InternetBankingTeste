﻿using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.WithdrawalSpecs
{
    public class WithdrawalFinalityIsRequiredSpec : ISpecification<WithdrawalCommunication>
    {
        public bool IsSatisfiedBy(WithdrawalCommunication withdrawal)
        {
            return !string.IsNullOrEmpty(withdrawal.Finality) && withdrawal.Finality.Trim().Length > 4;
        }
    }
}