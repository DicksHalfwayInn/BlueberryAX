
using Avalonia.Controls;

namespace BlueberryAX
{
    public class LoginViewModel
    {
        #region Public Properties

        //public double 

        public static LoginViewModel Instance = default!;

        public string Greeting = "Hello Kingston";

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            if (Avalonia.Controls.Design.IsDesignMode)
                Instance = new LoginViewModel();
        }

        #endregion

    }
}