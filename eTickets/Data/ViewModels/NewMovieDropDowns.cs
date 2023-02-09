using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropDowns
    {
        public NewMovieDropDowns()
        {
            Producers = new List<ProducerM>();
            Cinema = new List<CinemaM>();
            Actor = new List<ActorM>();        }
        public List<ProducerM> Producers { get; set; }
        public List<CinemaM> Cinema { get; set; }
        public List<ActorM> Actor { get; set; }

    }
}
