using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using GoodPlaces.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GoodPlaces.Core.Helpers;

namespace GoodPlaces.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel//<Dictionary<string, string>>
	{

		private readonly IMvxNavigationService _navigationService;
		private readonly Services.IAppSettings _settings;
		private readonly IUserDialogs _userDialogs;
        private readonly ILoginServices _loginServices;
		private readonly ILocalizeService _localizeService;

        public LoginViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService, ILoginServices loginServices)
		{
			_navigationService = navigationService;
			_settings = settings;
			_userDialogs = userDialogs;
			_localizeService = localizeService;
            _loginServices = loginServices;
		}

		public IMvxAsyncCommand LoginCommand =>
			new MvxAsyncCommand(async () =>
			{

                if(ValidData())
                {
                    IsVisible = false;
                    if (await _loginServices.login(Email, Password)) {
                        await _navigationService.Navigate<PlacesViewModel>();
                    }
                    else {
                        ErrorMessage = "Invalid Email or Password";
                        IsVisible = true;
                    }
                }
                else 
                {
                    ErrorMessage = "Invalid Email format";
                    IsVisible = true;
                }
				
			});

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                SetProperty(ref _isVisible, value);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                SetProperty(ref _errorMessage, value);
            }
        }

        private bool ValidData()
        {
            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(Email, emailPattern))
            {
                IsVisible = false;
                return true;
            }
            else
            {
                IsVisible = true;
                return false;
            }
        }
    }
}
