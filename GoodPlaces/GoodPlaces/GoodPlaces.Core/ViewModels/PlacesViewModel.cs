using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GoodPlaces.Logic.Models;
using GoodPlaces.Logic.Managers;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace GoodPlaces.Core.ViewModels
{
	public class PlacesViewModel : MvxViewModel
	{
		private readonly IMvxNavigationService _navigationService;
		public IMvxCommand ItemTappedCommand { get; private set; }

		public PlacesViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
			LoadPlacesViewModel();

		}

		private ObservableCollection<Place> _items;
		public ObservableCollection<Place> Items {
			get {
				return _items;
			}
			set {
				SetProperty(ref _items, value);
			}
		}

		public void LoadPlacesViewModel()
		{
			/*Items = new ObservableCollection<Place>() {
				new Place()
				{
					Distance = "200m",
					Name = "Panchita",
					Rating = 3
				},
				new Place()
				{
					Distance = "300m",
					Name = "Kingdom",
					Rating = 5
				}
			};*/
		
		Task.Run(async () => {
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
				if (status != PermissionStatus.Granted)
				{
					var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

					if (results.ContainsKey(Permission.Location))
						status = results[Permission.Location];
				}

				if (status == PermissionStatus.Granted)
				{
					var locator = CrossGeolocator.Current;
					locator.DesiredAccuracy = 50;
					try
					{
						var position = await locator.GetPositionAsync();
						Console.WriteLine("Position Status: {0}", position.Timestamp);
						Console.WriteLine("Position Latitude: {0}", position.Latitude);
						Console.WriteLine("Position Longitude: {0}", position.Longitude);
						string location = string.Format("{0},{1}", position.Latitude, position.Longitude);
						var data = await APIManager.GetPlaces(location);
						Items = new ObservableCollection<Place>(data.Places);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}

				}
			});
			ItemTappedCommand = new MvxCommand<Place>(OutputAge);
		}

		void OutputAge(Place place)
		{
			/*SelectedItemText = string.Format("{0} is {1} years old.", person.Name, person.Age);
			OnPropertyChanged("SelectedItemText");*/
			_navigationService.Navigate<PlaceDetailViewModel, Place>(place);
		}
	}
}
