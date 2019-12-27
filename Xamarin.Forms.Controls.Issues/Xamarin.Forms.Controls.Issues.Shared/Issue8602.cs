using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 8602, "UWP NavigationPage.TitleView does not fill Header", PlatformAffected.UWP)]
	public class Issue8602 : TestContentPage
	{
		public Issue8602()
		{
			Title = "Issue 8602";
		}

		Issue8602A page8602A = new Issue8602A();

		protected override void Init()
		{
			Grid navPageTitleView = new Grid();
			navPageTitleView.BackgroundColor = Color.Red;
			navPageTitleView.HorizontalOptions = LayoutOptions.FillAndExpand;
			navPageTitleView.VerticalOptions = LayoutOptions.FillAndExpand;
			NavigationPage.SetTitleView(this, navPageTitleView);

			BackgroundColor = Color.Yellow;

			Label instructions = new Label
			{
				Text = "Check the Title area. It should have a red background with no visible border, neither to the left or between it and the yellow page.\n"
				     + "There should be no text in the title area.\n\n"
					 + "Then click button 'To 8602A' below\n\n"
			};

			Button navButton = new Button { Text = "To 8602A", Margin = 10.0 };
			navButton.Clicked += (s, a) =>
			{
				Navigation.PushAsync(page8602A);
			};

			var stack = new StackLayout();

			stack.Children.Add(instructions);
			stack.Children.Add(navButton);

			Content = stack;
		}

		class Issue8602A : ContentPage
		{
			public Issue8602A()
			{
				Title = "Issue 8602A";

				BackgroundColor = Color.Yellow;

				Label instructions = new Label
				{
					Text = "Check the Title area. It should simply say 'Issue 8602A' and look normal."
				};

				var stack = new StackLayout();

				stack.Children.Add(instructions);

				Content = stack;
			}
		}
	}
}

