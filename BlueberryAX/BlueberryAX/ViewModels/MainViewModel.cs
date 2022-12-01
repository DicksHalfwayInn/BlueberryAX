
using Avalonia.Controls;

namespace BlueberryAX
{
    public class MainViewModel
    {
        #region Public Properties

        //public double 

        public static MainViewModel Instance = default!;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            if (Avalonia.Controls.Design.IsDesignMode)
                Instance = new MainViewModel();
        }

        #endregion

    }
}