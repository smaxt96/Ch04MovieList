using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models.Ticket
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please enter a sprint number.")]
        public string SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        public string PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
