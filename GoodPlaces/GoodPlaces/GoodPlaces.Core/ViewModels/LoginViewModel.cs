using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using GoodPlaces.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GoodPlaces.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel//<Dictionary<string, string>>
	{

		private readonly IMvxNavigationService _navigationService;
		private readonly Services.IAppSettings _settings;
		private readonly IUserDialogs _userDialogs;

		private readonly ILocalizeService _localizeService;

		public LoginViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
		{
			_navigationService = navigationService;
			_settings = settings;
			_userDialogs = userDialogs;
			_localizeService = localizeService;
		}

		public IMvxAsyncCommand LoginCommand =>
			new MvxAsyncCommand(async () =>
			{
				await _navigationService.Navigate<PlacesViewModel>();
			});

		/*public int Email
		{
			get { return _settings.Email; }
			set { _settings.Email = value; }
		}

		public int Password
		{
			get { return _settings.Password; }
			set { _settings.Password = value; }
		}*/
	}
}
