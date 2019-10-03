﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Controls
{
	public class BackgroundImageGallery
		: ContentPage
	{
		public BackgroundImageGallery ()
		{
			var contentIntabs = new Button { Text = "Tabbed children" };
			contentIntabs.Clicked += async (sender, args) => {
				await Navigation.PushModalAsync (new TabbedPage {
					ItemTemplate = new DataTemplate (() => {
						var page = new ContentPage();
						page.SetBinding (BackgroundImageSourceProperty, ".");
						return page;
					}),

					ItemsSource = new[] {
						"oasis.jpg",
						"crimson.jpg"
					}
				});
			};

			var contentInCarosel = new Button { Text = "Carousel children" };
			contentInCarosel.Clicked += async (sender, args) => {
#pragma warning disable CS0618 // Type or member is obsolete
				await Navigation.PushModalAsync (new CarouselPage
				{
#pragma warning restore CS0618 // Type or member is obsolete
					ItemTemplate = new DataTemplate (() => {
						var page = new ContentPage();
						page.SetBinding (BackgroundImageSourceProperty, ".");
						return page;
					}),

					ItemsSource = new[] {
						"oasis.jpg",
						"crimson.jpg"
					}
				});
			};

			var navigation = new Button { Text = "NavigationPage"};
			navigation.Clicked += async (sender, args) => {
				await Navigation.PushModalAsync (new NavigationPage (new ContentPage {
						Content = new Label {
							Text = "Text",
							FontSize = 42
						}})
					{
						BackgroundImageSource = "oasis.jpg"
					}
				);
			};

			var carousel = new Button { Text = "CarouselPage" };
			carousel.Clicked += async (sender, args) => {
#pragma warning disable CS0618 // Type or member is obsolete
				await Navigation.PushAsync (new CarouselPage
				{
#pragma warning restore CS0618 // Type or member is obsolete
					BackgroundImageSource = "crimson.jpg",
					ItemsSource = new[] { "test1", "test2" }
				});
			};

			var tabbed = new Button { Text = "TabbedPage" };
			tabbed.Clicked += async (sender, args) => {
				await Navigation.PushAsync (new TabbedPage {
					BackgroundImageSource = "crimson.jpg",
					ItemsSource = new[] { "test1", "test2" }
				});
			};

			var master = new Button { Text = "MasterDetail" };
			master.Clicked += async (sender, args) => {
				await Navigation.PushModalAsync (new MasterDetailPage {
					Master = new ContentPage { Title = "Master" },
					Detail = new ContentPage(),
					BackgroundImageSource = "crimson.jpg",
				});
			};

			Content = new StackLayout {
				Children = {
					navigation,
					carousel,
					tabbed,
					master,
					contentIntabs,
					contentInCarosel
				}
				
			};
		}
	}
}
