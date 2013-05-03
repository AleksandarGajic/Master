$(document).ready(function () {
	$('.iframe-wrap').html('<iframe width="960" height="540"  src="' + videoLink + '" frameborder="0" allowfullscreen></iframe>');
	Master.Service.GetVideoPageDetails(function (res) { console.log(res) }, function () { });

});

function GetVideoPageDetails($id) {
	var id = { id: "1054" };
	var jsonStr = $.toJSON(id);

	$.ajax({
		type: 'POST',
		async: false,
		url: '/Services/MasonService.asmx/GetLatestVideos',
		data: "{}",
		contentType: "application/json; charset=utf-8",
		dataType: 'json',
		success: function (res) {
			alert(res);
			if (res.d != "") {
				//success($.evalJSON(res.d));
				console.log($.evalJSON(res.d));
			}
		},
		error: function (res) {
			console.log(res.responseText);
		}
	});
}