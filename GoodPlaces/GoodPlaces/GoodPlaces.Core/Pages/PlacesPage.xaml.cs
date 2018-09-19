using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodPlaces.Core.ViewModels;
using GoodPlaces.Logic.Models;
using MvvmCross.Commands;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodPlaces.Core.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlacesPage : MvxContentPage
	{
		public PlacesPage ()
		{
			InitializeComponent ();
		}
		
	}
}