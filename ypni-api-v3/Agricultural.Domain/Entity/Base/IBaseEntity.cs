using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
