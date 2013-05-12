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
directive('ngSearchField', ['ext', 'server', '$rootScope', function (ext, server, $rootScope) {
    return function (scope, element, attrs) {
        scope.selected = -1;
        scope.redirect = function (searchItem) {
            if (searchItem) {
                scope.searchSuggestion = [];
                ext.safeApply(scope);
                $("#search").val('');
                ext.redirect('video/' + $.trim(searchItem.Id));
            }
        };

        scope.getSearchTitle = function (searchItem) {
            if (searchItem) {
                var term = $("#search").val();
                var searchTerm = searchItem.Title.toLowerCase()
                $.each(term.split(' '), function (idx, val) {
                    searchTerm = searchTerm.replace(val, '<>' + val + '</>');
                });

                return searchTerm.replace(/<>/g, '<b>').replace(/<\/>/g, '</b>');
            }
        };

        scope.bindData = function (res) {
            scope.searchSuggestion = res.Videos;
            ext.safeApply(scope);
        };

        scope.searchSuggestion = [];
        scope.categories = $rootScope.categories;
        scope.showCategories = false;

        scope.showHideCategories = function () {
            $('.search .category-holder').toggle();
        }

        scope.getSelectedCategories = function () {
            var retVal = [];
            $('.search .category-holder input:checked').each(function () {
                retVal.push($(this).val());
            });

            return retVal;
        };

        scope.$watch(attrs.ngSearchField, function (value) {
            if (value) {
                $("#search").focus(function () {
                    $('header ul.search-suggestion').show();
                });

                $("#search").blur(function () {
                    setTimeout(function () {
                        $('header ul.search-suggestion').hide();
                    }, 300);
                });

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
                        // Key enter pressed
                        if (scope.selected > -1) {
                            scope.redirect(scope.searchSuggestion[scope.selected]);
                            scope.selected = -1;
                        } else {
                            scope.selected = -1;
                            scope.doSearch();
                        }
                    } else if (keycode == 40) {
                        // Key down pressed
                        scope.selected++;
                        if (scope.selected >= scope.searchSuggestion.length) {
                            scope.selected = scope.searchSuggestion.length - 1;
                        }

                        $('header ul.search-suggestion li').removeClass('selected').eq(scope.selected).addClass('selected');
                    } else if (keycode == 38) {
                        // Key up pressed
                        scope.selected--;
                        if (scope.selected < -1) {
                            scope.selected = -1;
                        }

                        $('header ul.search-suggestion li').removeClass('selected').eq(scope.selected).addClass('selected');
                    } else {
                        scope.selected = -1;
                        if ($(this).val().length >= 2) {
                            server.searchSitePreview($(this).val(), scope.getSelectedCategories(), scope.bindData, ext.emptyFn);
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
