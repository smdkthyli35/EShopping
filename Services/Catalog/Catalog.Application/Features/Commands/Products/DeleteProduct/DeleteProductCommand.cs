using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}
