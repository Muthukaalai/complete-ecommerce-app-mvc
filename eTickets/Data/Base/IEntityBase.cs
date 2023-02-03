using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    // Creating base interface because we have created 'Add/Create, update, Delete' Actors now
    // we have to create the same way for Movies, Producers, Cinemas instead of creating same method from scratch
    // we are going to implement generic solution base repository interface and base generic implementation
    // 
    public interface IEntityBase
    {
        int Id { get; set; }  // check all folders MVC for Actors - we have Id common for all so we are adding ID as base interface here
    }
}
