using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoodPlaces.Logic.Models
{
	public class Place
	{

		private string _distance { get; set; }
		public string Distance {
			get { return _distance; }
			set
			{
				if (_distance != value)
				{
					_distance = value;
				}
			}
		}
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("rating")]
		public double Rating { get; set; }
		[JsonProperty("vicinity")]
		public string Address { get; set; }
		[JsonProperty("icon")]
		public string Image { get; set; }
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("place_id")]
		public string PlaceId { get; set; }
		[JsonProperty("formatted_phone_number")]
		public string PhoneNumber { get; set; }
	}
}
