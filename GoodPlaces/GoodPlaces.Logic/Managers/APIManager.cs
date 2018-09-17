using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoodPlaces.Logic.Models;
using GoodPlaces.Logic.Utils;
using Newtonsoft.Json;

namespace GoodPlaces.Logic.Managers
{
	public class APIManager
	{

		private static HttpClient GetClient()
		{
			HttpClient client = new HttpClient();

			client.DefaultRequestHeaders.Add("Accept", "application/json");
			return client;
		}

		private static string getUrlPlaces(string Location) {
			string url = string.Format("{0}/nearbysearch/json?location={1}&radius=3500&type=restaurant|food|store|police|hospital&keyword=cruise&key={2}", Constants.URLBase, Location, Constants.ApiKey);
			return url;
		}

		private static string getUrlPlaceDetails(string PlaceId)
		{
			//https://maps.googleapis.com/maps/api/place/details/json?placeid=ChIJ89S_Lgx045MRl1_v46KLKx4&fields=name,rating,formatted_phone_number,icon,vicinity&key=AIzaSyDJgfFUC7V8Hn1n2K7x3KklmgzM_BmVGU0
			string url = string.Format("{0}/details/json?placeid={1}&fields=name,rating,formatted_phone_number,icon,vicinity&key={2}", Constants.URLBase, PlaceId, Constants.ApiKey);
			return url;
		}

		public static async Task<GoogleData> GetPlaces(String Location)
		{
			string result = string.Empty;
			HttpClient client = GetClient();
			try
			{
				result = await client.GetStringAsync(getUrlPlaces(Location));
				return JsonConvert.DeserializeObject<GoogleData>(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return null;
		}

		public static async Task<DataDetails> GetPlaceDetails(String PlaceId)
		{
			string result = string.Empty;
			HttpClient client = GetClient();
			try
			{
				result = await client.GetStringAsync(getUrlPlaceDetails(PlaceId));
				return JsonConvert.DeserializeObject<DataDetails>(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return null;
		}

	}
}
