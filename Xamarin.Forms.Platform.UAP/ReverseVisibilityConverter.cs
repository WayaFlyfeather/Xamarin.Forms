using System;
using Windows.UI.Xaml;

namespace Xamarin.Forms.Platform.UWP
{
	public class ReverseVisibilityConverter : Windows.UI.Xaml.Data.IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Visibility v = (Visibility)value;

			return v == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
