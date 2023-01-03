using System;
using System.Collections.Generic;
using System.Text;

namespace BlueberryAX
{
    public class GlucoseBackgroundViewModel : BaseRadialGraphicViewModel
    {

        public GlucoseBackgroundViewModel()
        {
            ChildClearance = 0;
            GroupClearance = 0;
            FullAngleFrom = 0;
            FullAngleTo = 360;
        }
    }
}
