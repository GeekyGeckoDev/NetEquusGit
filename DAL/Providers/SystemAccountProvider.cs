using Application.ProviderInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.NetEquusDbContext;

namespace Infrastructure.Providers
{
    public  class SystemAccountProvider : ISystemAccountProvider
    {

        private readonly NetEquusDbContext _context;

        public SystemAccountProvider(NetEquusDbContext context)
        {
            _context = context;
        }

        public Guid GetSystemUserId() => SystemConstants.SystemUserId;

        public Guid GetSystemEstateId() => SystemConstants.SystemEstateId;
    }
}
