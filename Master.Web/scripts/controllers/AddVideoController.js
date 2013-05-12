/**
* Dashboard controller
*/
Master.controller('AddVideoController', ['$scope', '$routeParams', 'ext', 'server', '$rootScope',
    function ($scope, $routeParams, ext, server, $rootScope) {
        if (Master.userId) {
            $scope.categories = $rootScope.categories;
            $rootScope.setSeoTitle('Add Video');
            $rootScope.SetBreadcrumb('Add Video');
            $scope.successfullyAdded = function () {
                $('#videoTitle').val('');
                $('#videoLink').val('');
                $('#videoDescription').val('');
                $('.add-video-page .category input').attr('checked', false);
                $('.add-video-page h3').html('Video is successfully added!').show();
            };
            $scope.failureAdded = function (error) {
                console.log(error);
            };

            $scope.getSelectedCategories = function () {
                var retVal = [];
                $('.add-video-page .category input:checked').each(function () {
                    retVal.push($(this).val());
                });

                return retVal;
            };

            $scope.addVideo = function () {
                $('.add-video-page h3').html('Adding video...').show();
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

                    server.createVideo(Master.userId, title, description, link, $scope.getSelectedCategories(), success, failure);
                } else {
                    $('.add-video-page h3').html('Some fields are not valid!').show();
                }
            };
        } else {
            history.go(-1);
        }
    } ]
);