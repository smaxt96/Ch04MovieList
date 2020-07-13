using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ch04MovieList.Models
{
    public class BirthDateModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a birth date in the format of mm/dd/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string BirthDate { get; set; }
        public int CalculateCurrentAge()
        {
            DateTime dateOfBirth = DateTime.Parse(BirthDate);
            DateTime today = DateTime.Now;

            TimeSpan difference = today - dateOfBirth;
            int currentAge = (int)(difference.TotalDays / 365);
            return currentAge;
        }
    }
}
