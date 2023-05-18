using Agricultural.Application.DTOs.Config;
using Agricultural.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Services
{
    public interface  IConfigService
    {
        Task<IResult<ConfigDTO>> GetConfig(CancellationToken cancellationToken = default);

    }
}
