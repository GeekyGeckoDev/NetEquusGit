using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProviderInterfaces
{
    public interface ISystemAccountProvider
    {
        Guid GetSystemUserId();

        Guid GetSystemEstateId();
    }
}
