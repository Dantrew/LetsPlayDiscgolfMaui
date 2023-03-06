using LetsPlayDiscgolfMaui.ApplicationFacade;
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
        private bool _isCheckingLocation;
        private CancellationTokenSource _cancelTokenSource;
        public static double longitude;
        public static double latitude;
        ILoginFacade _loginFacade = new LoginFacade();

        public StartPageViewModel()
        {
            _ = GetCurrentLocation();
        }
        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                latitude = location.Latitude;
                longitude = location.Longitude;
            }
           
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;
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
