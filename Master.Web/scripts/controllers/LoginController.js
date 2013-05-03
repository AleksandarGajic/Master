/**
* Login controller
*/
Master.controller('LoginController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$rootScope.setSeoTitle('Login');

    	$scope.successfully = function () {
    		var userId = $.cookie('userId');
    		if (userId) {
    			$rootScope.setLogin(userId);
    			ext.redirect('user/' + userId);
    		}
    	};
    	$scope.failure = function (error) {
    		console.log(error);
    	};

    	$scope.login = function () {
    		var email = $.trim($('#loginEmail').val()),
				password = $.trim($('#loginPassword').val()),
				isValid = true;


    		isValid = ext.validateField($('#loginEmail'), isValid);
    		isValid = ext.validateField($('#loginPassword'), isValid);

    		if (isValid) {
    			var success = ext.bind($scope.successfully, $scope),
					failure = ext.bind($scope.failure, $scope);

    			server.login(email, password, success, failure);
    		}
    	};
    } ]
);