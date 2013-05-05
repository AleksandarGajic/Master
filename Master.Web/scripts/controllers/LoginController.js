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
    		} else {
    			$('#loginEmail').addClass('error');
    			$('#loginPassword').addClass('error');
    			$('.main-content h3').show();
    		}
    	};

    	$scope.failure = function (error) {
    	};

    	$scope.login = function () {
    		var email = $.trim($('#loginEmail').val()),
				password = $.trim($('#loginPassword').val()),
				isValid = true;

    		$('.main-content h3').hide();
    		isValid = ext.validateField($('#loginEmail'), isValid);
    		isValid = ext.validateField($('#loginPassword'), isValid);

    		if (!ext.testEmail(email)) {
    			$('#loginEmail').addClass('error');
    			isValid = false;
    		};

    		if (isValid) {
    			var success = ext.bind($scope.successfully, $scope),
					failure = ext.bind($scope.failure, $scope);

    			server.login(email, password, success, failure);
    		}
    	};
    } ]
);