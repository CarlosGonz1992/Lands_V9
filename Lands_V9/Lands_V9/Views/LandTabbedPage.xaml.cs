﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lands_V9.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandTabbedPage : TabbedPage
    {
        public LandTabbedPage ()
        {
            InitializeComponent();
        }
    }
}