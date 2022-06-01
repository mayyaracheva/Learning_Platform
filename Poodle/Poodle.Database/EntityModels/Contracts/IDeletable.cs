using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
