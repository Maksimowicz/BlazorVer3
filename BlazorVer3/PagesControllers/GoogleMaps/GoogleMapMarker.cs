namespace BlazorVer3.PagesControllers.GoogleMaps
{
    public class GoogleMapMarker
    {
        public string pinName;
        
        public double latitude;
        public double longitude;

        public string mapName;
        public string title;

        public GoogleMapInfo mapInfo;

        public GoogleMapMarker(string pinName, double latitude, double longitude, string mapName, string title)
        {
            this.pinName = pinName;
            this.latitude = latitude;
            this.longitude = longitude;
            this.mapName = mapName;
            this.title = title;
        }

        public void setMapInfo(GoogleMapInfo googleMapInfo)
        {
            this.mapInfo = googleMapInfo;
        }

    }
}
