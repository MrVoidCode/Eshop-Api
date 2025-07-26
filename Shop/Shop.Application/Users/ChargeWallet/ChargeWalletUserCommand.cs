using Common.Application;
using FluentValidation;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.ChargeWallet
{
    internal class ChargeWalletUserCommand : IBaseCommand
    {
        public ChargeWalletUserCommand(long userId, int price, WalletType type, string description, bool isFinally)
        {
            UserId = userId;
            Price = price;
            Type = type;
            Description = description;
            IsFinally = isFinally;
        }
        public long UserId { get; internal set; }
        public int Price { get; set; }
        public WalletType Type { get; set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
    }
    internal class ChargeWalletUserCommandHandler : IBaseCommandHandler<ChargeWalletUserCommand>
    {
        private readonly IUserDomainRepository _repository;
        private readonly IDomainUserService _service;

        public ChargeWalletUserCommandHandler(IUserDomainRepository repository, IDomainUserService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<OperationResult> Handle(ChargeWalletUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user != null)
            {
                return OperationResult.NotFound();
            }
            var wallet = new Wallet(request.Price, request.Type, request.Description, request.IsFinally);

            user.ChargeWallet(wallet);
            return OperationResult.Success();
        }
    }
    internal class ChargeWalletUserCommandValidation : AbstractValidator<ChargeWalletUserCommand>
    {
        public ChargeWalletUserCommandValidation()
        {
            RuleFor(f => f.Description)
                .NotEmpty()
                .NotNull().WithMessage(ValidationMessages.required("توضیحات"));
            RuleFor(f => f.Type)
                .NotEmpty()
                .NotNull().WithMessage(ValidationMessages.required("نوع"));
            RuleFor(f => f.Price)
                .NotEmpty()
                .NotNull().WithMessage(ValidationMessages.required("قیمت"))
                .LessThanOrEqualTo(1000).WithMessage("قیمت نمیتواند کمتر از 1000 باشد");
        }
    }
}
