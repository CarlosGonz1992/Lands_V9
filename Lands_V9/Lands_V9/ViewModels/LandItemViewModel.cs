using System;
using System.Collections.Generic;
using System.Text;

namespace Lands_V9.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands_V9.Models;
    using Lands_V9.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LandItemViewModel : Land
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }
        #endregion

        #region Methods
        private async void SelectLand()
        {
            MainViewModel.getInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
        #endregion
    }
}
