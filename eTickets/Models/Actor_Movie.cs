using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public MovieM movie { get; set; }  // here MovieM is a model we created

        public int ActorId { get; set; }
        public ActorM Actor { get; set; }
    }
}
