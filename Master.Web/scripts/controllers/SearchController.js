/**
* Search controller
*/
Master.controller('SearchController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$rootScope.setSeoTitle('Search');
    	$rootScope.SetBreadcrumb('Search');
    	$scope.term = ext.decodeRoute($routeParams.term);
    	$scope.getImageFromVideo = ext.getImageFromVideo;
    	$scope.getDate = ext.getDate;
    	$scope.HasMore = false;
    	$scope.page = 0;
    	$scope.Videos = []

    	$scope.bindData = function (data) {
    		$scope.Videos = $scope.Videos.concat(data.Videos);
    		$scope.HasMore = data.HasMore;
    		$scope.TotalCount = data.TotalCount;
    		ext.safeApply($scope);
    	};

    	server.searchSite($scope.term, $scope.page, $scope.bindData, ext.emptyFn);
    	
		$scope.showMore = function () {
    		$scope.page++;
    		server.searchSite($scope.term, $scope.page, $scope.bindData, ext.emptyFn);
    	};

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