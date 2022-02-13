let mapObject;
var myCenter;
let markers = [];
var offset = 0.1;

let markersMap = new Map();
let infoMap = new Map();
let mapsMap = new Map();

function initialize() {
    var latlng = new google.maps.LatLng(52.2605, 20.9592);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById("map"), options);

}

function returnMap(mapName) {

    var latlng = new google.maps.LatLng(52.2605, 20.9592);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    mapObject = new google.maps.Map(document.getElementById(mapName), options);

    mapsMap.set(mapName, mapObject);

    return "aaa";
}


function disableMarker(markerToDisable) {
    var marker = markers[markerToDisable];
    marker.setMap(null);
}

function addMarker(pinName, latitude, longitude, mapName, title) {

    var mapObject = mapsMap.get(mapName);

    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: mapObject,
        title: title,
    });

    markersMap.set(pinName, marker);

}


function addMapInfo(mapName, anchor, content) {
    var infowindow = new google.maps.InfoWindow(
        {
            content: content,
        });

    var markerAnchor = markersMap.get(anchor);
    var mapAnchor = mapsMap.get(mapName);

    infowindow.open({
        anchor: markerAnchor,
        map: mapAnchor,
        shouldFocus: true,
    })

    infoMap.set(anchor, infowindow);
}


