﻿using System;
using System.Collections.ObjectModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Maui.Controls.UITests;

namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 19283, "PointerOver VSM Breaks Button", PlatformAffected.iOS)]
	public partial class Issue19283 : ContentPage
	{
		public Issue19283()
		{
			InitializeComponent();

			// https://github.com/dotnet/maui/issues/19289
			if (!OperatingSystem.IsAndroid())
			{
				btn.GestureRecognizers.Add(new PointerGestureRecognizer());
			}

			btn.Clicked += (sender, args) =>
			{
				layout.Children.Add(new Label { Text = "Success", AutomationId = "Success" });
			};
		}
	}
}
