/**
* Dashboard controller
*/
Master.controller('DashboardController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$rootScope.setSeoTitle('');
    	$scope.getImageFromVideo = ext.getImageFromVideo;
    	$scope.getDate = ext.getDate;
    	$scope.bindData = function (videos) {
    		$scope.Videos = videos;
    		ext.safeApply($scope);
    	};

    	server.getLatestVideos($scope.bindData, ext.emptyFn);
    } ]
);