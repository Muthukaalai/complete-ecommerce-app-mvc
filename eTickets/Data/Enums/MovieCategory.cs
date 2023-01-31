using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public enum MovieCategory
    {
        // by default it starts with 0 but I'm giving value as 1 & coreesponding will bw 2, 3, 4
        Action = 1,
        Comedy,
        Drama,
        Documentary,
        Cartoon,
        Horror
    }
}
