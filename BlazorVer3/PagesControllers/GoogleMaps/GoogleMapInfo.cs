namespace BlazorVer3.PagesControllers.GoogleMaps
{
    public class GoogleMapInfo
    {
        public string mapName;
        public GoogleMapMarker anchor;
        public string content;
        
        public GoogleMapInfo(string mapName, GoogleMapMarker anchor, string content)
        {
            this.mapName = mapName;
            this.anchor = anchor;
            this.content = content;
        }

    }
}
