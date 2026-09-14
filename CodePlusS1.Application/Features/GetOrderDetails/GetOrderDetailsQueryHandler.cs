using CodePlusS1.Domain.Models;
using CodePlusS1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePlusS1.Application.Features.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler
    {
        private readonly TaskDbContext context;

        public GetOrderDetailsQueryHandler(TaskDbContext context)
        {
            this.context = context;
        }

        public async Task<OrderDto> Handle()
        {
          

        }

        
    }
}
