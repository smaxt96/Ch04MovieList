using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models.Olympics
{
	public class CountryViewModel
	{
		public Country Country { get; set; }
		public string ActiveCat { get; set; } = "all";
		public string ActiveGame { get; set; } = "all";

	}
}