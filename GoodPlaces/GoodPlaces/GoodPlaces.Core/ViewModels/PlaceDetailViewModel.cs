using System;
using System.Collections.Generic;
using System.Text;
using GoodPlaces.Logic.Models;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GoodPlaces.Core.ViewModels
{
    class PlaceDetailViewModel : MvxViewModel<Place>
	{
		private readonly IMvxNavigationService _navigationService;
		private readonly Services.IAppSettings _settings;

		public PlaceDetailViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings)
		{
			_navigationService = navigationService;
			_settings = settings;
		
		}

		public override async void Prepare(Place parameter)
		{
			//throw new NotImplementedException();
			await _navigationService.Navigate<PlacesViewModel>();
		}

		/*public void Init(Place item)
		{
			Place = item;
		}

		private Place _placeItem;
		public Place Place
		{
			get { return _placeItem; }
			set { _placeItem = value; RaisePropertyChanged(() => Place); }
		}*/
	}
}
