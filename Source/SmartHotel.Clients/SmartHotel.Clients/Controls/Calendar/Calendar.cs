﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
    public partial class Calendar : ContentView
    {
        List<CalendarButton> buttons;
        List<Grid> mainCalendars;
        List<Label> titleLabels;
        StackLayout mainView, contentView;
        public static double GridSpace = 0;

        public Calendar()
        {
            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            TitleLeftArrow = new CalendarButton
            {
                FontAttributes = FontAttributes.None,
                BackgroundColor = Colors.Transparent,
                BackgroundImage = FileImageSource.FromFile((Device.RuntimePlatform == Device.UWP) ? "Assets/ic_arrow_left_normal.png" : "ic_arrow_left_normal") as FileImageSource,
                HeightRequest = 48,
                WidthRequest = 48,
                Margin = new Thickness(24, 0, 0, 0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };

            TitleLabel = new Label
            {
                FontSize = 24,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.None,
                TextColor = Colors.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = string.Empty,
                LineBreakMode = LineBreakMode.NoWrap
            };

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            TitleRightArrow = new CalendarButton
            {
                FontAttributes = FontAttributes.None,
                BackgroundColor = Colors.Transparent,
                HeightRequest = 48,
                WidthRequest = 48,
                Margin = new Thickness(0, 0, 24, 0),
                BackgroundImage = FileImageSource.FromFile((Device.RuntimePlatform == Device.UWP) ? "Assets/ic_arrow_right_normal.png" : "ic_arrow_right_normal") as FileImageSource,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };

            MonthNavigationLayout = new StackLayout
            {
                Padding = 0,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 50,
                Children = { TitleLeftArrow, TitleLabel, TitleRightArrow }
            };

            contentView = new StackLayout
            {
                Padding = 0,
                Orientation = StackOrientation.Vertical
            };

            mainView = new StackLayout
            {
                Padding = 0,
                Orientation = StackOrientation.Vertical,
                Children = { MonthNavigationLayout, contentView }
            };

            TitleLeftArrow.Clicked += LeftArrowClickedEvent;
            TitleRightArrow.Clicked += RightArrowClickedEvent;
            dayLabels = new List<Label>(7);
            weekNumberLabels = new List<Label>(6);
            buttons = new List<CalendarButton>(42);
            mainCalendars = new List<Grid>(1);
            weekNumbers = new List<Grid>(1);

            CalendarViewType = DateTypeEnum.Normal;
            YearsRow = 4;
            YearsColumn = 4;
        }

        #region MinDate

        public static readonly BindableProperty MinDateProperty =
            BindableProperty.Create(nameof(MinDate), typeof(DateTime?), typeof(Calendar), null,
                                    propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.MaxMin));

        /// <summary>
        /// Gets or sets the minimum date.
        /// </summary>
        /// <value>The minimum date.</value>
        public DateTime? MinDate
        {
            get => (DateTime?)GetValue(MinDateProperty);
            set { SetValue(MinDateProperty, value); ChangeCalendar(CalandarChanges.MaxMin); }
        }

        #endregion

        #region MaxDate

        public static readonly BindableProperty MaxDateProperty =
            BindableProperty.Create(nameof(MaxDate), typeof(DateTime?), typeof(Calendar), null,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.MaxMin));

        /// <summary>
        /// Gets or sets the max date.
        /// </summary>
        /// <value>The max date.</value>
        public DateTime? MaxDate
        {
            get => (DateTime?)GetValue(MaxDateProperty);
            set => SetValue(MaxDateProperty, value);
        }

        #endregion

        #region StartDate

        public static readonly BindableProperty StartDateProperty =
            BindableProperty.Create(nameof(StartDate), typeof(DateTime), typeof(Calendar), DateTime.Now,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.StartDate));

        /// <summary>
        /// Gets or sets a date, to pick the month, the calendar is focused on
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get => (DateTime)GetValue(StartDateProperty);
            set => SetValue(StartDateProperty, value);
        }

        #endregion

        #region StartDay

        public static readonly BindableProperty StartDayProperty =
            BindableProperty.Create(nameof(StartDate), typeof(DayOfWeek), typeof(Calendar), DayOfWeek.Sunday,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.StartDay));

        /// <summary>
        /// Gets or sets the day the calendar starts the week with.
        /// </summary>
        /// <value>The start day.</value>
        public DayOfWeek StartDay
        {
            get => (DayOfWeek)GetValue(StartDayProperty);
            set => SetValue(StartDayProperty, value);
        }

        #endregion

        #region BorderWidth

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(Calendar), // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
Device.RuntimePlatform == Device.iOS ? 1 : 3,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeBorderWidth((int)newValue, (int)oldValue));

        protected void ChangeBorderWidth(int newValue, int oldValue)
        {
            if (newValue == oldValue) return;
            buttons.FindAll(b => !b.IsSelected && b.IsEnabled).ForEach(b => b.BorderWidth = newValue);
        }

        /// <summary>
        /// Gets or sets the border width of the calendar.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        #endregion

        #region OuterBorderWidth

        public static readonly BindableProperty OuterBorderWidthProperty =
            BindableProperty.Create(nameof(OuterBorderWidth), typeof(int), typeof(Calendar), // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
Device.RuntimePlatform == Device.iOS ? 1 : 3,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).mainCalendars.ForEach((obj) => obj.Padding = (int)newValue));

        /// <summary>
        /// Gets or sets the width of the whole calandar border.
        /// </summary>
        /// <value>The width of the outer border.</value>
        public int OuterBorderWidth
        {
            get => (int)GetValue(OuterBorderWidthProperty);
            set => SetValue(OuterBorderWidthProperty, value);
        }

        #endregion

        #region BorderColor

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(Calendar), Color.FromArgb("#dddddd"),
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeBorderColor((Color)newValue, (Color)oldValue));

        protected void ChangeBorderColor(Color newValue, Color oldValue)
        {
            if (newValue == oldValue) return;
            mainCalendars.ForEach((obj) => obj.BackgroundColor = newValue);
            buttons.FindAll(b => b.IsEnabled && !b.IsSelected).ForEach(b => b.BorderColor = newValue);
        }

        /// <summary>
        /// Gets or sets the border color of the calendar.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        #endregion

        #region DatesBackgroundColor

        public static readonly BindableProperty DatesBackgroundColorProperty =
            BindableProperty.Create(nameof(DatesBackgroundColor), typeof(Color), typeof(Calendar), Colors.White,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeDatesBackgroundColor((Color)newValue, (Color)oldValue));

        protected void ChangeDatesBackgroundColor(Color newValue, Color oldValue)
        {
            if (newValue == oldValue) return;
            buttons.FindAll(b => b.IsEnabled && (!b.IsSelected || SelectedBackgroundColor != null)).ForEach(b => b.BackgroundColor = newValue);
        }

        /// <summary>
        /// Gets or sets the background color of the normal dates.
        /// </summary>
        /// <value>The color of the dates background.</value>
        public Color DatesBackgroundColor
        {
            get => (Color)GetValue(DatesBackgroundColorProperty);
            set => SetValue(DatesBackgroundColorProperty, value);
        }

        #endregion

        #region DatesTextColor

        public static readonly BindableProperty DatesTextColorProperty =
            BindableProperty.Create(nameof(DatesTextColor), typeof(Color), typeof(Calendar), Colors.Black,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeDatesTextColor((Color)newValue, (Color)oldValue));

        protected void ChangeDatesTextColor(Color newValue, Color oldValue)
        {
            if (newValue == oldValue) return;
            buttons.FindAll(b => b.IsEnabled && (!b.IsSelected || SelectedTextColor != null) && !b.IsOutOfMonth).ForEach(b => b.TextColor = newValue);
        }

        /// <summary>
        /// Gets or sets the text color of the normal dates.
        /// </summary>
        /// <value>The color of the dates text.</value>
        public Color DatesTextColor
        {
            get => (Color)GetValue(DatesTextColorProperty);
            set => SetValue(DatesTextColorProperty, value);
        }

        #endregion

        #region DatesFontAttributes

        public static readonly BindableProperty DatesFontAttributesProperty =
            BindableProperty.Create(nameof(DatesFontAttributes), typeof(FontAttributes), typeof(Calendar), FontAttributes.None,     
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeDatesFontAttributes((FontAttributes)newValue, (FontAttributes)oldValue));

        protected void ChangeDatesFontAttributes(FontAttributes newValue, FontAttributes oldValue)
        {
            if (newValue == oldValue) return;
            buttons.FindAll(b => b.IsEnabled && (!b.IsSelected || SelectedTextColor != null) && !b.IsOutOfMonth).ForEach(b => b.FontAttributes = newValue);
        }

        /// <summary>
        /// Gets or sets the dates font attributes.
        /// </summary>
        /// <value>The dates font attributes.</value>
        public FontAttributes DatesFontAttributes
        {
            get => (FontAttributes)GetValue(DatesFontAttributesProperty);
            set => SetValue(DatesFontAttributesProperty, value);
        }

        #endregion

        #region DatesFontSize

        public static readonly BindableProperty DatesFontSizeProperty =
            BindableProperty.Create(nameof(DatesFontSize), typeof(double), typeof(Calendar), 20.0,      
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeDatesFontSize((double)newValue, (double)oldValue));

        protected void ChangeDatesFontSize(double newValue, double oldValue)
        {
            if (Math.Abs(newValue - oldValue) < 0.01) return;
            buttons?.FindAll(b => !b.IsSelected && b.IsEnabled).ForEach(b => b.FontSize = newValue);
        }

        /// <summary>
        /// Gets or sets the font size of the normal dates.
        /// </summary>
        /// <value>The size of the dates font.</value>
        public double DatesFontSize
        {
            get => (double)GetValue(DatesFontSizeProperty);
            set => SetValue(DatesFontSizeProperty, value);
        }

        #endregion

        #region DatesFontFamily

        public static readonly BindableProperty DatesFontFamilyProperty =
                    BindableProperty.Create(nameof(DatesFontFamily), typeof(string), typeof(Calendar), default(string), 
                        propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeDatesFontFamily((string)newValue, (string)oldValue));

        protected void ChangeDatesFontFamily(string newValue, string oldValue)
        {
            if (newValue == oldValue) return;
            buttons?.FindAll(b => !b.IsSelected && b.IsEnabled).ForEach(b => b.FontFamily = newValue);
        }

        /// <summary>
        /// Gets or sets the font family of dates.
        /// </summary>
        public string DatesFontFamily
        {
            get => GetValue(DatesFontFamilyProperty) as string;
            set => SetValue(DatesFontFamilyProperty, value);
        }

        #endregion

        #region ShowNumOfMonths

        public static readonly BindableProperty ShowNumOfMonthsProperty =
            BindableProperty.Create(nameof(ShowNumOfMonths), typeof(int), typeof(Calendar), 1,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.All));

        /// <summary>
        /// Gets or sets a the number of months to show
        /// </summary>
        /// <value>The start date.</value>
        public int ShowNumOfMonths
        {
            get => (int)GetValue(ShowNumOfMonthsProperty);
            set => SetValue(ShowNumOfMonthsProperty, value);
        }

        #endregion

        #region ShowInBetweenMonthLabels

        public static readonly BindableProperty ShowInBetweenMonthLabelsProperty =
            BindableProperty.Create(nameof(ShowInBetweenMonthLabels), typeof(bool), typeof(Calendar), true,
                                    propertyChanged: (bindable, oldValue, newValue) => (bindable as Calendar).ChangeCalendar(CalandarChanges.All));

        /// <summary>
        /// Gets or sets a the number of months to show
        /// </summary>
        /// <value>The start date.</value>
        public bool ShowInBetweenMonthLabels
        {
            get => (bool)GetValue(ShowInBetweenMonthLabelsProperty);
            set => SetValue(ShowInBetweenMonthLabelsProperty, value);
        }

        #endregion

        #region DateCommand

        public static readonly BindableProperty DateCommandProperty =
            BindableProperty.Create(nameof(DateCommand), typeof(ICommand), typeof(Calendar), null);

        /// <summary>
        /// Gets or sets the selected date command.
        /// </summary>
        /// <value>The date command.</value>
        public ICommand DateCommand
        {
            get => (ICommand)GetValue(DateCommandProperty);
            set => SetValue(DateCommandProperty, value);
        }

        #endregion

        public DateTime CalendarStartDate(DateTime date)
        {
            var start = date;
            var beginOfMonth = start.Day == 1;
            while (!beginOfMonth || start.DayOfWeek != StartDay)
            {
                start = start.AddDays(-1);
                beginOfMonth |= start.Day == 1;
            }
            return start;
        }

        #region Functions

        protected override void OnParentSet()
        {
            FillCalendarWindows();
            base.OnParentSet();
            ChangeCalendar(CalandarChanges.All);
        }

        protected Task FillCalendar() => Task.Factory.StartNew(() =>
                                                   {
                                                       FillCalendarWindows();
                                                   });

        protected void FillCalendarWindows()
        {
            CreateWeeknumbers();
            CreateButtons();
            ShowHideElements();
        }

        protected void CreateWeeknumbers()
        {
            weekNumberLabels.Clear();
            weekNumbers.Clear();
            if (!ShowNumberOfWeek) return;

            for (var i = 0; i < ShowNumOfMonths; i++)
            {
                var columDef = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                var rowDef = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                var weekNumbers = new Grid { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.Start, RowSpacing = 0, ColumnSpacing = 0, Padding = new Thickness(0, 0, 0, 0) };
                weekNumbers.ColumnDefinitions = new ColumnDefinitionCollection { columDef };
                weekNumbers.RowDefinitions = new RowDefinitionCollection { rowDef, rowDef, rowDef, rowDef, rowDef, rowDef };
                // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                weekNumbers.WidthRequest = NumberOfWeekFontSize * (Device.RuntimePlatform == Device.iOS ? 1.5 : 2.5);

                for (var r = 0; r < 6; r++)
                {

                    weekNumberLabels.Add(new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        TextColor = NumberOfWeekTextColor,
                        BackgroundColor = NumberOfWeekBackgroundColor,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = NumberOfWeekFontSize,
                        FontAttributes = NumberOfWeekFontAttributes,
                        FontFamily = NumberOfWeekFontFamily
                    });

                    weekNumbers.Add(weekNumberLabels.Last(), 0, r);
                }
                this.weekNumbers.Add(weekNumbers);
            }
        }

        protected void CreateButtons()
        {
            var columDef = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
            var rowDef = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };
            buttons.Clear();
            mainCalendars.Clear();

            for (var i = 0; i < ShowNumOfMonths; i++)
            {
                var mainCalendar = new Grid { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand, RowSpacing = GridSpace, ColumnSpacing = GridSpace, Padding = 1, BackgroundColor = BorderColor };
                mainCalendar.ColumnDefinitions = new ColumnDefinitionCollection { columDef, columDef, columDef, columDef, columDef, columDef, columDef };
                mainCalendar.RowDefinitions = new RowDefinitionCollection { rowDef, rowDef, rowDef, rowDef, rowDef, rowDef };

                for (var r = 0; r < 5; r++)
                {
                    for (var c = 0; c < 7; c++)
                    {
                        buttons.Add(new CalendarButton
                        {
                            CornerRadius = 0,
                            BorderWidth = BorderWidth,
                            BorderColor = BorderColor,
                            FontSize = DatesFontSize,
                            BackgroundColor = DatesBackgroundColor,
                            TextColor = DatesTextColor,
                            FontAttributes = DatesFontAttributes,
                            FontFamily = DatesFontFamily,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        });

                        var b = buttons.Last();
                        b.Clicked += DateClickedEvent;
                        mainCalendar.Add(b, c, r);
                    }
                }
                mainCalendars.Add(mainCalendar);
            }
        }

        public void ForceRedraw() => ChangeCalendar(CalandarChanges.All);

        protected void ChangeCalendar(CalandarChanges changes) => Device.BeginInvokeOnMainThread(() =>
        {
            Content = null;
            if (changes.HasFlag(CalandarChanges.StartDate))
            {
                TitleLabel.Text = StartDate.ToString(TitleLabelFormat);
                if (titleLabels != null)
                {
                    var tls = StartDate.AddMonths(1);
                    foreach (var tl in titleLabels)
                    {
                        (tl as Label).Text = tls.ToString(TitleLabelFormat);
                        tls = tls.AddMonths(1);
                    }
                }
            }

            var start = CalendarStartDate(StartDate).Date;
            var beginOfMonth = false;
            var endOfMonth = false;
            for (var i = 0; i < buttons.Count; i++)
            {
                endOfMonth |= beginOfMonth && start.Day == 1;
                beginOfMonth |= start.Day == 1;

                if (i < dayLabels.Count && WeekdaysShow && changes.HasFlag(CalandarChanges.StartDay))
                {
                    var day = start.ToString(WeekdaysFormat);
                    var showDay = char.ToUpper(day.First()) + day.Substring(1).ToLower();
                    dayLabels[i].Text = showDay;
                }

                ChangeWeekNumbers(start, i);

                if (changes.HasFlag(CalandarChanges.All))
                {
                    buttons[i].Text = string.Format("{0}", start.Day);
                }
                else
                {
                    buttons[i].TextWithoutMeasure = string.Format("{0}", start.Day);
                }
                buttons[i].Date = start;

                buttons[i].IsOutOfMonth = !(beginOfMonth && !endOfMonth);
                buttons[i].IsEnabled = ShowNumOfMonths == 1 || !buttons[i].IsOutOfMonth;

                SpecialDate sd = null;
                if (SpecialDates != null)
                {
                    sd = SpecialDates.FirstOrDefault(s => s.Date.Date == start.Date);
                }

                SetButtonNormal(buttons[i]);

                if ((MinDate.HasValue && start.Date < MinDate) || (MaxDate.HasValue && start.Date > MaxDate) || (DisableAllDates && sd == null))
                {
                    SetButtonDisabled(buttons[i]);
                }
                else if (buttons[i].IsEnabled && (SelectedDates?.Select(d => d.Date)?.Contains(start.Date) ?? false))
                {
                    SetButtonSelected(buttons[i], sd);
                }
                else if (sd != null)
                {
                    SetButtonSpecial(buttons[i], sd);
                }

                start = start.AddDays(1);
                if (i != 0 && (i + 1) % 42 == 0)
                {
                    beginOfMonth = false;
                    endOfMonth = false;
                    start = CalendarStartDate(start);
                }

            }
            if (DisableDatesLimitToMaxMinRange)
            {
                TitleLeftArrow.IsEnabled = !(MinDate.HasValue && CalendarStartDate(StartDate).Date < MinDate);
                TitleRightArrow.IsEnabled = !(MaxDate.HasValue && start > MaxDate);
            }
            Content = mainView;
        });

        protected void SetButtonNormal(CalendarButton button)
        {
            button.BackgroundPattern = null;
            button.BackgroundImage = null;

            Device.BeginInvokeOnMainThread(() =>
            {
                button.IsEnabled = true;
                button.IsSelected = false;
                button.FontSize = DatesFontSize;
                button.BorderWidth = BorderWidth;
                button.BorderColor = BorderColor;
                button.FontFamily = button.IsOutOfMonth ? DatesFontFamilyOutsideMonth : DatesFontFamily;
                button.BackgroundColor = button.IsOutOfMonth ? DatesBackgroundColorOutsideMonth : DatesBackgroundColor;
                button.TextColor = button.IsOutOfMonth ? DatesTextColorOutsideMonth : DatesTextColor;
                button.FontAttributes = button.IsOutOfMonth ? DatesFontAttributesOutsideMonth : DatesFontAttributes;
                button.IsEnabled = ShowNumOfMonths == 1 || !button.IsOutOfMonth;
            });
        }

        protected void DateClickedEvent(object s, EventArgs a)
        {
            var selectedDate = (s as CalendarButton).Date;
            if (SelectedDate.HasValue && selectedDate.HasValue && SelectedDate.Value == selectedDate.Value)
            {
                ChangeSelectedDate(selectedDate);
                SelectedDate = null;
            }
            else
            {
                SelectedDate = selectedDate;
            }
        }

        #endregion

        public event EventHandler<DateTimeEventArgs> DateClicked;
    }
}