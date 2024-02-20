﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Maui.Controls.UITests;

namespace Maui.Controls.Sample.Issues
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[Issue(IssueTracker.Github, 18282, "The editor placeholder can't able to changed, It's default placed at center", PlatformAffected.iOS)]
	public partial class Issue18282 : ContentPage
	{
		public Issue18282()
		{
			InitializeComponent();
		}
	}
}