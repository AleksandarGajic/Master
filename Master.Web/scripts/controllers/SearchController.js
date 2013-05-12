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
        $('#advancedSearch').show();

        $scope.getSelectedCategories = function () {
            var retVal = [];
            $('.search .category-holder input:checked').each(function () {
                retVal.push($(this).val());
            });

            return retVal;
        };

        $scope.bindData = function (data) {
            if ($scope.page == 0) {
                $scope.Videos = data.Videos;
            } else {
                $scope.Videos = $scope.Videos.concat(data.Videos);
            }
            console.log($scope.Videos);
            $scope.HasMore = data.HasMore;
            $scope.TotalCount = data.TotalCount;
            ext.safeApply($scope);
        };

        server.searchSite($scope.term, $scope.page, $scope.getSelectedCategories(), $scope.bindData, ext.emptyFn);

        $('.search .category-holder input').click(function () {
            $scope.page = 0;
            server.searchSite($scope.term, $scope.page, $scope.getSelectedCategories(), $scope.bindData, ext.emptyFn);
        });

        $scope.showMore = function () {
            $scope.page++;
            server.searchSite($scope.term, $scope.page, $scope.getSelectedCategories(), $scope.bindData, ext.emptyFn);
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
            $('#advancedSearch').hide();
            $('.search .category-holder').hide();
            $('.search .category-holder input').unbind('click');
        });
    } ]
);