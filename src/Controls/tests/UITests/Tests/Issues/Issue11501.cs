﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class Issue11501 : _IssuesUITest
	{
		public Issue11501(TestDevice device) : base(device)
		{
		}

		public override string Issue => "Making Fragment Changes While App is Backgrounded Fails";

		public override bool ResetMainPage => false;

		[TestCase("SwapMainPage")]
		[TestCase("SwapFlyoutPage")]
		[TestCase("SwapTabbedPage")]
		[TestCase("RemoveAddTabs")]
		public void MakingFragmentRelatedChangesWhileAppIsBackgroundedFails(string scenario)
		{
			this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.Mac, TestDevice.Windows });

			try
			{
				App.WaitForElement(scenario);
				App.Tap(scenario);
				App.WaitForElement("BackgroundMe");
				App.BackgroundApp();
				App.WaitForNoElement("BackgroundMe");
				App.ForegroundApp();
				App.WaitForElement("Restore");
				App.Tap("Restore");
			}
			catch
			{
				SaveUIDiagnosticInfo();

				// Just in case these tests leave the app in an unreliable state
				App.ResetApp();
				FixtureSetup();
				throw;
			}
		}
	}
}
