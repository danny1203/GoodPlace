using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GoodPlaces.Logic.Managers;
using GoodPlaces.Logic.Models;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace GoodPlaces.Core.ViewModels
{
    class PlaceDetailViewModel : MvxViewModel<Place>
	{
		private readonly IMvxNavigationService _navigationService;
		private readonly Services.IAppSettings _settings;
		public string SelectedItemText { get; private set; }
		
		private Place _placeDetail;
		public Place PlaceDetail
		{
			get
			{
				return _placeDetail;
			}
			set
			{
				SetProperty(ref _placeDetail, value);
			}
		}


		public PlaceDetailViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings)
		{
			_navigationService = navigationService;
			_settings = settings;
		
		}

		public override async void Prepare(Place Place)
		{
			//throw new NotImplementedException();
			try
			{
				var data = await APIManager.GetPlaceDetails(Place.PlaceId);
				PlaceDetail = data.Place;
				
				
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
