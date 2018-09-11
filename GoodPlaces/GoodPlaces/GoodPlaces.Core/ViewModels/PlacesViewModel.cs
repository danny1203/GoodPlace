using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GoodPlaces.Logic.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace GoodPlaces.Core.ViewModels
{
	public class PlacesViewModel : MvxViewModel
	{
		private readonly IMvxNavigationService _navigationService;
		//private readonly Services.IAppSettings _settings;

		//private ObservableCollection<Place> items;

		public PlacesViewModel(IMvxNavigationService navigationService)//, Services.IAppSettings settings)
		{
			_navigationService = navigationService;
			//_settings = settings;
			LoadPlacesViewModel();
			//ButtonText = Resources.AppResources.MainPageButton;
			//await GetLocationAsync();
		}

		private ObservableCollection<Place> items;
		public ObservableCollection<Place> Items { get; set; }

		public void goToDetailsAsync(Place place)
		{
			_navigationService.Navigate<PlaceDetailViewModel, Place>(place);
		}

		public IMvxCommand GetCurrentLocation =>
			new MvxCommand( () =>
			{ /*try
				{
					var locator = CrossGeolocator.Current;
					locator.DesiredAccuracy = 5;


					var position = locator.GetPositionAsync(TimeSpan.FromSeconds(5)).Result;
				}
				catch (Exception ex)
				{
					Console.WriteLine("test");
				}*/
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

							var result = await locator.GetPositionAsync();
						}
						catch (Exception e)
						{
							Console.WriteLine("test");
						}
						
					}
				});
				//Console.WriteLine
				/*Debug.WriteLine("Position Status: {0}", position.Timestamp);
				Debug.WriteLine("Position Latitude: {0}", position.Latitude);
				Debug.WriteLine("Position Longitude: {0}", position.Longitude);*/
			});

		public void LoadPlacesViewModel()
		{
			Items = new ObservableCollection<Place>() {
				new Place()
				{
					Distance = "200m",
					Name = "Panchita",
					Ranking = 3
				},
				new Place()
				{
					Distance = "300m",
					Name = "Kingdom",
					Ranking = 5
				}
			};

			// Web service call to update list with new values
			/*MyHTTP.GetAllNewsAsync(list =>
			{
				foreach (Car item in list)
					Items.Add(item);
			});*/
		}

		private async System.Threading.Tasks.Task GetLocationAsync()
		{
			/*IMvxLocationWatcher _locationWatcher = Mvx.Resolve<IMvxLocationWatcher>();
			_locationWatcher.Start(new MvxLocationOptions() { Accuracy = MvxLocationAccuracy.Fine }, (location) => {
			// Use location parameter to get location information}, 
			OnError);*/
			var locator = CrossGeolocator.Current;

			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

			Debug.WriteLine("Position Status: {0}", position.Timestamp);
			Debug.WriteLine("Position Latitude: {0}", position.Latitude);
			Debug.WriteLine("Position Longitude: {0}", position.Longitude);

		}


		/*public async Task SelectPlace()
		{
			await _navigationService.Navigate<LoginViewModel>();
		}*/


		/*	private Place _selectPlace { get; set; }
		public Place SelectPlace {
			get { return _selectPlace; }
			set
			{
				if (_selectPlace != value)
				{
					_selectPlace = value;
					
					_navigationService.Navigate<LoginViewModel>();
					//HandleSelectItemAsync();
				}
			}

		}*/

		//
		/*public IMvxAsyncCommand PlaceSelectedCommand =>
				new MvxAsyncCommand(async () =>
				{

					await _navigationService.Navigate<SecondViewModel, Dictionary<string, string>>(param);
				});*/
		//

		/*public async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			(sender as ListView).SelectedItem = null;

			if (args.SelectedItem != null)
			{
				await _navigationService.Navigate<LoginViewModel>();
				/*PageDataViewModel pageData = args.SelectedItem as PageDataViewModel;
				Page page = (Page)Activator.CreateInstance(pageData.Type);
				await Navigation.PushAsync(page);*/
		/*}
	}*/
	}
}
