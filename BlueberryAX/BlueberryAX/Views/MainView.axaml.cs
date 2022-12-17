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

            // Gather the named controls
            mFoodEntryButton = this.FindControl<Control>("FoodEntryButton") ?? throw new System.Exception("Cannot find Food Entry Button by name");
            mFoodEntryPopup = this.FindControl<Control>("FoodEntryPopup") ?? throw new System.Exception("Cannot find Food Entry Popup by name");
            mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new System.Exception("Cannot find Main Grid by name");
        }

        #endregion

        protected override async void OnLoaded()
        {
            await ((MainViewModel)DataContext).LoadSettingsCommand.ExecuteAsync(null);

            base.OnLoaded();
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // Get relative position of button, in relation to main grid
                var position = mFoodEntryButton.TranslatePoint(new Point(), mMainGrid) ??
                               throw new Exception("Cannot get TranslatePoint from Configuration Button");

                // Set margin of popup so it appears bottom left of button
                mFoodEntryPopup.Margin = new Thickness(
                    position.X,
                    0,
                    0,
                    mMainGrid.Bounds.Height - position.Y - mFoodEntryButton.Bounds.Height);
            });
        }

        //private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
        //    => ((MainViewModel)DataContext).ChannelConfigurationButtonPressedCommand.Execute(null);

    }
}
