using MvvmCross.Converters;
using MvvmCross.Platforms.Wpf.Converters;
using SimulationApp.Core.Models.Enums;
using System;
using System.Globalization;

namespace SimulationApp.WPF.Converters
{
    public class StateToColorConverter : MvxValueConverter<CellState, string>
    {
        protected override string Convert(CellState value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value)
            {
                case CellState.Default:
                    return "Black";
                case CellState.Entity:
                    return "Red";
                default:
                    return null;
            }
        }
    }

    public class TheNativeStateToColorConverter
    : MvxNativeValueConverter<StateToColorConverter>
    { }
}
