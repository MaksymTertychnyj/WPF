﻿using Figure.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Figure.Helper
{
    public class TranslatConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string? nameTargetObject = values[0]?.ToString();
            ResourceDictionary? windowResources = values[1] is MainViewModel viewModel ?
                viewModel.LocalizationProvider.MainWindowResources
                : null;

            return (windowResources != null) && (nameTargetObject != null) ? windowResources[nameTargetObject] : "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
