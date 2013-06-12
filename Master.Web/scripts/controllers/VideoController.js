/**
* Video controller
*/
Master.controller('VideoController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$scope.videoId = ext.decodeRoute($routeParams.videoId);
    	$scope.getUrl = ext.getFriendlyUrlForVideo;
    	$scope.getDate = ext.getDate;
    	$scope.getTimeAgo = ext.getTimeAgo;
    	$scope.formatMovieDuration = ext.formatMovieDuration;
    	$scope.bindData = function (data, callback) {
    		callback(null, data);
    	};

    	$scope.bindComments = function (data, callback) {
    		if (callback) {
    			callback(null, data);
    		} else {
    			$scope.Comments = data;
    			ext.safeApply($scope);
    		}
    	};

    	$scope.failure = function (callback) {
    		history.go(-1);
    	};

    	$scope.getPageDetails = function (callback) {
    		server.getVideoPageDetails($scope.videoId, ext.bind($scope.bindData, $scope, [callback], true), ext.bind($scope.failure, $scope, [callback], false));
    	};

    	$scope.getPageComments = function (callback) {
    		server.getVideoPageComments($scope.videoId, ext.bind($scope.bindComments, $scope, [callback], true), ext.bind($scope.failure, $scope, [callback], false));
    	};

    	$scope.takeVideoTime = function () {
    		$scope.currentTime = 0;
    		if ($('#cbxTakeTime').is(':checked')) {
    			if (jwplayer && jwplayer()) {
    				jwplayer().pause();
    				$scope.currentTime = jwplayer().getPosition();
    			}
    		}
    	};

    	$scope.seekVideo = function (time) {
    		jwplayer().seek(time);
    	};

    	$scope.createComment = function (callback, name, text, time) {
    		server.createComment($scope.videoId, text, name, time, callback, callback);
    	};

    	$scope.postComment = function () {
    		var name = $('#commentName').val(),
				text = $('#commentText').val(),
				time = $scope.currentTime ? $scope.currentTime : 0,
				isValid = true;

    		if ($.trim(name) == '') {
    			isValid = false;
    			$('#commentName').addClass('error');
    		} else {
    			$('#commentName').removeClass('error');
    		}

    		if ($.trim(text) == '') {
    			isValid = false;
    			$('#commentText').addClass('error');
    		} else {
    			$('#commentText').removeClass('error');
    		}

    		var flow =
			[
				ext.bind($scope.createComment, $scope, [name, text, time], true),
				ext.bind($scope.getPageComments, $scope)
			],
			complete = ext.bind(
				function (error, result) {
					if (angular.isDefined(error) && error !== null) {
						history.go(-1);
					} else {
						$scope.Comments = result;
						ext.safeApply($scope);
						$('#commentName').val(''),
						$('#commentText').val('');
					}
				},
				$scope
			);

    		if (isValid) {
    			async.waterfall(flow, complete);
    		}
    	};

    	var flow =
			[
				ext.bind($scope.getPageDetails, $scope),
				ext.bind($scope.getPageComments, $scope)
			],
			complete = ext.bind(
				function (error, result) {
					if (angular.isDefined(error) && error !== null) {
						// throw an error
					} else {
						$scope.Video = result[0];
						$scope.Comments = result[1];
						ext.safeApply($scope);
						$rootScope.setSeoTitle($scope.Video.SeoTitle);
						$rootScope.SetBreadcrumb($scope.Video);
					}
				},
				$scope
			);

    	async.parallel(flow, complete);

    	Master.updateComments = ext.bind($scope.getPageComments, $scope);
    	Master.updateCommentsInterval = setInterval('Master.updateComments()', 5 * 1000);

    	$scope.$on("$destroy", function () {
    		clearInterval(Master.updateCommentsInterval);
    	});
    } ]
);