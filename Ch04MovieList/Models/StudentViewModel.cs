using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models
{
    public class StudentViewModel
    {
        public int AccessLevel { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
