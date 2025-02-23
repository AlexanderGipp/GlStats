﻿using GlStats.Core.Boundaries.Infrastructure;
using GlStats.Wpf.Utilities;
using GlStats.Wpf.Views;
using Prism.Regions;

namespace GlStats.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IAuthentication _auth;
        private readonly IRegionManager _regionManager;

        public DelegateCommand RegisterInitViewCommand { get; private set; }

        public MainWindowViewModel(IAuthentication auth, IRegionManager regionManager)
        {
            _auth = auth;
            _regionManager = regionManager;

            RegisterInitViewCommand = new DelegateCommand(RegisterInitialView);
        }

        private void RegisterInitialView()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_auth.GetConfig().CurrentCulture);

            if (string.IsNullOrWhiteSpace(_auth.GetConfig().GitLabUrl) ||
                string.IsNullOrWhiteSpace(_auth.GetConfig().GitLabToken))
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri(nameof(RegistrationControl), UriKind.Relative));
            }
            else
            {
                _regionManager.RequestNavigate(RegionNames.NavRegion, new Uri(nameof(NavigationControl), UriKind.Relative));
                _regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri(nameof(ProjectsControl), UriKind.Relative));
            }
        }
    }
}
