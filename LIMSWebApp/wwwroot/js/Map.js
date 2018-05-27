
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
    layers: [raster, vector],
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


//console.log(new XMLSerializer().serializeToString(featureRequest));

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




/*========================================================================================*/
//OpenLayers WFS Filter Example// Credits: http://bl.ocks.org/ThomasG77/530d830eca124cc1b836ff341bc63da6

/*
 <!DOCTYPE html>
<html>
  <head>
    <meta charset='utf-8'>
    <title>WFS - GetFeature</title>
    <link rel="stylesheet" href="https://openlayers.org/en/v3.20.0/css/ol.css" type="text/css">
    <!-- The line below is only needed for old environments like Internet Explorer and Android 4.x -->
    <script src="https://cdn.polyfill.io/v2/polyfill.min.js?features=requestAnimationFrame,Element.prototype.classList,URL"></script>
    <script src="https://openlayers.org/en/v3.20.0/build/ol.js"></script>
  </head>
  <body>
    <div id="map" class="map"></div>
    <script>
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
        layers: [raster, vector],
        target: document.getElementById('map'),
        view: new ol.View({
          center: ol.proj.fromLonLat([-74.21686064251395, 45.375053394861254]),
          maxZoom: 18,
          zoom: 7
        })
      });

      //var polygon = new ol.geom.Polygon([
      //  [
      //    [
      //      -76.13890000314728,
      //      45.71589184909814
      //    ],
      //    [
      //      -76.35862656564728,
      //      44.69416594907523
      //    ],
      //    [
      //      -74.46897812814728,
      //      44.66291807088572
      //    ],
      //    [
      //      -71.92015000314728,
      //      45.191840069034185
      //    ],
      //    [
      //      -73.63401719064727,
      //      46.17424709227828
      //    ],
      //    [
      //      -76.13890000314728,
      //      45.71589184909814
      //    ]
      //  ]
      //]);

      // Correct inverted X, Y coordinates
      //polygon.applyTransform(function (coords, coords2, stride) {
      //  for (var j = 0; j < coords.length;j += stride) {
      //    var y = coords[j];
      //    var x = coords[j + 1];
      //    coords[j] = x;
      //    coords[j + 1] = y;
      //  };
      //});

      // generate a GetFeature request
      var featureRequest = new ol.format.WFS().writeGetFeature({
        srsName: 'EPSG:3857',
        featureNS: 'http://www.intergraph.com/geomedia/gml',
        featurePrefix: 'gmgml',
        featureTypes: ['Parcels'],
        outputFormat: 'application/json',
        filter: ol.format.filter.and(
          //ol.format.filter.intersects('the_geom', polygon, 'EPSG:4326'),
          ol.format.filter.equalTo('Id', routeId)
        )
      });

      console.log(new XMLSerializer().serializeToString(featureRequest));

      // then post the request and add the received features to a layer
      fetch('https://demo.osl.co.ke:7575/LIMSParcels/service.svc/get?', {
        method: 'POST',
        body: new XMLSerializer().serializeToString(featureRequest)
      }).then(function(response) {
        return response.text();
      }).then(function(text) {
        var features = new ol.format.WFS().readFeatures(text);
        vectorSource.addFeatures(features);
      });

    </script>
  </body>
</html>
 
 */


