using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models.Ticket
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            filterstring = filterstring ?? "all";
            string[] filters = filterstring.Split('-');
            StatusId = filters[0];
        }

        public string FilterString { get; }
        public string StatusId { get; }

        public bool HasStatus => StatusId.ToLower() != "all";
    }
}
