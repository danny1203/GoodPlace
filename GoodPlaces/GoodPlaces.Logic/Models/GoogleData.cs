using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoodPlaces.Logic.Models
{
	public class GoogleData
	{
		[JsonProperty("results")]
		public IEnumerable<Place> Places { get; set; }
	}
}
