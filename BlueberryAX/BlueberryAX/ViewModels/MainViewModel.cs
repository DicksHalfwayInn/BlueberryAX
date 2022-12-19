using Avalonia.Data;
using BlueberryAX.DataModels;
using BlueberryAX.Services;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueberryAX.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region Private Members

        /// <summary>
        ///      The Service used to load the dummy list of valid users
        /// </summary>
        private readonly IValidUsersService mValidUsersService;

        /// <summary>
        /// The Default email address used in the Login popup
        /// </summary>
        private static readonly string mDefaultEmailAddress = "Email@Address.com";

        /// <summary>
        ///      The default email and null password for the Login popup on opening
        /// </summary>
        private static readonly UserModel mDefaultLoggedInUser = new UserModel("DefaultUser", "DefaultShortName", "DefaultEmail", "DefaultPassword");

        #endregion EndRegion-Private Members


        #region Public Properties

        [ObservableProperty] private bool loginPopupIsOpen = false;

        /// <summary>
        ///      Indicates if the FoodEntryPopup is open... TODO:  Doesn't seem to work
        /// </summary>
        [ObservableProperty] private bool foodEntryPopupIsOpen = false;

        /// <summary>
        ///      The list of valid users that come from the valid users service on 
        ///      LoadSettingsAsync() which is a Community Toolkit tool that runs after the view is loaded
        /// </summary>   
        [ObservableProperty] private ObservableCollection<UserModel> validUsers = default!;

        /// <summary>
        ///      The Logged in User
        /// </summary>
        [ObservableProperty] private UserModel loggedInUser = mDefaultLoggedInUser;

        #region Email FullProperty

        /// <summary>
        /// The Email Address which changes to just the key pressed when it changes for the first time
        /// </summary>
        private string emailAddress = mDefaultEmailAddress;

        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                // Check to see if the default email address has been changed for the first time
                //      If it has been changed then find the newly inserted keypress and delete all the
                //      default characters from the property
                if (value != emailAddress && emailAddress == mDefaultEmailAddress)
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

                // If the user has deleted all his entered characters in the Email textbox
                //      then change the text back to the default
                if (value.Length == 0) value = mDefaultEmailAddress;

                // Set the emailaddress property to the changed value
                SetProperty(ref emailAddress, value);
            }
        }

        #endregion EndRegion-Email FullProperty

        #region Password FullProperty

        /// <summary>
        /// The Password which changes to just the key pressed when it changes for the first time
        /// </summary>
        private string password;

        public string Password
        {
            get => password;
            set
            {
                // update the password property with the changed value
                SetProperty(ref password, value);

            }
        }

        #endregion Password FullProperty

        #endregion Public Properties


        #region Public Commands

        [RelayCommand]
        private void FoodEntryButtonPressed()
        {
            FoodEntryPopupIsOpen ^= true;
        }

        [RelayCommand]
        private void Login()
        {
            foreach (var validUser in validUsers)
            {
                if (emailAddress == validUser.Email && emailAddress != mDefaultEmailAddress)
                {
                    if (validUser.Password == password)
                    {
                        LoggedInUserIsValid(validUser);

                        LoginPopupIsOpen = false;
                    }
                }
            }
        }

        private void LoggedInUserIsValid(UserModel user)
        {
            LoggedInUser = user;
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

            ValidUsers = new ObservableCollection<UserModel>(await mValidUsersService.GetValidUsersAsync());


        }

        #endregion EndRegion-Public Commands

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="userService">The valid users service</param>
        public MainViewModel(IValidUsersService userService)
        {
            mValidUsersService = userService;
        }

        /// <summary>
        ///     Design-time constructor
        /// </summary>
        public MainViewModel()
        {
            mValidUsersService = new DummyValidUsersService();
        }

        #endregion
    }
}
