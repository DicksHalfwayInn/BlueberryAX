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

        [ObservableProperty] private string _boldTitle = "AVALONIA";

        [ObservableProperty] private string _regularTitle = "LOUDNESS METER";

        [ObservableProperty] private bool _channelConfigurationListIsOpen = true;

        //[ObservableProperty]
        //private ObservableGroupedCollection<string, ChannelConfigurationItem> _channelConfigurations = default!;

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(ChannelConfigurationButtonText))]
        //private ChannelConfigurationItem? _selectedChannelConfiguration;

        //public string ChannelConfigurationButtonText => SelectedChannelConfiguration?.ShortText ?? "Select Channel";

        #endregion

        #region Public Commands

        [RelayCommand]
        private void ChannelConfigurationButtonPressed() => ChannelConfigurationListIsOpen ^= true;

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
