using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodPlaces.Core.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaceDetailPage : MvxContentPage
	{
		public PlaceDetailPage()
		{
			InitializeComponent();
		}
	}
}