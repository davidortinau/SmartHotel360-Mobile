﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
    public partial class Calendar : ContentView
    {

        #region SpecialDates

        public static readonly BindableProperty SpecialDatesProperty =
            BindableProperty.Create(nameof(SpecialDates), typeof(IEnumerable<SpecialDate>), typeof(Calendar), null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (oldValue != null)
                    {
                        if (oldValue is INotifyCollectionChanged observableCollection)
                        {
                            observableCollection.CollectionChanged -= (s, e) =>
                            {
                                var newItems = e.NewItems;
                                if (newItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        var buttons = (bindable as Calendar).buttons;
                                        var button = buttons.FirstOrDefault(d => d.Date.Value.Date == sd.Date.Date);
                                        (bindable as Calendar).SetButtonSpecial(button, sd);
                                    }
                                }

                                var oldItems = e.OldItems;
                                if (oldItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        (bindable as Calendar).ResetButton((bindable as Calendar).buttons.FirstOrDefault(d => d.Date.Value == sd.Date));
                                    }
                                }
                            };
                        }
                    }
                    if (newValue != null)
                    {
                        if (newValue is INotifyCollectionChanged observableCollection)
                        {
                            observableCollection.CollectionChanged += (s, e) =>
                            {
                                var newItems = e.NewItems;
                                if (newItems != null)
                                {
                                    foreach (SpecialDate sd in newItems)
                                    {
                                        var buttons = (bindable as Calendar).buttons;
                                        var button = buttons.Where(d => d.Date.HasValue).FirstOrDefault(d => d.Date.Value.Date == sd.Date.Date);
                                        (bindable as Calendar).SetButtonSpecial(button, sd);
                                    }
                                }

                                var oldItems = e.OldItems;
                                if (oldItems != null)
                                {
                                    foreach (SpecialDate sd in oldItems)
                                    {
                                        (bindable as Calendar).ResetButton((bindable as Calendar).buttons.FirstOrDefault(d => d.Date.Value == sd.Date));
                                    }
                                }
                            };
                        }
                    }
                });

        public IEnumerable<SpecialDate> SpecialDates
        {
            get => (IEnumerable<SpecialDate>)GetValue(SpecialDatesProperty);
            set => SetValue(SpecialDatesProperty, value);
        }

        #endregion

        public void RaiseSpecialDatesChanged() => ChangeCalendar(CalandarChanges.MaxMin);

        protected void SetButtonSpecial(CalendarButton button, SpecialDate special)
        {
            if (button != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    button.BackgroundPattern = special.BackgroundPattern;
                    button.BackgroundImage = special.BackgroundImage;
                    if (special.FontSize.HasValue) button.FontSize = special.FontSize.Value;
                    if (special.BorderWidth.HasValue) button.BorderWidth = special.BorderWidth.Value;
                    if (special.BorderColor != null) button.BorderColor = special.BorderColor;
                    if (special.BackgroundColor != null) button.BackgroundColor = special.BackgroundColor;
                    if (special.TextColor != null) button.TextColor = special.TextColor;
                    if (special.FontAttributes.HasValue) button.FontAttributes = special.FontAttributes.Value;
                    if (!string.IsNullOrEmpty(special.FontFamily)) button.FontFamily = special.FontFamily;
                    button.IsEnabled = special.Selectable;
                });
            }
        }
    }
}
