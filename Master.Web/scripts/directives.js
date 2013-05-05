'use strict';

/* Directives */

angular.
    module('Master.directives', []).

directive('ngShowOverride', function () {
	return function (scope, element, attrs) {
		scope.$watch(attrs.ngShowOverride, function (value) {
			if (value) {
				element.fadeIn(300);
			} else {
				element.fadeOut(300);
			}
		});
	}
}).
directive('ngSearchField', ['ext', 'server', function (ext, server) {
	return function (scope, element, attrs) {

		scope.redirect = function (searchItem) {
			if (searchItem) {
				scope.searchSuggestion = [];
				ext.safeApply(scope);
				$("#search").val('');
				ext.redirect('video/' + searchItem.Id);
			}
		};

		scope.getSearchTitle = function (searchItem) {
			if (searchItem) {
				var term = $("#search").val();
				return searchItem.Title.toLowerCase().replace(term, '<strong>' + term + '</strong>');
			}
		};

		scope.bindData = function (res) {
			scope.searchSuggestion = res.Videos;
			ext.safeApply(scope);
		};

		scope.$watch(attrs.ngSearchField, function (value) {
			if (value) {
				scope.doSearch = function () {
					var term = $("#search").val();
					term = $.trim(term);
					if (term !== '') {
						term = ext.encodeRoute(term);
						scope.searchSuggestion = [];
						ext.safeApply(scope);
						$("#search").val('');
						ext.redirect('search/' + term);
					}
				};

				$("#search").keyup(function (event) {
					var keycode = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));
					if (keycode == 13) {
						scope.doSearch();
					} else {
						if ($(this).val().length >= 2) {
							server.searchSitePreview($(this).val(), scope.bindData, ext.emptyFn);
						} else {
							scope.searchSuggestion = [];
							ext.safeApply(scope);
						}
					}
				});

				$("#searchButton").click(function () {
					scope.doSearch();
				});
			}
		});
	}
} ]).
directive('ngFollowComment', function () {
	return function (scope, element, attrs) {
		scope.$watch(attrs.ngFollowComment, function (value) {
			if (value) {
				$(window).scroll(function () {
					if ($('.comments .right').length) {
						var topPosition = $('.comments .right').offset().top,
						currentPosition = $(window).scrollTop();

						if (currentPosition >= topPosition) {
							element.css('position', 'fixed').css('top', '10px');
						} else {
							element.css('position', 'relative').css('top', 0);
						}
					}
				});

				scope.$on("$destroy", function () {
					$(window).unbind('scroll');
				});
			}
		});
	}
});
