using AutoMapper;
using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Models;

namespace BGB.InternetBanking.Api
{
    public static class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Reset();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Acquirer, AcquirerDto>();

                cfg.CreateMap<BindedAccount, BindedAccountDto>()
                .ForSourceMember(src => src.Customer, opt => opt.Ignore());

                cfg.CreateMap<BusinessCheck, BusinessCheckDto>();

                cfg.CreateMap<CardMovement, CardMovementDto>();

                cfg.CreateMap<CheckingAccount, CheckingAccountDto>();

                cfg.CreateMap<CheckingAccountDto, CheckingAccount>()
                .ForMember(dst => dst.Type, opt => opt.Ignore())
                .ForMember(dst => dst.Formatted, opt => opt.Ignore());

                cfg.CreateMap<CheckingAccountBalance, CheckingAccountBalanceDto>()
                .ForMember(dst => dst.Available, opt => opt.MapFrom(src => src.Available));

                cfg.CreateMap<CheckingAccountMovement, CheckingAccountMovementDto>();

                cfg.CreateMap<Cpf, CpfDto>();
                
                cfg.CreateMap<CpfDto, Cpf>()
                .ForMember(dst => dst.Control, opt => opt.Ignore())
                .ForMember(dst => dst.Digit, opt => opt.Ignore())
                .ForMember(dst => dst.FormatedNumber, opt => opt.Ignore());

                cfg.CreateMap<Credential, CredentialDto>()
                .ForMember(dst => dst.AccountNumber, opt => opt.Ignore());

                cfg.CreateMap<Customer, CustomerDto>();

                cfg.CreateMap<CustomerDto, Customer>();

                cfg.CreateMap<Deed, DeedDto>()
                .ForSourceMember(src => src.Instruction, opt => opt.Ignore())
                .ForSourceMember(src => src.DayProtest, opt => opt.Ignore());

                cfg.CreateMap<Establishment, EstablishmentDto>();

                cfg.CreateMap<Flag, FlagDto>();

                cfg.CreateMap<GuaranteeBoard, GuaranteeBoardDto>();

                cfg.CreateMap<Index, IndexDto>();

                cfg.CreateMap<IndexQuotation, IndexQuotationDto>();

                cfg.CreateMap<InvestmentMovement, InvestmentMovementDto>()
                .ForMember(src => src.PaperCode, opt => opt.MapFrom(src => src.Paper.Code))
                .ForMember(src => src.PaperName, opt => opt.MapFrom(src => src.Paper.Name));

                cfg.CreateMap<InvestmentStatement, InvestmentStatementDto>();

                cfg.CreateMap<Payee, PayeeDto>();

                cfg.CreateMap<PayeeDto, Payee>();

                cfg.CreateMap<PresumedIncome, PresumedIncomeDto>();

                cfg.CreateMap<Status, StatusDto>();

                cfg.CreateMap<StatusDto, Status>();

                cfg.CreateMap<TypeStatus, TypeStatusDto>();

                cfg.CreateMap<TypeStatusDto, TypeStatus>();

                cfg.CreateMap<User, UserDto>()
                .ForSourceMember(src => src.Credential, opt => opt.Ignore());

                cfg.CreateMap<UserDto, User>()
                .ForMember(dst => dst.Credential, opt => opt.Ignore());

                cfg.CreateMap<WithdrawalCommunication, WithdrawalCommunicationDto>()
                .ForSourceMember(src => src.MinimumAmount, opt => opt.Ignore())
                .ForSourceMember(src => src.ExpectedDateValid, opt => opt.Ignore());

                cfg.CreateMap<WithdrawalCommunicationDto, WithdrawalCommunication>()
                .ForMember(dst => dst.MinimumAmount, opt => opt.Ignore())
                .ForMember(dst => dst.ExpectedDateValid, opt => opt.Ignore())
                .ForMember(dst => dst.DaysInAdvance, opt => opt.Ignore());
            });
        }
    }
}