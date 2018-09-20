using System;
using System.Collections.Generic;
using System.Text;
using GeoCoordinatePortable;
using Newtonsoft.Json;
using MvvmCross.Commands;
using System.Linq;
using GoodPlaces.Logic.Utils;

namespace GoodPlaces.Logic.Models
{
	public class Place
	{
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
		[JsonProperty("geometry")]
		public GeometryData Geometry { get; set; }
		[JsonProperty("photos")]
		public IEnumerable<Photos> Photos { get; set; }

		private string _distance { get; set; }
		public string Distance
		{
			get
			{
				var sCoord = new GeoCoordinate(Geometry.Location.Latitude, Geometry.Location.Longitude);
				var eCoord = new GeoCoordinate(Geometry.Viewport.Northeast.Latitude, Geometry.Viewport.Northeast.Longitude);

				return Convert.ToInt32(sCoord.GetDistanceTo(eCoord)) + " m";
			}
			set
			{
				_distance = value;
			}
		}
		private string _photo { get; set; }
		public string Photo
		{
			get
			{
				string image = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=200&photoreference=CmRaAAAAtF8f2Ri1T6SwYk7qPhS8Wna9L_F77eHdsKEx2CKQ9ubhHUy7lDH9WLnL1NV98ZdKM4eU5iWjJAUd42wFeGIRBGTYsuZ7xocCUqJLoMwCu4ktTwdmoYVUHYzIGbyN5qAgEhApLVsEYLiOPsFve4b9dnGhGhT9Bmwm2EadFjwEyPdWdWpZcKK7ag&key=AIzaSyDJgfFUC7V8Hn1n2K7x3KklmgzM_BmVGU0";
				try
				{
					var firstImage = Photos.Cast<Photos>().First();
					image = string.Format("https://maps.googleapis.com/maps/api/place/photo?maxwidth=300&photoreference={0}&key={1}", firstImage.Reference, Constants.ApiKey);
				} catch (Exception ex)
				{
					Console.WriteLine("error on get image " + ex);
				}
				
				return image;
			}
			set
			{
				_photo = value;
			}
		}
		private string _ratingText { get; set; }
		public string RatingText
		{
			get
			{
				return Rating + " Stars";
			}
			set
			{
				_ratingText = value;
			}
		}
	}

	public class GeometryData
		{
		[JsonProperty("location")]
		public Location Location { get; set; }
		[JsonProperty("viewport")]
		public Viewport Viewport { get; set; }
	}

	public class Location
	{
		[JsonProperty("lat")]
		public double Latitude { get; set; }
		[JsonProperty("lng")]
		public double Longitude { get; set; }
	}

	public class Viewport
	{
		[JsonProperty("northeast")]
		public Location Northeast { get; set; }
		[JsonProperty("southwest")]
		public Location Southwest { get; set; }
	}


	public class Photos
	{
		[JsonProperty("photo_reference")]
		public string Reference { get; set; }
	}
}
