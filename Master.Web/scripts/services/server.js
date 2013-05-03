/**
* Utility functions
*/
Master.service('server', [function () {
	this.server = {
		_getLatestVideos: function (success, failure) {
			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/GetLatestVideos',
				data: "{}",
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_getVideoPageDetails: function (videoId, success, failure) {
			var data = { "videoId": videoId };
			data = $.toJSON(data);

			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/GetVideoPageDetails',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_getVideoPageComments: function (videoId, success, failure) {
			var data = { "videoId": videoId };
			data = $.toJSON(data);

			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/GetVideoPageComments',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_getUserPageDetails: function (userId, success, failure) {
			var data = { "userId": userId };
			data = $.toJSON(data);

			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/GetUserPageDetails',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_getUserVideos: function (userId, page, success, failure) {
			var data = { "userId": userId, "page": page };
			data = $.toJSON(data);

			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/GetUserVideos',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_createComment: function (videoId, text, name, success, failure) {
			var data = { "videoId": videoId, "text": text, "name": name };
			data = $.toJSON(data);
			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/CreateComment',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},

		_createVideo: function (userId, title, text, link, success, failure) {
			var data = { "userId": userId, "title": title, "text": text, "link": link };
			data = $.toJSON(data);
			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/CreateVideo',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					success(null);
				},
				error: function (res) {
					failure(res);
				}
			});
		},

		_createUser: function (name, lastName, email, password, success, failure) {
			var data = { "name": name, "lastName": lastName, "email": email, "password": password };
			data = $.toJSON(data);
			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/CreateUser',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					success(null);
				},
				error: function (res) {
					failure(res);
				}
			});
		},

		_searchSite: function (term, page, success, failure) {
			var data = { "term": term, "page": page };
			data = $.toJSON(data);
			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/SearchSite',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						success($.evalJSON(res.d));
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		},
		_login: function (email, password, success, failure) {
			var data = { "email": email, "password": password };
			data = $.toJSON(data);

			$.ajax({
				type: 'POST',
				async: false,
				url: '/Services/MasonService.asmx/Login',
				data: data,
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				success: function (res) {
					if (res.d != "") {
						var usermodel = $.evalJSON(res.d);
						if (usermodel && usermodel.Id) {
							$.cookie('userId', usermodel.Id);
						}
						success(null)
					} else {
						success(null);
					}
				},
				error: function (res) {
					failure(null);
				}
			});
		}
	};

	return {
		getLatestVideos: this.server._getLatestVideos,
		getVideoPageDetails: this.server._getVideoPageDetails,
		getVideoPageComments: this.server._getVideoPageComments,
		createComment: this.server._createComment,
		getUserPageDetails: this.server._getUserPageDetails,
		getUserVideos: this.server._getUserVideos,
		searchSite: this.server._searchSite,
		createVideo: this.server._createVideo,
		createUser: this.server._createUser,
		login: this.server._login
	}
}
]);