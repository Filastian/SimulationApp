﻿using SimulationApp.Core.Models.Enums;
using System.ComponentModel;

namespace SimulationApp.Core.Models
{
    public class Cell : INotifyPropertyChanged
    {
        public CellState State { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
