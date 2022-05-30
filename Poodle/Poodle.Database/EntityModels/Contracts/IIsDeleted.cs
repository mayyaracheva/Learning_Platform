using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels.Contracts
{
    public interface IIsDeleted
    {
        bool IsDeleted { get; set; }
    }
}
