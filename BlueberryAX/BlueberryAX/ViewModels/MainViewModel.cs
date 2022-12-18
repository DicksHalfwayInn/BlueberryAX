using Avalonia.Data;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueberryAX.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region Private Members

        //private readonly IAudioInterfaceService mAudioInterfaceService;


        #endregion

        #region Public Properties

        [ObservableProperty] private string boldTitle = "AVALONIA";

        [ObservableProperty] private string regularTitle = "LOUDNESS METER";

        [ObservableProperty] private bool foodEntryPopupIsOpen = false;

        private string emailAddress = "Email@Address.com";

        /// <summary>
        /// The Email Address which changes to just the key pressed when it changes for the first time
        /// </summary>
        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                if (value != emailAddress && emailAddress == "Email@Address.com")
                {
                    var i = 0;
                    foreach (var c in value)
                    {
                        char ch = emailAddress[i];
                        if (!(ch == c))
                        {
                            emailAddress = value[i].ToString();
                            return;
                        }
                        i++;
                    }

                }
                if (value.Length == 0)
                {
                    value = "Email@Address.com";
                }
                SetProperty(ref emailAddress, value);
            }
        }

        private string password;

        

        /// <summary>
        /// The Password which changes to just the key pressed when it changes for the first time
        /// </summary>
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
            
        }



        //[ObservableProperty]
        //private ObservableGroupedCollection<string, ChannelConfigurationItem> _channelConfigurations = default!;

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(ChannelConfigurationButtonText))]
        //private ChannelConfigurationItem? _selectedChannelConfiguration;

        //public string ChannelConfigurationButtonText => SelectedChannelConfiguration?.ShortText ?? "Select Channel";

        #endregion

        #region Public Commands

        [RelayCommand]
        private void FoodEntryButtonPressed()
        {
            FoodEntryPopupIsOpen ^= true;
        }

        //[RelayCommand]
        //private void ChannelConfigurationItemPressed(ChannelConfigurationItem item)
        //{
        //    // Update the selected item
        //    SelectedChannelConfiguration = item;

        //    // Close the menu
        //    ChannelConfigurationListIsOpen = false;
        //}

        [RelayCommand]
        private async Task LoadSettingsAsync()
        {

            await Task.Delay(2000);

            // Get the channel configuration data
            //var channelConfigurations = await mAudioInterfaceService.GetChannelConfigurationsAsync();

            // Create a grouping from the flat data
            //ChannelConfigurations =
            //    new ObservableGroupedCollection<string, ChannelConfigurationItem>(
            //        channelConfigurations.GroupBy(item => item.Group));
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="audioInterfaceService">The audio interface service</param>
        //public MainViewModel(IAudioInterfaceService audioInterfaceService)
        //{
        //    mAudioInterfaceService = audioInterfaceService;
        //}

        /// <summary>
        ///     Design-time constructor
        /// </summary>
        //public MainViewModel()
        //{
        //    mAudioInterfaceService = new DummyAudioInterfaceService();
        //}

        #endregion
    }
}
