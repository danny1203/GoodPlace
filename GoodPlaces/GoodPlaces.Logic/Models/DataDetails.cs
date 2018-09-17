using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoodPlaces.Logic.Models
{
	public class DataDetails
	{
		[JsonProperty("results")]
		public Place Place { get; set; }
	}
}
