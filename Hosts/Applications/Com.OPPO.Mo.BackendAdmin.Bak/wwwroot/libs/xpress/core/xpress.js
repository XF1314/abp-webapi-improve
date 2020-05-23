var xpress = xpress || {};
(function () {

    /* Application paths *****************************************/

    //Current application root path (including virtual directory if exists).
    xpress.appPath = xpress.appPath || '/';

    xpress.pageLoadTime = new Date();

    //Converts given path to absolute path using xpress.appPath variable.
    xpress.toAbsAppPath = function (path) {
        if (path.indexOf('/') === 0) {
            path = path.substring(1);
        }

        return xpress.appPath + path;
    };

    /* LOGGING ***************************************************/
    //Implements Logging API that provides secure & controlled usage of console.log

    xpress.log = xpress.log || {};

    xpress.log.levels = {
        DEBUG: 1,
        INFO: 2,
        WARN: 3,
        ERROR: 4,
        FATAL: 5
    };

    xpress.log.level = xpress.log.levels.DEBUG;

    xpress.log.log = function (logObject, logLevel) {
        if (!window.console || !window.console.log) {
            return;
        }

        if (logLevel !== undefined && logLevel < xpress.log.level) {
            return;
        }

        console.log(logObject);
    };

    xpress.log.debug = function (logObject) {
        xpress.log.log("DEBUG: ", xpress.log.levels.DEBUG);
        xpress.log.log(logObject, xpress.log.levels.DEBUG);
    };

    xpress.log.info = function (logObject) {
        xpress.log.log("INFO: ", xpress.log.levels.INFO);
        xpress.log.log(logObject, xpress.log.levels.INFO);
    };

    xpress.log.warn = function (logObject) {
        xpress.log.log("WARN: ", xpress.log.levels.WARN);
        xpress.log.log(logObject, xpress.log.levels.WARN);
    };

    xpress.log.error = function (logObject) {
        xpress.log.log("ERROR: ", xpress.log.levels.ERROR);
        xpress.log.log(logObject, xpress.log.levels.ERROR);
    };

    xpress.log.fatal = function (logObject) {
        xpress.log.log("FATAL: ", xpress.log.levels.FATAL);
        xpress.log.log(logObject, xpress.log.levels.FATAL);
    };

    /* LOCALIZATION ***********************************************/

    xpress.localization = xpress.localization || {};

    xpress.localization.values = {};

    xpress.localization.localize = function (key, sourceName) {
        sourceName = sourceName || xpress.localization.defaultResourceName;

        var source = xpress.localization.values[sourceName];

        if (!source) {
            xpress.log.warn('Could not find localization source: ' + sourceName);
            return key;
        }

        var value = source[key];
        if (value === undefined) {
            return key;
        }

        var copiedArguments = Array.prototype.slice.call(arguments, 0);
        copiedArguments.splice(1, 1);
        copiedArguments[0] = value;

        return xpress.utils.formatString.apply(this, copiedArguments);
    };

    xpress.localization.getResource = function (name) {
        return function () {
            var copiedArguments = Array.prototype.slice.call(arguments, 0);
            copiedArguments.splice(1, 0, name);
            return xpress.localization.localize.apply(this, copiedArguments);
        };
    };

    xpress.localization.defaultResourceName = undefined;

    /* AUTHORIZATION **********************************************/

    xpress.auth = xpress.auth || {};

    xpress.auth.policies = xpress.auth.policies || {};

    xpress.auth.grantedPolicies = xpress.auth.grantedPolicies || {};

    xpress.auth.isGranted = function (policyName) {
        return xpress.auth.policies[policyName] !== undefined && xpress.auth.grantedPolicies[policyName] !== undefined;
    };

    xpress.auth.isAnyGranted = function () {
        if (!arguments || arguments.length <= 0) {
            return true;
        }

        for (var i = 0; i < arguments.length; i++) {
            if (xpress.auth.isGranted(arguments[i])) {
                return true;
            }
        }

        return false;
    };

    xpress.auth.areAllGranted = function () {
        if (!arguments || arguments.length <= 0) {
            return true;
        }

        for (var i = 0; i < arguments.length; i++) {
            if (!xpress.auth.isGranted(arguments[i])) {
                return false;
            }
        }

        return true;
    };

    xpress.auth.tokenCookieName = 'Xpress.AuthToken';

    xpress.auth.setToken = function (authToken, expireDate) {
        xpress.utils.setCookieValue(xpress.auth.tokenCookieName, authToken, expireDate, xpress.appPath, xpress.domain);
    };

    xpress.auth.getToken = function () {
        return xpress.utils.getCookieValue(xpress.auth.tokenCookieName);
    };

    xpress.auth.clearToken = function () {
        xpress.auth.setToken();
    };

    /* SETTINGS *************************************************/

    xpress.setting = xpress.setting || {};

    xpress.setting.values = xpress.setting.values || {};

    xpress.setting.get = function (name) {
        return xpress.setting.values[name];
    };

    xpress.setting.getBoolean = function (name) {
        var value = xpress.setting.get(name);
        return value === 'true' || value === 'True';
    };

    xpress.setting.getInt = function (name) {
        return parseInt(xpress.setting.values[name]);
    };

    /* NOTIFICATION *********************************************/
    //Defines Notification API, not implements it

    xpress.notify = xpress.notify || {};

    xpress.notify.success = function (message, title, options) {
        xpress.log.warn('xpress.notify.success is not implemented!');
    };

    xpress.notify.info = function (message, title, options) {
        xpress.log.warn('xpress.notify.info is not implemented!');
    };

    xpress.notify.warn = function (message, title, options) {
        xpress.log.warn('xpress.notify.warn is not implemented!');
    };

    xpress.notify.error = function (message, title, options) {
        xpress.log.warn('xpress.notify.error is not implemented!');
    };

    /* MESSAGE **************************************************/
    //Defines Message API, not implements it

    xpress.message = xpress.message || {};

    xpress.message._showMessage = function (message, title) {
        alert((title || '') + ' ' + message);
    };

    xpress.message.info = function (message, title) {
        xpress.log.warn('xpress.message.info is not implemented!');
        return xpress.message._showMessage(message, title);
    };

    xpress.message.success = function (message, title) {
        xpress.log.warn('xpress.message.success is not implemented!');
        return xpress.message._showMessage(message, title);
    };

    xpress.message.warn = function (message, title) {
        xpress.log.warn('xpress.message.warn is not implemented!');
        return xpress.message._showMessage(message, title);
    };

    xpress.message.error = function (message, title) {
        xpress.log.warn('xpress.message.error is not implemented!');
        return xpress.message._showMessage(message, title);
    };

    xpress.message.confirm = function (message, titleOrCallback, callback) {
        xpress.log.warn('xpress.message.confirm is not properly implemented!');

        if (titleOrCallback && !(typeof titleOrCallback === 'string')) {
            callback = titleOrCallback;
        }

        var result = confirm(message);
        callback && callback(result);
    };

    /* UI *******************************************************/

    xpress.ui = xpress.ui || {};

    /* UI BLOCK */
    //Defines UI Block API and implements basically

    var $xpressBlockArea = document.createElement('div');
    $xpressBlockArea.classList.add('xpress-block-area');

    /* opts: { //Can be an object with options or a string for query a selector
     *  elm: a query selector (optional - default: document.body)
     *  busy: boolean (optional - default: false)
     *  promise: A promise with always or finally handler (optional - auto unblocks the ui if provided)
     * }
     */
    xpress.ui.block = function (opts) {
        if (!opts) {
            opts = {};
        } else if (typeof opts === 'string') {
            opts = {
                elm: opts
            };
        }

        var $elm = document.querySelector(opts.elm) || document.body;

        if (opts.busy) {
            $xpressBlockArea.classList.add('xpress-block-area-busy');
        } else {
            $xpressBlockArea.classList.remove('xpress-block-area-busy');
        }

        if (document.querySelector(opts.elm)) {
            $xpressBlockArea.style.position = 'absolute';
        } else {
            $xpressBlockArea.style.position = 'fixed';
        }

        $elm.appendChild($xpressBlockArea);

        if (opts.promise) {
            if (opts.promise.always) { //jQuery.Deferred style
                opts.promise.always(function () {
                    xpress.ui.unblock({
                        $elm: opts.elm
                    });
                });
            } else if (opts.promise['finally']) { //Q style
                opts.promise['finally'](function () {
                    xpress.ui.unblock({
                        $elm: opts.elm
                    });
                });
            }
        }
    };

    /* opts: {
     *    
     * }
     */
    xpress.ui.unblock = function (opts) {
        var element = document.querySelector('.xpress-block-area');
        if (element) {
            element.classList.add('xpress-block-area-disappearing');
            setTimeout(function () {
                if (element) {
                    element.classList.remove('xpress-block-area-disappearing');
                    element.parentElement.removeChild(element);
                }
            }, 250);
        }
    };

    /* UI BUSY */
    //Defines UI Busy API, not implements it

    xpress.ui.setBusy = function (opts) {
        if (!opts) {
            opts = {
                busy: true
            };
        } else if (typeof opts === 'string') {
            opts = {
                elm: opts,
                busy: true
            };
        }

        xpress.ui.block(opts);
    };

    xpress.ui.clearBusy = function (opts) {
        xpress.ui.unblock(opts);
    };

    /* SIMPLE EVENT BUS *****************************************/

    xpress.event = (function () {
        var _callbacks = {};
        var on = function (eventName, callback) {
            if (!_callbacks[eventName]) {
                _callbacks[eventName] = [];
            }

            _callbacks[eventName].push(callback);
        };

        var off = function (eventName, callback) {
            var callbacks = _callbacks[eventName];
            if (!callbacks) {
                return;
            }

            var index = -1;
            for (var i = 0; i < callbacks.length; i++) {
                if (callbacks[i] === callback) {
                    index = i;
                    break;
                }
            }

            if (index < 0) {
                return;
            }

            _callbacks[eventName].splice(index, 1);
        };

        var trigger = function (eventName) {
            var callbacks = _callbacks[eventName];
            if (!callbacks || !callbacks.length) {
                return;
            }

            var args = Array.prototype.slice.call(arguments, 1);
            for (var i = 0; i < callbacks.length; i++) {
                callbacks[i].apply(this, args);
            }
        };

        // Public interface ///////////////////////////////////////////////////

        return {
            on: on,
            off: off,
            trigger: trigger
        };
    })();


    /* UTILS ***************************************************/

    xpress.utils = xpress.utils || {};

    /* Creates a name namespace.
    *  Example:
    *  var taskService = xpress.utils.createNamespace(xpress, 'services.task');
    *  taskService will be equal to xpress.services.task
    *  first argument (root) must be defined first
    ************************************************************/
    xpress.utils.createNamespace = function (root, ns) {
        var parts = ns.split('.');
        for (var i = 0; i < parts.length; i++) {
            if (typeof root[parts[i]] === 'undefined') {
                root[parts[i]] = {};
            }

            root = root[parts[i]];
        }

        return root;
    };

    /* Find and replaces a string (search) to another string (replacement) in
    *  given string (str).
    *  Example:
    *  xpress.utils.replaceAll('This is a test string', 'is', 'X') = 'ThX X a test string'
    ************************************************************/
    xpress.utils.replaceAll = function (str, search, replacement) {
        var fix = search.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
        return str.replace(new RegExp(fix, 'g'), replacement);
    };

    /* Formats a string just like string.format in C#.
    *  Example:
    *  xpress.utils.formatString('Hello {0}','Tuana') = 'Hello Tuana'
    ************************************************************/
    xpress.utils.formatString = function () {
        if (arguments.length < 1) {
            return null;
        }

        var str = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var placeHolder = '{' + (i - 1) + '}';
            str = xpress.utils.replaceAll(str, placeHolder, arguments[i]);
        }

        return str;
    };

    xpress.utils.toPascalCase = function (str) {
        if (!str || !str.length) {
            return str;
        }

        if (str.length === 1) {
            return str.charAt(0).toUpperCase();
        }

        return str.charAt(0).toUpperCase() + str.substr(1);
    };

    xpress.utils.toCamelCase = function (str) {
        if (!str || !str.length) {
            return str;
        }

        if (str.length === 1) {
            return str.charAt(0).toLowerCase();
        }

        return str.charAt(0).toLowerCase() + str.substr(1);
    };

    xpress.utils.truncateString = function (str, maxLength) {
        if (!str || !str.length || str.length <= maxLength) {
            return str;
        }

        return str.substr(0, maxLength);
    };

    xpress.utils.truncateStringWithPostfix = function (str, maxLength, postfix) {
        postfix = postfix || '...';

        if (!str || !str.length || str.length <= maxLength) {
            return str;
        }

        if (maxLength <= postfix.length) {
            return postfix.substr(0, maxLength);
        }

        return str.substr(0, maxLength - postfix.length) + postfix;
    };

    xpress.utils.isFunction = function (obj) {
        return !!(obj && obj.constructor && obj.call && obj.apply);
    };

    /**
     * parameterInfos should be an array of { name, value } objects
     * where name is query string parameter name and value is it's value.
     * includeQuestionMark is true by default.
     */
    xpress.utils.buildQueryString = function (parameterInfos, includeQuestionMark) {
        if (includeQuestionMark === undefined) {
            includeQuestionMark = true;
        }

        var qs = '';
        function addSeperator() {
            if (!qs.length) {
                if (includeQuestionMark) {
                    qs = qs + '?';
                }
            } else {
                qs = qs + '&';
            }
        }

        for (var i = 0; i < parameterInfos.length; ++i) {
            var parameterInfo = parameterInfos[i];
            if (parameterInfo.value === undefined) {
                continue;
            }

            if (parameterInfo.value === null) {
                parameterInfo.value = '';
            }

            addSeperator();

            if (parameterInfo.value.toJSON && typeof parameterInfo.value.toJSON === "function") {
                qs = qs + parameterInfo.name + '=' + encodeURIComponent(parameterInfo.value.toJSON());
            } else if (Array.isArray(parameterInfo.value) && parameterInfo.value.length) {
                for (var j = 0; j < parameterInfo.value.length; j++) {
                    if (j > 0) {
                        addSeperator();
                    }

                    qs = qs + parameterInfo.name + '[' + j + ']=' + encodeURIComponent(parameterInfo.value[j]);
                }
            } else {
                qs = qs + parameterInfo.name + '=' + encodeURIComponent(parameterInfo.value);
            }
        }

        return qs;
    };

    /**
     * Sets a cookie value for given key.
     * This is a simple implementation created to be used by xpress.
     * Please use a complete cookie library if you need.
     * @param {string} key
     * @param {string} value 
     * @param {Date} expireDate (optional). If not specified the cookie will expire at the end of session.
     * @param {string} path (optional)
     */
    xpress.utils.setCookieValue = function (key, value, expireDate, path) {
        var cookieValue = encodeURIComponent(key) + '=';

        if (value) {
            cookieValue = cookieValue + encodeURIComponent(value);
        }

        if (expireDate) {
            cookieValue = cookieValue + "; expires=" + expireDate.toUTCString();
        }

        if (path) {
            cookieValue = cookieValue + "; path=" + path;
        }

        document.cookie = cookieValue;
    };

    /**
     * Gets a cookie with given key.
     * This is a simple implementation created to be used by xpress.
     * Please use a complete cookie library if you need.
     * @param {string} key
     * @returns {string} Cookie value or null
     */
    xpress.utils.getCookieValue = function (key) {
        var equalities = document.cookie.split('; ');
        for (var i = 0; i < equalities.length; i++) {
            if (!equalities[i]) {
                continue;
            }

            var splitted = equalities[i].split('=');
            if (splitted.length !== 2) {
                continue;
            }

            if (decodeURIComponent(splitted[0]) === key) {
                return decodeURIComponent(splitted[1] || '');
            }
        }

        return null;
    };

    /**
     * Deletes cookie for given key.
     * This is a simple implementation created to be used by xpress.
     * Please use a complete cookie library if you need.
     * @param {string} key
     * @param {string} path (optional)
     */
    xpress.utils.deleteCookie = function (key, path) {
        var cookieValue = encodeURIComponent(key) + '=';

        cookieValue = cookieValue + "; expires=" + (new Date(new Date().getTime() - 86400000)).toUTCString();

        if (path) {
            cookieValue = cookieValue + "; path=" + path;
        }

        document.cookie = cookieValue;
    }

    /* SECURITY ***************************************/
    xpress.security = xpress.security || {};
    xpress.security.antiForgery = xpress.security.antiForgery || {};

    xpress.security.antiForgery.tokenCookieName = 'XSRF-TOKEN';
    xpress.security.antiForgery.tokenHeaderName = 'X-XSRF-TOKEN';

    xpress.security.antiForgery.getToken = function () {
        return xpress.utils.getCookieValue(xpress.security.antiForgery.tokenCookieName);
    };

})();