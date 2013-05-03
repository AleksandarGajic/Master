/**
* Dashboard controller
*/
Master.controller('AddVideoController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	if (Master.userId) {
    		$rootScope.setSeoTitle('Add Video');
    		$rootScope.SetBreadcrumb('Add Video');
    		$scope.successfullyAdded = function () {
    			$('#videoTitle').val('');
    			$('#videoLink').val('');
    			$('#videoDescription').val('');
    			$('.add-video-page h3').show();
    		};
    		$scope.failureAdded = function (error) {
    			console.log(error);
    		};
    		$scope.addVideo = function () {
    			var title = $.trim($('#videoTitle').val()),
				link = $.trim($('#videoLink').val()),
				description = $.trim($('#videoDescription').val()),
				isValid = true;


    			isValid = ext.validateField($('#videoTitle'), isValid);
    			isValid = ext.validateField($('#videoLink'), isValid);
    			isValid = ext.validateField($('#videoDescription'), isValid);

    			if (isValid && Master.userId) {
    				var success = ext.bind($scope.successfullyAdded, $scope),
					failure = ext.bind($scope.failureAdded, $scope);

    				server.createVideo(Master.userId, title, description, link, success, failure);
    			}
    		};
    	} else {
    		history.go(-1);
    	}
    } ]
);