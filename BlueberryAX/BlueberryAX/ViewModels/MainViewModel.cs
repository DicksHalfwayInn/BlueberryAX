using Avalonia;
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

        #region Non-Infographic Properties, Commands and Private Methods

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

        /// <summary>
        ///      Indicates if the Login Popup is open
        /// </summary>
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

        // TODO: and this...
        [ObservableProperty] private bool loginFailed = false;

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
                // TODO: CHange this
                LoginFailed = false;
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
                LoginFailed = false;
                // update the password property with the changed value
                SetProperty(ref password, value);
            }
        }

        #endregion EndRegion-Password-FullProperty

        #endregion EndRegion-Public Properties

        #region Public Commands

        /// <summary>
        /// The Food Entry Button Pressed method
        /// </summary>
        [RelayCommand]
        private void FoodEntryButtonPressed()
        {
            //  TODO:  This never gets hit but it needs be changed to Login type.
            FoodEntryPopupIsOpen ^= true;
        }

        /// <summary>
        ///      Runs whenever the LogIn button is pressed on the Login Popup in the view
        /// </summary>
        [RelayCommand]
        private void Login()
        {
            // Find out if we have a valid user from the list of valid users
            foreach (var validUser in validUsers)
            {
                // If we have a valid user... make sure their password is correct
                if (emailAddress == validUser.Email && emailAddress != mDefaultEmailAddress)
                {
                    if (validUser.Password == password)
                    {
                        // Call method to handle a valid user and pass in the user
                        LoggedInUserIsValid(validUser);
                        // Exit the Login method
                        return;
                    }
                }
            }
            // Reset the Login is Valid property to true, even if it is reset to the default settings
            // This only gets set to false if a login button is pressed with invalid credentials
            LoginFailed = true;
        }

        /// <summary>
        ///      Called when the Cancel button on the Login popup is active
        /// </summary>
        [RelayCommand]
        private void CancelLogin()
        {
            ResetLoginEmailAndPasswordToDefault();
        }

        #endregion EndRegion-Public Commands

        #region Private Methods

        /// <summary>
        ///      Called when the logged in user has been validated with one in the valid list
        /// </summary>
        /// <param name="user">The user that the email and password validated</param>
        private void LoggedInUserIsValid(UserModel user)
        {
            LoggedInUser = user;

            ResetLoginEmailAndPasswordToDefault();
        }

        /// <summary>
        /// Resets the Login popup's email and password to the default
        ///        And makes the Login popup disappear
        /// </summary>
        private void ResetLoginEmailAndPasswordToDefault()
        {
            emailAddress = "Email@Address.com";

            Password = "";

            LoginPopupIsOpen = false;

            // TODO: and this...
            LoginFailed = false;
        }

        #endregion Private Methods

        #endregion EndRegion - Non-Infographic Properties, Commands and Private Methods

        #region Infographic Properties, Commands and Private Methods

        private static double mInfographicOR = 169;

        private static double mRadarBackgrdOR = 120;

        [ObservableProperty]private double radarOD = mRadarBackgrdOR * 2;

        [ObservableProperty]private double infographicOD = mInfographicOR * 2;

        [ObservableProperty]private CornerRadius infographicCornerRadius = new CornerRadius(mInfographicOR);

        [ObservableProperty]private double radarBackgrdOD = (mRadarBackgrdOR + 1) * 2;

        [ObservableProperty] private CornerRadius radarBackgrdCornerRadius = new CornerRadius(mRadarBackgrdOR);

        [ObservableProperty]private double containerWidth = 400;

        [ObservableProperty]private double containerHeight = 400;

        [ObservableProperty]private BadgeColor backgroundColor = BadgeColor.Yellow;

        [ObservableProperty]private double radarLeft = 50;

        [ObservableProperty]private double radarRight = 50;





        #endregion EndRegion-Infographic Properties, Commands and Private Methods




        #region CommunityToolkitMethod Commands

        /// <summary>
        /// The CommunityToolkitMethod that gets ran after the view is loaded and running
        /// </summary>
        /// <returns>Returns a null task ???? TODO: what should this comment be???</returns>
        [RelayCommand]
        private async Task LoadSettingsAsync()
        {
            ValidUsers = new ObservableCollection<UserModel>(await mValidUsersService.GetValidUsersAsync());

        }

        #endregion EndRegion-CommunityToolkitMethod Commands



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

        #endregion EndRegion-Constructors
    }
}

