'use strict';
var Master = angular.module('Master', ['Master.filters', 'Master.directives']);

Master.
    config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) { //*** Configurate routes
    	$routeProvider.
            when('/home', { templateUrl: 'partials/dashboard.html', controller: 'DashboardController', routeName: 'Dashboard' }).
            when('', { templateUrl: 'partials/dashboard.html', controller: 'DashboardController', routeName: 'Dashboard', redirectTo: '/home' }).
            when('/', { templateUrl: 'partials/dashboard.html', controller: 'DashboardController', routeName: 'Dashboard', redirectTo: '/home' }).
			when('/video/:videoId', { templateUrl: 'partials/video.html', controller: 'VideoController', routeName: 'Video' }).
			when('/user/:userId', { templateUrl: 'partials/user.html', controller: 'UserController', routeName: 'User' }).
			when('/search/:term', { templateUrl: 'partials/search.html', controller: 'SearchController', routeName: 'Serach' }).
			when('/addvideo', { templateUrl: 'partials/addvideo.html', controller: 'AddVideoController', routeName: 'AddVideo' }).
			when('/register', { templateUrl: 'partials/register.html', controller: 'RegisterController', routeName: 'Register' }).
			when('/login', { templateUrl: 'partials/login.html', controller: 'LoginController', routeName: 'Login' }).
            otherwise({ redirectTo: '/home' })
        ;
    } ]).
    run(['$rootScope', 'ext',
        function ($rootScope, ext) {
        	$rootScope.loggedIn = false;
        	$rootScope.setSeoTitle = function (title) {
        		title = title.length > 0 ? (' - ' + title) : ''
        		$rootScope.SeoTitle = 'Master' + title;
        		ext.safeApply($rootScope);
        	};

        	$rootScope.SetBreadcrumb = function (data) {
        		$rootScope.breadcrumb = '<a href="/">Home</a>';
        		if (data && data.VideoAuthor) {
        			$rootScope.breadcrumb += ' > <a href="/#/user/' + data.VideoAuthor.Id + '">' + data.VideoAuthor.Name + ' ' + data.VideoAuthor.LastName + '</a>';
        			$rootScope.breadcrumb += ' > <span>' + data.Title + '</span>';
        		} else if (data && data.LastName) {
        			$rootScope.breadcrumb += ' > <span>' + data.Name + ' ' + data.LastName + '</span>';
        		} else {
        			$rootScope.breadcrumb += ' > <span>' + data + '</span>';
        		}
        	}

        	$rootScope.setLogin = function (userId) {
        		Master.userId = userId;
        		$rootScope.loggedIn = true;
        		ext.safeApply($rootScope);
        	}

        	$rootScope.logOut = function () {
        		$.cookie('userId', '');
        		$rootScope.loggedIn = false;
        		Master.userId = null;
        		delete Master.userId;
        		ext.redirect('');
        	}

        	$rootScope.InitSearch = true;

        	var userId = $.cookie('userId');
        	if (userId) {
        		$rootScope.setLogin(userId);
        	}
        }
    ]);