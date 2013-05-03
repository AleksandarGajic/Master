/**
* Register controller
*/
Master.controller('RegisterController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
    	$rootScope.setSeoTitle('Register');
    	$rootScope.SetBreadcrumb('Register');
    	$scope.successfullyRegister = false;

    	$scope.successfully = function () {
    		var userId = $.cookie('userId');
    		if (userId) {
    			$rootScope.setLogin(userId);
    			ext.redirect('user/' + userId);
    		}
    	};

    	$scope.failureAdded = function (error) {
    		console.log(error);
    	};

    	$scope.login = function () {
    		var email = $.trim($('#userEmail').val()),
				password = $.trim($('#userPassword').val());

    		server.login(email, password, ext.bind($scope.successfully, $scope), ext.bind($scope.failureAdded, $scope));
    	};

    	$scope.successfullyAdded = function () {
    		$scope.successfullyRegister = true;
    		Master.login = ext.bind($scope.login, $scope);
    		setTimeout(Master.login, 3000);
    	};

    	$scope.registerUser = function () {
    		var name = $.trim($('#userName').val()),
				lastName = $.trim($('#userLastName').val()),
				email = $.trim($('#userEmail').val()),
				password = $.trim($('#userPassword').val()),
				confirmPassword = $.trim($('#userConfirmPassword').val()),
				isValid = true;

    		isValid = ext.validateField($('#userName'), isValid);
    		isValid = ext.validateField($('#userLastName'), isValid);
    		isValid = ext.validateField($('#userEmail'), isValid);
    		isValid = ext.validateField($('#userPassword'), isValid);
    		isValid = ext.validateField($('#userConfirmPassword'), isValid);
    		//TODO: validate passwords match
    		if (!ext.testEmail(email)) {
    			isValid = false;
    			$('#userEmail').addClass('error');
    		} else {
    			$('#userEmail').removeClass('error');
    		}

    		if (isValid) {
    			var success = ext.bind($scope.successfullyAdded, $scope),
					failure = ext.bind($scope.failureAdded, $scope);

    			server.createUser(name, lastName, email, password, success, failure);
    		}
    	};
    } ]
);