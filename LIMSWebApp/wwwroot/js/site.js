



//(function () {

//    /* ======================================= Start Map Page Script ==================================== */

//    maptiks.trackcode = 'cd02c3aa-6877-4413-b792-edaa23a83b14';
//    //var parcelsVectorSource = new ol.source.Vector();

//    //var parcelsVector = new ol.layer.Vector({
//    //    source: vectorEuropa,
//    //    style: new ol.style.Style({
//    //        stroke: new ol.style.Stroke({
//    //            color: 'rgba(0, 0, 255, 1.0)',
//    //            width: 2
//    //        })
//    //    })
//    //});
//    var source = new ol.source.Vector();
//    $.ajax('temp.geojson').then(function (response) {
//        var geojsonFormat = new ol.format.GeoJSON();
//        var features = geojsonFormat.readFeatures(response,
//            { featureProjection: 'EPSG:3857' });
//        source.addFeatures(features);
//    });
//    var map = new ol.Map({
//        maptiks_id: 'Maps API OL Example',
//        layers: [
//            //source,
//            new ol.layer.Tile({
//                title: "Open Street Map",
//                type: "base",
//                source: new ol.source.OSM()
//            }),
//            new ol.layer.Tile({
//                title: 'DigitalGlobe Maps API: Recent Imagery',
//                type: "base",
//                source: new ol.source.XYZ({
//                    url: 'http://api.tiles.mapbox.com/v4/digitalglobe.92ee07af/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiZGlnaXRhbGdsb2JlIiwiYSI6ImNqNTVpcXdiNzA3NTczM3RnYnRqb2g2anEifQ.DziD_BPlGaeFqp3VXMqMvQ', // You will need to replace the 'access_token' and 'Map ID' values with your own. http://developer.digitalglobe.com/docs/maps-api
//                    attribution: "© DigitalGlobe, Inc"
//                })
//            }),
//            new ol.layer.Tile({
//                title: 'DigitalGlobe Maps API: Terrain Map',
//                type: "base",
//                source: new ol.source.XYZ({
//                    url: 'http://api.tiles.mapbox.com/v4/digitalglobe.nako1fhg/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiZGlnaXRhbGdsb2JlIiwiYSI6ImNqNTVpcXdiNzA3NTczM3RnYnRqb2g2anEifQ.DziD_BPlGaeFqp3VXMqMvQ', // You will need to replace the 'access_token' and 'Map ID' values with your own. http://developer.digitalglobe.com/docs/maps-api
//                    attribution: "©Mapbox, Inc / OpenStreetMap Contributors "
//                })
//            }),
            
//        ],
//        target: 'map',
//        view: new ol.View({
//            center: [4098004.08, -142987.72],
//            zoom: 12,
//            minZoom: 2
//        })
       
//    });
//    //map.addLayer(vectorEuropa)
//    //var featureRequest = new ol.format.WFS().writeGetFeature({
//    //    srsName: 'EPSG:3857',
//    //    featureNS: 'http://www.intergraph.com/geomedia/gml',
//    //    featurePrefix: 'gmgml',
//    //    featureTypes: ['Parcels'],
//    //    outputFormat: 'application/json'

//    //   // , filter: ol.format.filter(

//    //        //ol.format.filter.Comparison.equalTo('id')
//    //    //)

//    //    //,filter: ol.format.filter.and(
//    //    //    ol.format.filter.like('name', 'Mississippi*'),
//    //    //    ol.format.filter.equalTo('waterway', 'riverbank')
//    //    // )
//    });
   
////////    // then post the request and add the received features to a layer
////    fetch('https://webmapsvr.oakar.local/LIMSParcels/service.svc/get', {
////        method:'GET',
////        //body: new XMLSerializer().serializeToString(featureRequest),
       
////    }).then(function (response) {
////        console.log(response.json);
////        return response.json();
////    }).then(function (json) {
////        var features = new ol.format.GeoJSON().readFeatures(json);
////        parcelsVectorSource.addFeatures(features);
////        map.getView().fit(parcelsVectorSource.getExtent());
////    });


//////    //    var layerSwitcher = new ol.control.LayerSwitcher({
//////    //        target: "layer-switcher"
//////    //    });

//////    //    var zoomcontrol = new ol.control.Zoom({
//////    //        target: "custom-zoom"
//////    //    });

//////    //    //var attribution = new ol.control.Attribution({
//////    //    //    target:"attribution",
//////    //    //    collapsible: "true",
//////    //    //    collapsed:"true"
//////    //    //});

//////    //    /*var zoomtoextent = new ol.control.ZoomToExtent({
//////    //        target: "zoom-slider"
//////    //    });*/

//////    //    map.addControl(layerSwitcher);
//////    //    map.addControl(zoomcontrol);
//////    //    //map.addControl(zoomtoextent);

//////    ///*================================= End Map page Script =====================================*/

//////    ////side menu script
//////    //$('#slide-submenu').on('click', function () {
//////    //    $(this).closest('.list-group').fadeOut('slide', function () {
//////    //        $('.mini-submenu').fadeIn();
//////    //    });

//////    //});

//////    //$('.mini-submenu').on('click', function () {
//////    //    $(this).next('.list-group').toggle('slide');
//////    //    $('.mini-submenu').hide();
//////    //})

//////    ///* Charting Section Script */
//////    //var ctx = document.getElementById('demoChart').getContext('2d');
//////    //var myChart = new Chart(ctx, {
//////    //    type: 'line',
//////    //    data: {
//////    //        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'],
//////    //        datasets: [{
//////    //            label: 'Land Subdivisions',
//////    //            data: [12, 19, 3, 17, 6, 3, 7, 23, 34, 56, 23, 8],
//////    //            backgroundColor: "rgba(91,192,222,0.4)"
//////    //        }, {
//////    //            label: 'Land Transfers',
//////    //            data: [2, 29, 5, 5, 9, 3, 10, 12, 13, 15, 27, 20],
//////    //            backgroundColor: "rgba(217,83,79,0.4)"
//////    //        }]
//////    //    },
//////    //    options: {
//////    //        title: {
//////    //            display: true,
//////    //            text: 'Number of Land Transactions by Month'
//////    //        }
//////    //    }
//////    //});

//////    ///* Deletig using boostrap popup */
//////    //(function ($) {
//////    //    function ApplicationRole() {
//////    //        var $this = this;

//////    //        function initilizeModel() {
//////    //            $("#modal-action-application-role").on('loaded.bs.modal', function (e) {

//////    //            }).on('hidden.bs.modal', function (e) {
//////    //                $(this).removeData('bs.modal');
//////    //            });
//////    //        }
//////    //        $this.init = function () {
//////    //            initilizeModel();
//////    //        }
//////    //    }
//////    //    $(function () {
//////    //        var self = new ApplicationRole();
//////    //        self.init();
//////    //    })
//////    //}(jQuery))


//////// Write your JavaScript code - DO it inside the above function!