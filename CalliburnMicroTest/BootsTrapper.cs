﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalliburnMicroTest
{
    class BootsTrapper: BootstrapperBase
    {
        
            public BootsTrapper()
            {
                Initialize();
            }

            protected override void OnStartup(object sender, StartupEventArgs e)
            {
                DisplayRootViewFor<ViewModels.MainViewModel>();
            }
        

    }
}
