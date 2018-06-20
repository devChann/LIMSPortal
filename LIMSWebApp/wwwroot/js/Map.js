
var vectorSource = new ol.source.Vector();
var vector = new ol.layer.Vector({
    source: vectorSource,
    style: new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: 'rgba(0, 0, 255, 1.0)',
            width: 2
        })
    })
});




var raster = new ol.layer.Tile({
    source: new ol.source.OSM()
});

var map = new ol.Map({
    layers: [raster],
    target: document.getElementById('map'),
    view: new ol.View({
        center: [4098004.08, -142987.72],
        maxZoom: 30,
        zoom: 18
    })
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
    body: requestBody,
    headers: new Headers({
        'Content-Type': 'application/xml'
    })
}).then(function (response) {
    var contentType = response.headers.get("content-type");
    console.log(contentType);
    if (contentType && contentType.includes("application/vnd.geo+json")) {
        return response.json();
    }
    throw new TypeError("Oops, we haven't got JSON!");
}).then(function (json) {
    var features = new ol.format.GeoJSON().readFeatures(json);
    vectorSource.addFeatures(features);
    map.getView().fit(vectorSource.getExtent());
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
map.addLayer(vector)
/* End of loading indicator */