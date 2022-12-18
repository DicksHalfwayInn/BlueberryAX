using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using BlueberryAX.ViewModels;
using System;

namespace BlueberryAX.Views
{
    public partial class MainView : UserControl
    {
        #region Private Members

        private Control mFoodEntryPopup;
        private Control mFoodEntryButton;

        private Control mUserEntryPopup;
        private Control mUserEntryButton;

        private Control mGlucoseEntryPopup;
        private Control mGlucoseEntryButton;

        private Control mMainGrid;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <exception cref="System.Exception">Throws if named controls cannot be found</exception>
        public MainView()
        {
            InitializeComponent();

            // Gather Food Entry Button and Popup Control information using name from the view
            mFoodEntryButton = this.FindControl<Control>("FoodEntryButton") ?? throw new System.Exception("Cannot find Food Entry Button by name");
            mFoodEntryPopup = this.FindControl<Control>("FoodEntryPopup") ?? throw new System.Exception("Cannot find Food Entry Popup by name");

            // Gather User Entry Button and Popup Control information using name from the view
            mUserEntryButton = this.FindControl<Control>("UserEntryButton") ?? throw new System.Exception("Cannot find User Entry Button by name");
            mUserEntryPopup = this.FindControl<Control>("UserEntryPopup") ?? throw new System.Exception("Cannot find User Entry Popup by name");

            // Gather Glucose Entry Button and Popup Control information using name from the view
            mGlucoseEntryButton = this.FindControl<Control>("GlucoseEntryButton") ?? throw new System.Exception("Cannot find Glucose Entry Button by name");
            mGlucoseEntryPopup = this.FindControl<Control>("GlucoseEntryPopup") ?? throw new System.Exception("Cannot find Glucose Entry Popup by name");

            // Gather the information from the Main Grid that these ^ controls are in 
            mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new System.Exception("Cannot find Main Grid by name");
        }

        #endregion

        // Overrides the View's OnLoaded event
        protected override async void OnLoaded()
        {
            if (DataContext!= null)
            {
                await ((MainViewModel)DataContext).LoadSettingsCommand.ExecuteAsync(null);
            }

            base.OnLoaded();
        }

        // Called whenever the size of the View changes
        public override void Render(DrawingContext context)
        {
            base.Render(context);

            // Calculate the Margin for the Food Entry Popup in relation to the button
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // Get relative position of the Food Entry button, in relation to main grid
                var position = mFoodEntryButton.TranslatePoint(new Point(), mMainGrid) ??
                               throw new Exception("Cannot get TranslatePoint from FoodEntry Button");


                // Set margin of Food Entry popup so it appears bottom left of button
                mFoodEntryPopup.Margin = new Thickness(
                    position.X,
                    0,
                    0,
                    mMainGrid.Bounds.Height - position.Y - mFoodEntryButton.Bounds.Height);
            });

            // Calculate the Margin for the User Entry Popup in relation to the button
            Dispatcher.UIThread.InvokeAsync(() =>
            {
            // Get relative position of the User Entry button, in relation to main grid
            var position = mUserEntryButton.TranslatePoint(new Point(), mMainGrid) ??
                           throw new Exception("Cannot get TranslatePoint from UserEntry Button");


                // Set margin of popup so it appears top right of button
                mUserEntryPopup.Margin = new Thickness( 
                0,
                position.Y,
                mMainGrid.Bounds.Width - position.X - mUserEntryButton.Bounds.Width ,
                0);
            });

            // Calculate the Margin for the Glucose Entry Popup in relation to the button
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // Get relative position of Glucose Entry button, in relation to main grid
                var position = mGlucoseEntryButton.TranslatePoint(new Point(), mMainGrid) ??
                               throw new Exception("Cannot get TranslatePoint from Glucose Entry Button");

                // Set margin of popup so it appears bottom right of button
                mGlucoseEntryPopup.Margin = new Thickness(
                    0,
                    0,
                    mMainGrid.Bounds.Width - position.X - mGlucoseEntryButton.Bounds.Width,
                    mMainGrid.Bounds.Height - position.Y - mGlucoseEntryButton.Bounds.Height
                    );
            });
        }

        //private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
        //    => ((MainViewModel)DataContext).ChannelConfigurationButtonPressedCommand.Execute(null);

    }
}
