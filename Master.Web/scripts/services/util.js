/**
* Utility functions
*/
Master.service('util', [function () {
	this.util = {
		/**
		* Bind function to scope
		* @param fn [Function] - function that need scope change
		* @param scope [Object] - new scope
		* @param args [Array] - custom arguments
		* @param appendArgs [Bool] - whetever to append args to other(respond) args or pass them as only args to bind fucntion
		* @return Function
		*/
		_customBind: function (fn, scope, args, appendArgs) {
			if (arguments.length === 2) {
				return function () {
					return fn.apply(scope, arguments);
				};
			}

			var method = fn,
                slice = Array.prototype.slice;

			return function () {
				var callArgs = args || arguments;

				if (appendArgs === true) {
					callArgs = slice.call(arguments, 0);
					callArgs = callArgs.concat(args);
				} else if (typeof appendArgs == 'number') {
					callArgs = slice.call(arguments, 0);
					I5.Common.Array.insert(callArgs, appendArgs, args);
				}

				return method.apply(scope || window, callArgs);
			};
		},

		_formatDescriptionText: function (txt) {
			var status = txt.replace(/((https?|s?ftp|ssh)\:\/\/[^"\s\<\>]*[^.,;'">\:\s\<\>\)\]\!])/g, function (url) {
				return '<a href="' + url + '" target="_blank">' + url + "</a>"
			});

			return status
		},

		/**
		* URL encodes passed string. This function will first run the JavaScript 'encodeURIComponent' function
		* and then encoded some additional characters that are valid URL characters:
		* . (period).
		* @param {string} originalRoute Original string that should be passed to redirectTo method.
		* @return {string} Returns URL encoded string.
		*/
		_encodeRoute: function (originalRoute) {
			var retVal = originalRoute;
			if (retVal) {
				retVal = encodeURIComponent(retVal);

				// the period and tilda characters ('.', '~') are valid URL characters and will
				// not be encoded by 'encodeURIComponent' function so we have to manually URL encode it.
				retVal = retVal.replace(/\./g, '%2E');
				retVal = retVal.replace(/\~/g, '%7E');
			}

			return retVal;
		},

		/**
		*  Format duration in seconds in appropriate format.
		*  @param [seconds] - duration
		*  @param [h] - return hours
		*  @param [m] - return minutes
		*  @param [s] - return seconds
		*/
		_formatMovieDuration: function (seconds, h, m, s) {
			var ret = [];
			if (seconds >= 3600 && h) {
				h = Math.floor(seconds / 3600);
				ret.push(h);
				seconds -= (h * 3600);
			} else if (h) {
				ret.push('0');
			}

			if (seconds >= 60 && m) {
				m = Math.floor(seconds / 60);
				ret.push((m < 10) ? '0' + m : m);
				seconds -= (m * 60);
			} else if (m) {
				ret.push('00');
			}

			if (seconds >= 0 && s) {
				ret.push((seconds < 10) ? '0' + seconds : seconds);
			} else if (s) {
				ret.push('00');
			}
			return ret.join(':');
		},

		/**
		* URL decodes passed string. This function will first run the JavaScript 'decodeURIComponent' function
		* and then decode some additional characters:
		* . (period).
		* @param {string} encodedRoute The encoded route received from the router.
		* @return {string} Returns URL decoded string.
		*/
		_decodeRoute: function (encodedRoute) {
			var retVal = encodedRoute;
			if (retVal) {
				retVal = decodeURIComponent(retVal);
			}

			return retVal;
		},

		/**
		* Empty function
		*/
		_emptyFn: function () {
		},
		/**
		* Perform apply only if apply isnt in progress
		*/
		_safeApply: function (scope, callback) {
			if (scope.$$phase != '$apply' && scope.$$phase != '$digest' &&
                (!scope.$root || (scope.$root.$$phase != '$apply' && scope.$root.$$phase != '$digest'))) {
				scope.$apply();
			}
			if (angular.isFunction(callback)) {
				callback();
			}
		},

		_startsWith: function (word, starts) {
			if (starts === word.substr(0, starts.length)) {
				return true;
			}

			return false;
		},
		/**
		* Perform apply only if apply isnt in progress
		*/
		_getFriendlyUrlForVideo: function (link) {
			var retVal = link;
			if (self._startsWith(link, 'http://www.youtube.com/watch') && link.split('=').length > 1) {
				retVal = "http://www.youtube.com/v/" + link.split('=')[1];
			}

			return retVal;
		},
		_getDate: function (time) {
			time = time.replace('/Date(', '').replace(')/', '');
			time = parseInt(time);
			time = new Date(time);
			return time.getUTCDate() + '.' + (time.getUTCMonth() + 1) + '.' + time.getUTCFullYear() + '.';
		},
		_testEmail: function (email) {
			var pattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])",
				regExp = new RegExp(pattern, "i");

			return regExp.test(email);
		},
		_getTimeAgo: function (created) {
			created = created.replace('/Date(', '').replace(')/', '');
			created = parseInt(created);
			var curTime = new Date(),
               diff = parseFloat(curTime.getTime() - created) / 1000,
               timeAgo = [diff, ' second'];

			if (diff / (365 * 30 * 24 * 60 * 60) >= 1) { //*** Month ago
				timeAgo = [Math.floor(diff / (365 * 30 * 24 * 60 * 60)), ' year'];
			} else if (diff / (30 * 24 * 60 * 60) >= 1) { //*** Month ago
				timeAgo = [Math.floor(diff / (30 * 24 * 60 * 60)), ' month'];
			} else if (diff / (24 * 60 * 60) >= 1) { //*** Days ago
				timeAgo = [Math.floor(diff / (24 * 60 * 60)), ' day'];
			} else if (diff / (60 * 60) >= 1) { //*** Hours ago
				timeAgo = [Math.floor(diff / (60 * 60)), ' hour'];
			} else if (diff / 60) {
				timeAgo = [Math.floor(diff / 60), ' minute'];
			}

			return timeAgo.join('') + (timeAgo[0] > 1 ? 's' : '') + ' ago';
		},
		_getImageFromVideo: function (video) {
			var retVal = video.VideoImage,
				link = video.VideoLink;			

			if (self._startsWith(link, 'http://www.youtube.com/watch') && link.split('=').length > 1) {
				retVal = 'http://i.ytimg.com/vi/' + link.split('=')[1] + '/hqdefault.jpg'
			}

			return retVal;
		},
		/**
		* Redirect to passed hash
		*/
		_redirect: function (hash) {
			window.location.hash = (/#/.test(hash)) ? hash : '#/' + hash;
		},
		_validateField: function ($element, isValid) {
			if ($.trim($element.val()) == '') {
				isValid = false;
				$element.addClass('error');
			} else {
				$element.removeClass('error');
			}

			return isValid;
		}
	};
	var self = this.util;

	return {
		bind: this.util._customBind,
		validateField: this.util._validateField,
		emptyFn: this.util._emptyFn,
		encodeRoute: this.util._encodeRoute,
		decodeRoute: this.util._decodeRoute,
		safeApply: this.util._safeApply,
		getFriendlyUrlForVideo: this.util._getFriendlyUrlForVideo,
		getDate: this.util._getDate,
		getImageFromVideo: this.util._getImageFromVideo,
		getTimeAgo: this.util._getTimeAgo,
		testEmail: this.util._testEmail,
		redirect: this.util._redirect,
		formatDescriptionText: this.util._formatDescriptionText,
		formatMovieDuration: this.util._formatMovieDuration
	}
} ]);
//*** Extensions(ext) User friendly util shortcut
Master.service('ext', ['util', function (util) {
	return util;
} ]);
