using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class InformationVM
    {
        public List<string> Origins { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> MeasurementUnits { get; set; }
    }
}
