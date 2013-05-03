/**
* User controller
*/
Master.controller('UserController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$scope.userId = ext.decodeRoute($routeParams.userId);
    	$scope.getImageFromVideo = ext.getImageFromVideo;
    	$scope.getDate = ext.getDate;
    	$scope.Videos = [];
    	$scope.HasMore = false;
    	$scope.page = 0;

    	$scope.bindData = function (data, callback) {
    		callback(null, data);
    	};

    	$scope.bindVideos = function (data, callback) {
    		if (callback) {
    			callback(null, data);
    		} else {
    			$scope.Videos = $scope.Videos.concat(data.Videos);
    			$scope.HasMore = data.HasMore;
    			ext.safeApply($scope);
    		}
    	};

    	$scope.getUserPageDetails = function (callback) {
    		server.getUserPageDetails($scope.userId, ext.bind($scope.bindData, $scope, [callback], true), callback);
    	}

    	$scope.getUserVideos = function (callback) {
    		server.getUserVideos($scope.userId, $scope.page, ext.bind($scope.bindVideos, $scope, [callback], true), callback);
    	}

    	$scope.showMore = function () {
    		$scope.page++;
    		$scope.getUserVideos(null);
    	};

    	var flow =
			[
				ext.bind($scope.getUserPageDetails, $scope),
				ext.bind($scope.getUserVideos, $scope)
			],
			complete = ext.bind(
				function (error, result) {
					if (angular.isDefined(error) && error !== null) {
						// throw an error
					} else {
						$scope.User = result[0];
						$scope.Videos = result[1].Videos;
						$scope.HasMore = result[1].HasMore;
						ext.safeApply($scope);

						$rootScope.setSeoTitle($scope.User.SeoTitle);
						$rootScope.SetBreadcrumb($scope.User);
					}
				},
				$scope
			);

    	async.parallel(flow, complete);

    	$(window).scroll(function () {
    		if ($(window).scrollTop() + document.documentElement.clientHeight + 100 >= $(document).height()) {
    			if ($scope.HasMore) {
    				$scope.showMore();
    			}
    		}
    	});

    	$scope.$on("$destroy", function () {
			$(window).unbind('scroll');
    	});
    } ]
);