using BGB.InternetBanking.Repositories;
using BGB.InternetBanking.Repositories.Interfaces;
using BGB.InternetBanking.Services;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BGB.InternetBanking.Api
{
    public static class ConfigDependency
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountBalanceRepository, AccountBalanceRepository>();
            services.AddTransient<IAccountBalanceService, AccountBalanceService>();

            services.AddTransient<IAccountMovementRepository, AccountMovementRepository>();
            services.AddTransient<IAccountMovementService, AccountMovementService>();

            services.AddTransient<ICardMovementRepository, CardMovementRepository>();
            services.AddTransient<ICardMovementService, CardMovementService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<IDeedRepository, DeedRepository>();
            services.AddTransient<IDeedService, DeedService>();

            services.AddTransient<IGuaranteeRepository, GuaranteeRepository>();
            services.AddTransient<IGuaranteeService, GuaranteeService>();

            services.AddTransient<IHolidayRepository, HolidayRepository>();

            services.AddTransient<IIndexQuotationRepository, IndexQuotationRepository>();
            services.AddTransient<IIndexQuotationService, IndexQuotationService>();

            services.AddTransient<IInvestmentBalanceRepository, InvestmentBalanceRepository>();
            services.AddTransient<IInvestmentBalanceService, InvestmentBalanceService>();

            services.AddTransient<IInvestmentMovementRepository, InvestmentMovementRepository>();
            services.AddTransient<IInvestmentMovementService, InvestmentMovementService>();

            services.AddTransient<IParameterRepository, ParameterRepository>();
            services.AddTransient<IParameterService, ParameterService>();

            services.AddTransient<IStatusRepository, StatusRepository>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IWithdrawalRepository, WithdrawalRepository>();
            services.AddTransient<IWithdrawalService, WithdrawalService>(); ;

            return services;
        }
    }
}
