/*
	This script is initialize in the ParcelDetails.cshtml view
*/

$(function () {
	/* configure loading indicator*/
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


	//Pop-up elements for displaying attributes of clicked parcel
	const container = document.getElementById('popup');
	const content = document.getElementById('popup-content');
	const closer = document.getElementById('popup-closer');

	var styles = [

		new ol.style.Style({
			stroke: new ol.style.Stroke({
				color: 'blue',
				width: 3
			}),
			fill: new ol.style.Fill({
				color: 'rgba(0, 0, 255, 0.1)'
			})
		}),
		new ol.style.Style({
			image: new ol.style.Circle({
				radius: 5,
				fill: new ol.style.Fill({
					color: 'rgba(255, 0, 25,0.8)'
				})
			}),
			geometry: function (feature) {
				// return the coordinates of the first ring of the polygon
				var coordinates = feature.getGeometry().getCoordinates()[0];
				return new ol.geom.MultiPoint(coordinates);
			}
		})
	];


	var featureprops = [];

	var vectorSource = new ol.source.Vector();

	var vector = new ol.layer.Vector({
		source: vectorSource,
		style: styles
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

	var popup = new Popup();
	map.addOverlay(popup);


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


	var features = (new ol.format.GeoJSON()).readFeatures(GeoJson);

	var props = features[0].getProperties();

	featureprops.push(props);

	vectorSource.addFeatures(features);
	map.getView().fit(vectorSource.getExtent());


	function displayPopUp(evt) {


		var pixel = map.getPixelFromCoordinate(evt.coordinate);

		var info = "";

		map.forEachFeatureAtPixel(pixel, function (feature, layer) {

			if (layer === vector) {

				var featureinfo = featureprops[0];

				info = "<b>Parcel Number:</b><small> " + featureinfo.Parcel_Num + "</small><br>";
				info += "<b>Beacons:</b><small> " + featureinfo.Boundary + "</small><br>";
				info += "<b>Date of Update:</b><small> " + featureinfo.DateUpdated + "</small><br>";
				info += "<b>Area:</b><small> " + featureinfo.Area2 + " Acres" + "</small><br>";

				popup.show(evt.coordinate, "<div><h5>Parcel Details</h5><div>" + info + "</div></div>");
			}
			

		});

		
	}


	map.on('pointermove', displayPopUp);   //pointermove, singleclick

	vector.on('change:visible', onChangeVisible);
	vector.on('render', onRender);

	map.addLayer(vector);


});






