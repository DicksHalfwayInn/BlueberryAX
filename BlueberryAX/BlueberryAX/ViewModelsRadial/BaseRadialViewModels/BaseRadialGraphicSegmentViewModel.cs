using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueberryAX
{
    public partial class BaseRadialGraphicSegmentViewModel : BaseGraphicViewModel
    {
        #region Public Properties

        #region UI

        [ObservableProperty] private string segmentText = "SegmentText";

        public double Width { get; set; }
        public double Height { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }

        #endregion


        /// <summary>
        /// The angle at which this annotation should be rotated
        /// </summary>
        public double Angle { get; set; }

        public BadgeColor Color { get; set; }

        #endregion
    }
}
