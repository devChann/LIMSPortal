
//Pop-up elements for displaying attributes of clicked parcel
const container = document.getElementById('popup');
const content = document.getElementById('popup-content');
const closer = document.getElementById('popup-closer');

var featureprops = [];

var vectorSource = new ol.source.Vector();
var vector = new ol.layer.Vector({
    source: vectorSource,
    style: new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: 'rgba(0, 0, 255, 1.0)',
            width: 2

        }),
        fill: new ol.style.Fill({
            color: 'rgba(0,0,255,0.5)'
            
        })
    })
});

//define projection
var projection = new ol.proj.Projection({
    code: 'EPSG:3857',
    units: 'm',
    axisOrientation: 'neu'
});

//Create an overlay to anchor the popup to the map.
const overlay = new ol.Overlay({
    element: container,
    autoPan: true,
    autoPanAnimation: {
        duration: 250
    }
});

//configure view
var view = new ol.View({
    center: [4098004.08, -142987.72],
    maxZoom: 30,
    zoom: 18,
    projection: projection
});

var raster = new ol.layer.Tile({
    source: new ol.source.OSM()
});

var map = new ol.Map({
    layers: [raster],
    target: document.getElementById('map'),
    view: view,
    overlays: [overlay],
});


var mousePositionControl = new ol.control.MousePosition({
    className: 'custom-mouse-position',
    target: document.getElementById('location'),
    coordinateFormat: ol.coordinate.createStringXY(5),
    undefinedHTML: '&nbsp;'
});


//click handler to hide the popup.
closer.onclick = function () {
    overlay.setPosition(undefined);
    closer.blur();
    return false;
};


//this function changes the cursor to a pointer when cursor is on map
map.on('pointermove', function (evt) {
    if (evt.dragging) {
        return;
    }
    var pixel = map.getEventPixel(evt.originalEvent);
    var hit = map.forEachLayerAtPixel(pixel, function (layer) {
        return true;
    });
    map.getTargetElement().style.cursor = hit ? 'pointer' : '';
});


// generate a GetFeature request
var featureRequest = new ol.format.WFS().writeGetFeature({
    srsName: 'EPSG:3857',
    featureNS: 'http://www.intergraph.com/geomedia/gml',
    featurePrefix: 'gmgml',
    featureTypes: ['Parcels'],
    outputFormat: 'application/vnd.geo+json',
    filter: ol.format.filter.equalTo('Id', routeId)

});


var requestBody = new XMLSerializer().serializeToString(featureRequest);

// then post the request and add the received features to a layer
fetch('https://demo.osl.co.ke:7575/LIMSParcels/service.svc/post', {
    method: 'POST',
    mode: 'cors',
    credentials: 'same-origin',
    body: requestBody,
    headers: new Headers({
        'Content-Type': 'application/xml',
        'Access-Control-Allow-Credentials': true,
        'Access-Control-Allow-Origin':'*'
    })
}).then(function (response) {
    var contentType = response.headers.get("content-type");
    console.log(contentType); //remove later
    if (contentType && contentType.includes("application/vnd.geo+json")) {
        var result = response.json();
        return result;
    }
    throw new TypeError("Oops, we haven't got JSON!");
}).then(function (json) {
    var features = new ol.format.GeoJSON().readFeatures(json);
    var props = features[0].getProperties();  

    featureprops.push(props);

    vectorSource.addFeatures(features);
    map.getView().fit(vectorSource.getExtent());
    });

//click handler to the map to render the popup.
map.on('singleclick', function (evt) {

    var coordinates = evt.coordinate;
    console.log(evt.features);
    var info = "";

    //variable to store requested feature info
    if (vectorSource) {
        var featureinfo = featureprops[0]; 

        info = "<h4>" + featureinfo.Parcel_Num + "</h4>";
        info += "<p>Lon/Lat: " + coordinates + "</p>";
        info += "<p>Beacons: " + featureinfo.Boundary + "</p>";
        info += "<p>Parcel Number: " + featureinfo.Parcel_Num + "</p>";
        info += "<p>Owner Name: " + featureinfo.Parcel_Own + "</p>";
        info += "<p>Area: " + featureinfo.Area2 + " Acres" + "</p>";  
       
   } else {
      info = "<p>No Parcel here</p>"; 
   }     

    console.log(featureinfo);

    content.innerHTML = info;

    overlay.setPosition(coordinates);

});




/* Start loading indicator*/
var throbberCounter = 0;
var increaseThrobberCounter = function () {
    document.getElementById('throbber').style.display = 'block';
    ++throbberCounter;
};
var decreaseThrobberCounter = function () {
    --throbberCounter;
    if (throbberCounter <= 0) {
        throbberCounter = 0;
        document.getElementById('throbber').style.display = 'none';
    }
};

var onChangeVisible = function (e) {
    if (e.oldValue && this.throbberVisible) {
        decreaseThrobberCounter();
        this.throbberVisible = false;
    } else if (!e.oldValue && !this.throbberVisible) {
        increaseThrobberCounter();
        this.throbberVisible = true;
    }
};

var onRender = function (e) {
    if (this.throbberVisible) {
        decreaseThrobberCounter();
        this.throbberVisible = false;
    }
};

vector.on('change:visible', onChangeVisible);
vector.on('render', onRender);
map.addLayer(vector);
/* End of loading indicator */




