﻿using MediatR;

namespace Basket.Application.Features.Commands.Baskets.DeleteBasketByUserName
{
    public class DeleteBasketByUserNameCommand : IRequest<Unit>
    {
        public string UserName { get; set; }

        public DeleteBasketByUserNameCommand(string userName)
        {
            UserName = userName;
        }
    }
}
