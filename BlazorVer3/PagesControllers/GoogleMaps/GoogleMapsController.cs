using BlazorVer3.Models;
using BlazorVer3.PagesControllers.GoogleMaps;
using Microsoft.JSInterop;
using GoogleMaps.LocationServices;
using System.Xml.Linq;

namespace BlazorVer3
{
    //Works with GooleScript.js
    public class GoogleMapsController
    {
        private string apiKey = "";
        IJSRuntime jsRuntime;
        List<GoogleMapMarker> markers;
        string mapName;

        public GoogleMapsController(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;

            markers = new List<GoogleMapMarker>();

        }


        public async void GenerateMap(string mapName)
        {
            string text = new(await jsRuntime.InvokeAsync<string>("returnMap", mapName));
            this.mapName = mapName;
        }

        private async void AddMarker(GoogleMapMarker marker)
        {
            GoogleMapInfo googleMapInfo = marker.mapInfo;

            await jsRuntime.InvokeVoidAsync("addMarker", marker.pinName, marker.latitude, marker.longitude, marker.mapName, marker.title);
            await jsRuntime.InvokeVoidAsync("addMapInfo", googleMapInfo.mapName, googleMapInfo.anchor.pinName, googleMapInfo.content);
        }

        public void GetMarkerList(string mapName)
        {
            using(var context = new PAI_DBContext())
            {
                List<GoogleMapsPin> query = context.GoogleMapsPins
                            .ToList();

                foreach(GoogleMapsPin pin in query)
                {
                    this.AddMarker(this.TransformGoogleMarkerToJs(pin, mapName));
                }

                //HERE generate GoogleMapMarker
            }
        }

        private GoogleMapMarker TransformGoogleMarkerToJs(GoogleMapsPin googleMapMarker, string mapName)
        {
            GoogleMapMarker returnMarker = new GoogleMapMarker(googleMapMarker.PinName,
                                                                Convert.ToDouble(googleMapMarker.Lat),
                                                                Convert.ToDouble(googleMapMarker.Lng),
                                                                mapName,
                                                                googleMapMarker.Description
                                                                );

            GoogleMapInfo returnPin = new GoogleMapInfo(mapName, returnMarker, googleMapMarker.AddressStr);

            returnMarker.setMapInfo(returnPin);

            return returnMarker;
        }

        public async Task<string> GetDecodedPin(double lat, double lng)
        {
            string returnValue = new(await jsRuntime.InvokeAsync<string>("geocodeConvert", lat, lng));

            return returnValue;
        }

        public  string pinAddressDecode(double lat, double lng)
        {
            GoogleLocationService gls = new GoogleLocationService(apiKey);

            AddressData data = gls.GetAddressFromLatLang(lat, lng);

            if(data == null)
            {
                return "";
            }

            return data.Address + ", " + data.City + "," + data.Zip;
        }

        public bool InsertNewPin(string pinName, double lat, double lng, string description)
        {
            GoogleMapsPin googleMapsPin = new GoogleMapsPin();

            googleMapsPin.PinName = pinName;
            googleMapsPin.Lat = (float?)lat;
            googleMapsPin.Lng = (float?)lng;
            googleMapsPin.Description = description;
           
            using (var context = new PAI_DBContext())
            {
                var innerPin = context.GoogleMapsPins.Where(x => x.PinName == pinName).ToList();


                if(innerPin.Count != 0)
                {
                    return false;
                }

                googleMapsPin.AddressStr = this.pinAddressDecode(lat, lng);
                context.GoogleMapsPins.Add(googleMapsPin);

                context.SaveChanges();
            }

            return true; 
        }

    }
}
