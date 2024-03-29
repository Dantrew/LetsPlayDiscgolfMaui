﻿using LetsPlayDiscgolfMaui.ApplicationFacade;
using LetsPlayDiscgolfMaui.Facade.Contracts;
using LetsPlayDiscgolfMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal class StartPageViewModel
    {
        public static double longitude;
        public static double latitude;
        ILoginFacade _loginFacade = new LoginFacade();

        public StartPageViewModel()
        {
            CheckLocation();
        }
        public async void CheckLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    latitude = location.Latitude;
                    longitude = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotSupportedException", "OK");
            }
            catch (FeatureNotEnabledException)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotEnabledException", "OK");
            }
            catch (PermissionException)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "PermissionException", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Unable to get location", "OK");
            }
        }
            public bool CheckInlog(string user, string pass)
        {
            if(_loginFacade.CanLogIn(user, pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
