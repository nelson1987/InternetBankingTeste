﻿using BGB.Core.Validations.Interfaces;

namespace BGB.InternetBanking.Models.Specifications.UserSpecs
{
    public class UserEmailIsRequiredSpec : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return user.Email.Trim().Length > 0;
        }
    }
}