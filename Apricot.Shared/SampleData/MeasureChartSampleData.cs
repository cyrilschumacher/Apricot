﻿using Apricot.Shared.Models.Services;
using Apricot.Shared.Models.ViewModels;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for shows a measure chart.
    /// </summary>
    public class MeasureChartSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        public MeasureChartModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MeasureChartSampleData()
        {
            Model = new MeasureChartModel
            {
                Measures = new []
                {
                    new MeasureServiceModel{ Date = "1432659441", Temperature = 21.8},
                    new MeasureServiceModel{ Date = "1432659450", Temperature = 28.1},
                    new MeasureServiceModel{ Date = "1432659450", Temperature = 22.5},
                    new MeasureServiceModel{ Date = "1432659424", Temperature = 24.9}
                }
            };
        }

        #endregion Constructors.
    }
}