﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lands_V9.ViewModels
{
    using Lands_V9.Models;
    using System.Collections.Generic;

    class MainViewModel
    {
        #region Properties
        public List<Land> LandsList { get; set; }
        public TokenResponse Token { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        #endregion

        #region Contructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel getInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
