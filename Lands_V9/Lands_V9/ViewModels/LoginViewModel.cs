using System;
using System.Collections.Generic;
using System.Text;

namespace Lands_V9.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands_V9.Views;
    using Services;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LoginViewModel : BaseViewModel
    {
        //#region Events
        //public event PropertyChangedEventHandler PropertyChanged;
        //#endregion

        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                SetValue(ref this.isEnabled, value);
                //if (this.isEnabled != value)
                //{
                //    this.isEnabled = value;
                //    PropertyChanged?.Invoke(
                //        this,
                //        new PropertyChangedEventArgs(nameof(IsEnabled)));
                //}
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            //if (this.Email != "cgonzaleslop@gmail.com" || this.Password != "1234")
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert("Error", "Email or password incorrect", "Accept");
            //    this.Password = string.Empty;
            //    return;
            //}

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var token = await this.apiService.GetToken("https://landsv9apicgl.azurewebsites.net", this.Email, this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Something was wrong, please try later.", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", token.ErrorDescription, "Accept");
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.getInstance();
            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //await Application.Current.MainPage.DisplayAlert("Ok", "Login correcto", "Accept");
        }
        #endregion

        #region Contructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnabled = true;



            //this.email = "cgonzaleslop@gmail.com";
            //this.password = "1234";

            ////https://restcountries.eu/rest/v2/all
        }
        #endregion
    }
}
