﻿using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
	public partial class Calendar : ContentView
	{
		#region TitleLabel

		public static readonly BindableProperty TitleLabelHorizontalTextAlignmentProperty = BindableProperty.Create(nameof(TitleLabelHorizontalTextAlignment), typeof(TextAlignment), typeof(Calendar), default(TextAlignment),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				(bindable as Calendar).TitleLabel.HorizontalTextAlignment = (TextAlignment)newValue;
				(bindable as Calendar).titleLabels?.ForEach(l => l.HorizontalTextAlignment = (TextAlignment)newValue);
			});

		public TextAlignment TitleLabelHorizontalTextAlignment
        {
            get => TitleLabel.HorizontalTextAlignment;
            set => TitleLabel.HorizontalTextAlignment = value;
        }

        public static readonly BindableProperty TitleLabelVerticalTextAlignmentProperty = BindableProperty.Create(nameof(TitleLabelVerticalTextAlignment), typeof(TextAlignment), typeof(Calendar), default(TextAlignment),
		    propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.VerticalTextAlignment = (TextAlignment)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.VerticalTextAlignment = (TextAlignment)newValue);
		});

		public TextAlignment TitleLabelVerticalTextAlignment
        {
            get => TitleLabel.VerticalTextAlignment;
            set => TitleLabel.VerticalTextAlignment = value;
        }

        public static readonly BindableProperty TitleLabelTextColorProperty = BindableProperty.Create(nameof(TitleLabelTextColor), typeof(Color), typeof(Calendar), default(Color),
			  propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.TextColor = (Color)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.TextColor = (Color)newValue);
		});

		public Color TitleLabelTextColor
        {
            get => TitleLabel.TextColor;
            set => TitleLabel.TextColor = value;
        }

        public static readonly BindableProperty TitleLabelTextProperty = BindableProperty.Create(nameof(TitleLabelText), typeof(String), typeof(Calendar), default(String),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLabel.Text = (String)newValue);

		public string TitleLabelText
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        public static readonly BindableProperty TitleLabelFontFamilyProperty = BindableProperty.Create(nameof(TitleLabelFontFamily), typeof(String), typeof(Calendar), default(String),
		   propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.FontFamily = (String)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.FontFamily = (String)newValue);
		});

		public string TitleLabelFontFamily
        {
            get => TitleLabel.FontFamily;
            set => TitleLabel.FontFamily = value;
        }

        public static readonly BindableProperty TitleLabelFontSizeProperty = BindableProperty.Create(nameof(TitleLabelFontSize), typeof(Double), typeof(Calendar), default(Double),
			propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.FontSize = (Double)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.FontSize = (Double)newValue);
		});

		public double TitleLabelFontSize
        {
            get => TitleLabel.FontSize;
            set => TitleLabel.FontSize = value;
        }

        public static readonly BindableProperty TitleLabelFontAttributesProperty = BindableProperty.Create(nameof(TitleLabelFontAttributes), typeof(FontAttributes), typeof(Calendar), default(FontAttributes),
		   propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.FontAttributes = (FontAttributes)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.FontAttributes = (FontAttributes)newValue);
		});

		public FontAttributes TitleLabelFontAttributes
        {
            get => TitleLabel.FontAttributes;
            set => TitleLabel.FontAttributes = value;
        }

        public static readonly BindableProperty TitleLabelFormattedTextProperty = BindableProperty.Create(nameof(TitleLabelFormattedText), typeof(FormattedString), typeof(Calendar), default(FormattedString),
		  propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.FormattedText = (FormattedString)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.FormattedText = (FormattedString)newValue);
		});

		public FormattedString TitleLabelFormattedText
        {
            get => TitleLabel.FormattedText;
            set => TitleLabel.FormattedText = value;
        }

        public static readonly BindableProperty TitleLabelLineBreakModeProperty = BindableProperty.Create(nameof(TitleLabelLineBreakMode), typeof(LineBreakMode), typeof(Calendar), default(LineBreakMode),
		  propertyChanged: (bindable, oldValue, newValue) => {
			(bindable as Calendar).TitleLabel.LineBreakMode = (LineBreakMode)newValue;
			(bindable as Calendar).titleLabels?.ForEach(l => l.LineBreakMode = (LineBreakMode)newValue);
		});

		public LineBreakMode TitleLabelLineBreakMode
        {
            get => TitleLabel.LineBreakMode;
            set => TitleLabel.LineBreakMode = value;
        }

        /// <summary>
        /// Gets the title label in the month navigation.
        /// </summary>
        public Label TitleLabel { get; protected set; }

		#endregion
		
		#region TitleLeftArrow

		public static readonly BindableProperty TitleLeftArrowTextProperty = BindableProperty.Create(nameof(TitleLeftArrowText), typeof(String), typeof(Calendar), default(String),	
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.Text = (String)newValue);

		public string TitleLeftArrowText
        {
            get => TitleLeftArrow.Text;
            set => TitleLeftArrow.Text = value;
        }

        public static readonly BindableProperty TitleLeftArrowTextColorProperty = BindableProperty.Create(nameof(TitleLeftArrowTextColor), typeof(Color), typeof(Calendar), default(Color),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.TextColor = (Color)newValue);

		public Color TitleLeftArrowTextColor
        {
            get => TitleLeftArrow.TextColor;
            set => TitleLeftArrow.TextColor = value;
        }

        public static readonly BindableProperty TitleLeftArrowBackgroundColorProperty = BindableProperty.Create(nameof(TitleLeftArrowBackgroundColor), typeof(Color), typeof(Calendar), default(Color),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.BackgroundColor = (Color)newValue);

		public Color TitleLeftArrowBackgroundColor
        {
            get => TitleLeftArrow.BackgroundColor;
            set => TitleLeftArrow.BackgroundColor = value;
        }

        public static readonly BindableProperty TitleLeftArrowFontProperty = BindableProperty.Create(nameof(TitleLeftArrowFont), typeof(string), typeof(Calendar), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.FontFamily = (string)newValue);

		public string TitleLeftArrowFont
        {
            get => TitleLeftArrow.FontFamily;
            set => TitleLeftArrow.FontFamily = value;
        }

        public static readonly BindableProperty TitleLeftArrowFontFamilyProperty = BindableProperty.Create(nameof(TitleLeftArrowFontFamily), typeof(String), typeof(Calendar), default(String),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.FontFamily = (String)newValue);

		public string TitleLeftArrowFontFamily
        {
            get => TitleLeftArrow.FontFamily;
            set => TitleLeftArrow.FontFamily = value;
        }

        public static readonly BindableProperty TitleLeftArrowFontSizeProperty = BindableProperty.Create(nameof(TitleLeftArrowFontSize), typeof(Double), typeof(Calendar), default(Double),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.FontSize = (Double)newValue);

		public Double TitleLeftArrowFontSize
        {
            get => TitleLeftArrow.FontSize;
            set => TitleLeftArrow.FontSize = value;
        }

        public static readonly BindableProperty TitleLeftArrowFontAttributesProperty = BindableProperty.Create(nameof(TitleLeftArrowFontAttributes), typeof(FontAttributes), typeof(Calendar), default(FontAttributes),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.FontAttributes = (FontAttributes)newValue);

		public FontAttributes TitleLeftArrowFontAttributes
        {
            get => TitleLeftArrow.FontAttributes;
            set => TitleLeftArrow.FontAttributes = value;
        }

        public static readonly BindableProperty TitleLeftArrowBorderWidthProperty = BindableProperty.Create(nameof(TitleLeftArrowBorderWidth), typeof(Double), typeof(Calendar), default(Double),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.BorderWidth = (Double)newValue);

		public double TitleLeftArrowBorderWidth
        {
            get => TitleLeftArrow.BorderWidth;
            set => TitleLeftArrow.BorderWidth = value;
        }

        public static readonly BindableProperty TitleLeftArrowBorderColorProperty = BindableProperty.Create(nameof(TitleLeftArrowBorderColor), typeof(Color), typeof(Calendar), default(Color),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.BorderColor = (Color)newValue);

		public Color TitleLeftArrowBorderColor
        {
            get => TitleLeftArrow.BorderColor;
            set => TitleLeftArrow.BorderColor = value;
        }

        public static readonly BindableProperty TitleLeftArrowCornerRadiusProperty = BindableProperty.Create(nameof(TitleLeftArrowCornerRadius), typeof(Int32), typeof(Calendar), default(Int32),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.CornerRadius = (Int32)newValue);

		public int TitleLeftArrowCornerRadius
        {
            get => TitleLeftArrow.CornerRadius;
            set => TitleLeftArrow.CornerRadius = value;
        }

        public static readonly BindableProperty TitleLeftArrowImageProperty = BindableProperty.Create(nameof(TitleLeftArrowImage), typeof(FileImageSource), typeof(Calendar), default(FileImageSource),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.ImageSource = (FileImageSource)newValue);

		public FileImageSource TitleLeftArrowImage
        {
            get => (FileImageSource)TitleLeftArrow.ImageSource;
            set => TitleLeftArrow.ImageSource = value;
        }

        public static readonly BindableProperty TitleLeftArrowIsEnabledCoreProperty = BindableProperty.Create(nameof(TitleLeftArrowIsEnabled), typeof(Boolean), typeof(Calendar), default(Boolean),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.IsEnabled = (Boolean)newValue);

		public bool TitleLeftArrowIsEnabled
        {
            get => TitleLeftArrow.IsEnabled;
            set => TitleLeftArrow.IsEnabled = value;
        }

        public static readonly BindableProperty TitleLeftArrowIsVisibleCoreProperty = BindableProperty.Create(nameof(TitleLeftArrowIsVisible), typeof(Boolean), typeof(Calendar), default(Boolean),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLeftArrow.IsVisible = (Boolean)newValue);

		public bool TitleLeftArrowIsVisible
        {
            get => TitleLeftArrow.IsVisible;
            set => TitleLeftArrow.IsVisible = value;
        }

        /// <summary>
        /// Gets the left button of the month navigation.
        /// </summary>
        public CalendarButton TitleLeftArrow { get; protected set; }
		
		#endregion
		
		#region TitleRightArrow

		public static readonly BindableProperty TitleRightArrowTextProperty = BindableProperty.Create(nameof(TitleRightArrowText), typeof(String), typeof(Calendar), default(String),
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.Text = (String)newValue);

		public string TitleRightArrowText
        {
            get => TitleRightArrow.Text;
            set => TitleRightArrow.Text = value;
        }

        public static readonly BindableProperty TitleRightArrowTextColorProperty = BindableProperty.Create(nameof(TitleRightArrowTextColor), typeof(Color), typeof(Calendar), default(Color),	
            propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.TextColor = (Color)newValue);

		public Color TitleRightArrowTextColor
        {
            get => TitleRightArrow.TextColor;
            set => TitleRightArrow.TextColor = value;
        }

        public static readonly BindableProperty TitleRightArrowBackgroundColorProperty = BindableProperty.Create(nameof(TitleRightArrowBackgroundColor), typeof(Color), typeof(Calendar), default(Color),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.BackgroundColor = (Color)newValue);

		public Color TitleRightArrowBackgroundColor
        {
            get => TitleRightArrow.BackgroundColor;
            set => TitleRightArrow.BackgroundColor = value;
        }

        public static readonly BindableProperty TitleRightArrowFontProperty = BindableProperty.Create(nameof(TitleRightArrowFont), typeof(string), typeof(Calendar), string.Empty,
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.FontFamily = (string)newValue);

		public string TitleRightArrowFont
        {
            get => (string)TitleRightArrow.FontFamily;
            set => TitleRightArrow.FontFamily = value;
        }

        public static readonly BindableProperty TitleRightArrowFontFamilyProperty = BindableProperty.Create(nameof(TitleRightArrowFontFamily), typeof(String), typeof(Calendar), default(String),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.FontFamily = (String)newValue);

		public string TitleRightArrowFontFamily
        {
            get => TitleRightArrow.FontFamily;
            set => TitleRightArrow.FontFamily = value;
        }

        public static readonly BindableProperty TitleRightArrowFontSizeProperty = BindableProperty.Create(nameof(TitleRightArrowFontSize), typeof(Double), typeof(Calendar), default(Double),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.FontSize = (Double)newValue);

		public double TitleRightArrowFontSize
        {
            get => TitleRightArrow.FontSize;
            set => TitleRightArrow.FontSize = value;
        }

        public static readonly BindableProperty TitleRightArrowFontAttributesProperty = BindableProperty.Create(nameof(TitleRightArrowFontAttributes), typeof(FontAttributes), typeof(Calendar), default(FontAttributes),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.FontAttributes = (FontAttributes)newValue);

		public FontAttributes TitleRightArrowFontAttributes
        {
            get => TitleRightArrow.FontAttributes;
            set => TitleRightArrow.FontAttributes = value;
        }

        public static readonly BindableProperty TitleRightArrowBorderWidthProperty = BindableProperty.Create(nameof(TitleRightArrowBorderWidth), typeof(Double), typeof(Calendar), default(Double),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.BorderWidth = (Double)newValue);

		public double TitleRightArrowBorderWidth
        {
            get => TitleRightArrow.BorderWidth;
            set => TitleRightArrow.BorderWidth = value;
        }

        public static readonly BindableProperty TitleRightArrowBorderColorProperty = BindableProperty.Create(nameof(TitleRightArrowBorderColor), typeof(Color), typeof(Calendar), default(Color),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.BorderColor = (Color)newValue);

		public Color TitleRightArrowBorderColor
        {
            get => TitleRightArrow.BorderColor;
            set => TitleRightArrow.BorderColor = value;
        }

        public static readonly BindableProperty TitleRightArrowCornerRadiusProperty = BindableProperty.Create(nameof(TitleRightArrowCornerRadius), typeof(Int32), typeof(Calendar), default(Int32),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.CornerRadius = (Int32)newValue);

		public int TitleRightArrowCornerRadius
        {
            get => TitleRightArrow.CornerRadius;
            set => TitleRightArrow.CornerRadius = value;
        }

        public static readonly BindableProperty TitleRightArrowImageProperty = BindableProperty.Create(nameof(TitleRightArrowImage), typeof(FileImageSource), typeof(Calendar), default(FileImageSource),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.ImageSource = (FileImageSource)newValue);

		public FileImageSource TitleRightArrowImage
        {
            get => (FileImageSource)TitleRightArrow.ImageSource;
            set => TitleRightArrow.ImageSource = value;
        }

        public static readonly BindableProperty TitleRightArrowIsEnabledCoreProperty = BindableProperty.Create(nameof(TitleRightArrowIsEnabled), typeof(Boolean), typeof(Calendar), default(Boolean),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.IsEnabled = (Boolean)newValue);

		public bool TitleRightArrowIsEnabled
        {
            get => TitleRightArrow.IsEnabled;
            set => TitleRightArrow.IsEnabled = value;
        }

        public static readonly BindableProperty TitleRightArrowIsVisibleCoreProperty = BindableProperty.Create(nameof(TitleRightArrowIsVisible), typeof(Boolean), typeof(Calendar), default(Boolean),
			propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleRightArrow.IsVisible = (Boolean)newValue);

		public bool TitleRightArrowIsVisible
        {
            get => TitleRightArrow.IsVisible;
            set => TitleRightArrow.IsVisible = value;
        }

        /// <summary>
        /// Gets the right button of the month navigation.
        /// </summary>
        public CalendarButton TitleRightArrow { get; protected set; }

		#endregion

		/// <summary>
		/// Gets the right button of the month navigation.
		/// </summary>
		public StackLayout MonthNavigationLayout { get; protected set; }

		#region MonthNavigationShow

		public static readonly BindableProperty MonthNavigationShowProperty =
			BindableProperty.Create(nameof(MonthNavigationShow), typeof(bool), typeof(Calendar), true,		                        
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).MonthNavigationLayout.IsVisible = (bool)newValue);

		/// <summary>
		/// Gets or sets wether to show the month navigation.
		/// </summary>
		/// <value>The month navigation show.</value>
		public bool MonthNavigationShow
        {
            get => (bool)GetValue(MonthNavigationShowProperty);
            set => SetValue(MonthNavigationShowProperty, value);
        }

        #endregion

        #region TitleLabelFormat

        public static readonly BindableProperty TitleLabelFormatProperty =
			BindableProperty.Create(nameof(TitleLabelFormat), typeof(string), typeof(Calendar), "MMMM\nyyyy",
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).TitleLabel.Text = ((bindable as Calendar).StartDate).ToString((string)newValue));

		/// <summary>
		/// Gets or sets the format of the title in the month navigation.
		/// </summary>
		/// <value>The title label format.</value>
		public string TitleLabelFormat
        {
            get => GetValue(TitleLabelFormatProperty) as string;
            set => SetValue(TitleLabelFormatProperty, value);
        }

        #endregion

        #region EnableTitleMonthYearDetails

        public static readonly BindableProperty EnableTitleMonthYearDetailsProperty =
		BindableProperty.Create(nameof(EnableTitleMonthYearView), typeof(bool), typeof(Calendar), false,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				(bindable as Calendar).TitleLabel.GestureRecognizers.Clear();
				if (!(bool)newValue) return;
				var gr = new TapGestureRecognizer();
				gr.Tapped += (sender, e) => (bindable as Calendar).NextMonthYearView();
				(bindable as Calendar).TitleLabel.GestureRecognizers.Add(gr);
			});

		/// <summary>
		/// Gets or sets wether on Title pressed the month, year or normal view is showen
		/// </summary>
		/// <value>The weekdays show.</value>
		public bool EnableTitleMonthYearView
        {
            get => (bool)GetValue(EnableTitleMonthYearDetailsProperty);
            set => SetValue(EnableTitleMonthYearDetailsProperty, value);
        }

        #endregion

        public event EventHandler<DateTimeEventArgs> RightArrowClicked, LeftArrowClicked;

		#region RightArrowCommand

		public static readonly BindableProperty RightArrowCommandProperty =
			BindableProperty.Create(nameof(RightArrowCommand), typeof(ICommand), typeof(Calendar), null);

		public ICommand RightArrowCommand
        {
            get => (ICommand)GetValue(RightArrowCommandProperty);
            set => SetValue(RightArrowCommandProperty, value);
        }

        protected void RightArrowClickedEvent(object s, EventArgs a)
		{
			if (CalendarViewType == DateTypeEnum.Year)
			{
				NextPrevYears(true);
			}
			else 
			{
				NextMonth();
			}

			RightArrowClicked?.Invoke(s, new DateTimeEventArgs { DateTime = StartDate });
			RightArrowCommand?.Execute(StartDate);
		}

        public void NextMonth() => StartDate = new DateTime(StartDate.Year, StartDate.Month, 1).AddMonths(ShowNumOfMonths);

        #endregion

        #region LeftArrowCommand

        public static readonly BindableProperty LeftArrowCommandProperty =
			BindableProperty.Create(nameof(LeftArrowCommand), typeof(ICommand), typeof(Calendar), null);

		public ICommand LeftArrowCommand
        {
            get => (ICommand)GetValue(LeftArrowCommandProperty);
            set => SetValue(LeftArrowCommandProperty, value);
        }

        protected void LeftArrowClickedEvent(object s, EventArgs a)
		{
			if (CalendarViewType == DateTypeEnum.Year)
			{
				NextPrevYears(false);
			}
			else
			{
				PreviousMonth();
			}
			LeftArrowClicked?.Invoke(s, new DateTimeEventArgs { DateTime = StartDate });
			LeftArrowCommand?.Execute(StartDate);
		}

        public void PreviousMonth() => StartDate = new DateTime(StartDate.Year, StartDate.Month, 1).AddMonths(-ShowNumOfMonths);
        
        #endregion
    }
}
