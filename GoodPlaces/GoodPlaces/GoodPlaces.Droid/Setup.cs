﻿// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;

namespace GoodPlaces.Droid
{
	public class Setup : MvxFormsAndroidSetup<Core.MvxApp, Core.FormsApp>
	{
		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();

			Mvx.RegisterSingleton<Core.Services.ILocalizeService>(() => new Services.LocalizeService());
		}
	}
}