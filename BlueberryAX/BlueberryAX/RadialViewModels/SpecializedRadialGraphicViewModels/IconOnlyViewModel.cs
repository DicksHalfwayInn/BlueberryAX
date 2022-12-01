using System;
using System.Collections.Generic;
using System.Text;

namespace BlueberryAX
{
    public class IconOnlyViewModel : BaseRadialGraphicSegmentViewModel
    {
        public string Text { get; set; }

        public new BadgeColor Color { get; set; } = BadgeColor.White;

    }
}
