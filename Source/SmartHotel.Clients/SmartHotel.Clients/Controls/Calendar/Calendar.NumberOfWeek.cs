﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
	public partial class Calendar : ContentView
	{
		List<Grid> weekNumbers;
		List<Label> weekNumberLabels;

		#region NumberOfWeekTextColor

		public static readonly BindableProperty NumberOfWeekTextColorProperty =
		  BindableProperty.Create(nameof(NumberOfWeekTextColor), typeof(Color), typeof(Calendar), Color.FromArgb("#aaaaaa"),
								  propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeNumberOfWeekTextColor((Color)newValue, (Color)oldValue));

		protected void ChangeNumberOfWeekTextColor(Color newValue, Color oldValue)
		{
			if (newValue == oldValue) return;
			weekNumberLabels.ForEach(l => l.TextColor = newValue);
		}

		/// <summary>
		/// Gets or sets the text color of the number of the week labels.
		/// </summary>
		/// <value>The color of the weekdays text.</value>
		public Color NumberOfWeekTextColor
        {
            get => (Color)GetValue(NumberOfWeekTextColorProperty);
            set => SetValue(NumberOfWeekTextColorProperty, value);
        }

        public static readonly BindableProperty NumberOfWeekBackgroundColorProperty =
			BindableProperty.Create(nameof(NumberOfWeekBackgroundColor), typeof(Color), typeof(Calendar), Colors.Transparent,
									propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeNumberOfWeekBackgroundColor((Color)newValue, (Color)oldValue));

		protected void ChangeNumberOfWeekBackgroundColor(Color newValue, Color oldValue)
		{
			if (newValue == oldValue) return;
			weekNumberLabels.ForEach(l => l.BackgroundColor = newValue);
		}

		/// <summary>
		/// Gets or sets the background color of the number of the week labels.
		/// </summary>
		/// <value>The color of the number of the weeks background.</value>
		public Color NumberOfWeekBackgroundColor
        {
            get => (Color)GetValue(NumberOfWeekBackgroundColorProperty);
            set => SetValue(NumberOfWeekBackgroundColorProperty, value);
        }

        #endregion

        #region NumberOfWeekFontSize

        public static readonly BindableProperty NumberOfWeekFontSizeProperty =
			BindableProperty.Create(nameof(NumberOfWeekFontSize), typeof(double), typeof(Calendar), 14.0,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeNumberOfWeekFontSize((double)newValue, (double)oldValue));

		protected void ChangeNumberOfWeekFontSize(double newValue, double oldValue)
		{
			if (Math.Abs(newValue - oldValue) < 0.01) return;
			// TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
			weekNumbers?.ForEach((obj) => obj.WidthRequest = newValue*( Device.RuntimePlatform == Device.iOS ? 1.5 : 2.2));
			weekNumberLabels.ForEach(l => l.FontSize = newValue);
		}

		/// <summary>
		/// Gets or sets the font size of the number of the week labels.
		/// </summary>
		/// <value>The size of the weekdays font.</value>
		public double NumberOfWeekFontSize
        {
            get => (double)GetValue(NumberOfWeekFontSizeProperty);
            set => SetValue(NumberOfWeekFontSizeProperty, value);
        }

        #endregion

        #region NumberOfWeekFontAttributes

        public static readonly BindableProperty NumberOfWeekFontAttributesProperty =
			BindableProperty.Create(nameof(NumberOfWeekFontAttributes), typeof(FontAttributes), typeof(Calendar), FontAttributes.None,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeNumberOfWeekFontAttributes((FontAttributes)newValue, (FontAttributes)oldValue));

		protected void ChangeNumberOfWeekFontAttributes(FontAttributes newValue, FontAttributes oldValue)
		{
			if (newValue == oldValue) return;
			weekNumberLabels.ForEach(l => l.FontAttributes = newValue);
		}

		/// <summary>
		/// Gets or sets the font attributes of the number of the week labels.
		/// </summary>
		public FontAttributes NumberOfWeekFontAttributes
        {
            get => (FontAttributes)GetValue(NumberOfWeekFontAttributesProperty);
            set => SetValue(NumberOfWeekFontAttributesProperty, value);
        }

        #endregion

        #region NumberOfWeekFontFamily

        public static readonly BindableProperty NumberOfWeekFontFamilyProperty =
					BindableProperty.Create(nameof(NumberOfWeekFontFamily), typeof(string), typeof(Calendar), default(string),
                        propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeNumberOfWeekFontFamily((string)newValue, (string)oldValue));

		protected void ChangeNumberOfWeekFontFamily(string newValue, string oldValue)
		{
			if (newValue == oldValue) return;
			weekNumberLabels.ForEach(l => l.FontFamily = newValue);
		}

		/// <summary>
		/// Gets or sets the font family of the number of the week labels.
		/// </summary>
		public string NumberOfWeekFontFamily
        {
            get => GetValue(NumberOfWeekFontFamilyProperty) as string;
            set => SetValue(NumberOfWeekFontFamilyProperty, value);
        }

        #endregion

        #region ShowNumberOfWeek

        public static readonly BindableProperty ShowNumberOfWeekProperty =
			BindableProperty.Create(nameof(ShowNumberOfWeek), typeof(bool), typeof(Calendar), false,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ShowHideElements());

		/// <summary>
		/// Gets or sets wether to show the number of the week labels.
		/// </summary>
		/// <value>The weekdays show.</value>
		public bool ShowNumberOfWeek
        {
            get => (bool)GetValue(ShowNumberOfWeekProperty);
            set => SetValue(ShowNumberOfWeekProperty, value);
        }

        #endregion

        #region CalendarWeekRule

        public static readonly BindableProperty CalendarWeekRuleProperty =
			BindableProperty.Create(nameof(CalendarWeekRule), typeof(CalendarWeekRule), typeof(Calendar), CalendarWeekRule.FirstFourDayWeek,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var calendar = (bindable as Calendar);
				var start = calendar.CalendarStartDate(calendar.StartDate).Date;
				for (var i = 0; i < calendar.buttons.Count; i++)
				{
					calendar.ChangeWeekNumbers(start, i);

					start = start.AddDays(1);
					if (i != 0 && (i + 1) % 42 == 0)
					{
						start = calendar.CalendarStartDate(start);
					}
				}
			});

		/// <summary>
		/// Gets or sets what CalendarWeekRule to use for the week numbers
		/// </summary>
		/// <value>The weekdays show.</value>
		public CalendarWeekRule CalendarWeekRule
        {
            get => (CalendarWeekRule)GetValue(CalendarWeekRuleProperty);
            set => SetValue(CalendarWeekRuleProperty, value);
        }

        #endregion
        
        protected void ChangeWeekNumbers(DateTime start, int i)
		{
			if (!ShowNumberOfWeek) return;
			var ciCurr = CultureInfo.CurrentCulture;
			var weekNum = ciCurr.Calendar.GetWeekOfYear(start, CalendarWeekRule.FirstFourDayWeek, StartDay);
			weekNumberLabels[(i / 7)].Text = string.Format("{0}", weekNum);
		}

		protected void ShowHideElements()
		{
			if (mainCalendars.Count < 1) return;
			contentView.Children.Clear();
			dayLabels.Clear();
			for (var i = 0; i < ShowNumOfMonths; i++)
			{
				var main = mainCalendars[i] as Layout;

				if (ShowInBetweenMonthLabels && i > 0)
				{
					var label = new Label
					{
						FontSize = TitleLabel.FontSize,
						VerticalTextAlignment = TitleLabel.VerticalTextAlignment,
						HorizontalTextAlignment = TitleLabel.HorizontalTextAlignment,
						FontAttributes = TitleLabel.FontAttributes,
						TextColor = TitleLabel.TextColor,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = string.Empty
					};
					if (titleLabels == null)
					{
						titleLabels = new List<Label>(ShowNumOfMonths);
					}

                    titleLabels.Add(label);
                    contentView.Add(label);
				}

				if (ShowNumberOfWeek)
				{
					main = new StackLayout
					{
						Padding = 0,
						Spacing = 0,
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Orientation = StackOrientation.Horizontal,
						Children = { weekNumbers[i], mainCalendars[i] }
					};
				}

				if (WeekdaysShow)
				{
					var columDef = new ColumnDefinition { Width = 48 };
					var dl = new Grid { VerticalOptions = LayoutOptions.CenterAndExpand, RowSpacing = 0, ColumnSpacing = 0, Padding = 0};
					dl.ColumnDefinitions = new ColumnDefinitionCollection { columDef, columDef, columDef, columDef, columDef, columDef, columDef };
                    var marginFront = NumberOfWeekFontSize * 1.5;
                    // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                    if (Device.RuntimePlatform == Device.UWP) marginFront = NumberOfWeekFontSize * 3;
                    if (ShowNumberOfWeek) dl.Padding = new Thickness(marginFront, 0, 0, 0);

                    for (var c = 0; c < 7; c++)
					{
                        dayLabels.Add(new Label
                        {
                            HeightRequest = 48,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
							BackgroundColor = WeekdaysBackgroundColor,
							TextColor = WeekdaysTextColor,
							FontSize = WeekdaysFontSize,
							FontFamily = WeekdaysFontFamily,
							FontAttributes = WeekdaysFontAttributes
						});
						dl.Add(dayLabels.Last(), c, 0);
					}

					var stack = new StackLayout
					{
						Padding = 0,
						Spacing = 0,
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.Center,
						Orientation = StackOrientation.Vertical,
						Children = { dl, main }
					};
					contentView.Add(stack);
				}
				else
				{
					contentView.Add(main);
				}
			}
		}
	}
}
