// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using GoodPlaces.Core.Services;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;

namespace GoodPlaces.Core
{
	public class MvxApp : MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes().
				EndingWith("Repository")
				.AsTypes()
				.RegisterAsLazySingleton();

			Mvx.RegisterType<Services.IAppSettings, Services.AppSettings>();
			Mvx.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
			Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.ConstructAndRegisterSingleton<ILoginServices, LoginMockServices>();

			//IMvxNavigationViewModel

			Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ5NTFAMzEzNjJlMzMyZTMwTlBBdjNSTy9wa0liRkpva2N2MC9JYlhIVlBLVDJWS2h6bXhVcHV1QXlqTT0=");
			//RegisterAppStart<ViewModels.MainViewModel>();
			RegisterAppStart<ViewModels.LoginViewModel>();
		}
	}
}
