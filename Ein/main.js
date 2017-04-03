Oidc.Log.logger = console;
Oidc.Log.level = Oidc.Log.DEBUG;

// helper function to show data to the user
function display(selector, data) {
    if (data && typeof data === 'string') {
        data = JSON.parse(data);
    }
    if (data) {
        data = JSON.stringify(data, null, 2);
    }

    $(selector).text(data);
}

var settings = {
    authority: 'https://localhost:44396/',
    client_id: 'ein',

    // for signing in with a redirect
    redirect_uri: 'http://ein.devl:56668',

    // for signing in with a popup
    silent_redirect_uri: 'http://ein.devl:56668/silent-renew.html',
    post_logout_redirect_uri: 'http://ein.devl:56668',

    response_type: 'id_token token',
    scope: 'openid profile email api',

    filterProtocolClaims: true,

    accessTokenExpiringNotificationTime: 4,
    automaticSilentRenew: true
};

var manager = new Oidc.UserManager(settings);
var user;

if (window.location.hash) {
    manager.signinRedirectCallback()
        .then(function() {
            window.location.replace('#');

            if (typeof window.history.replaceState == 'function') {
                history.replaceState({}, '', window.location.href.slice(0, -1));
            }
        }, function(error) {
            manager.signinRedirect();
        });
}
else {
    manager.signinRedirect();
}

manager.events.addUserLoaded(function (loadedUser) {
    user = loadedUser;
    display('.js-user', user);
});

manager.events.addSilentRenewError(function (error) {
    console.error("error while renewing the access token", error);
});

manager.events.addUserSignedOut(function () {
    alert('The user has signed out');
    manager.signinRedirect();
});

$('.js-call-api').on('click', function () {
    var headers = {};
    if (user && user.access_token) {
        headers['Authorization'] = 'Bearer ' + user.access_token;
    }

    $.ajax({
        url: 'http://sample-api.devl:60136/values',
        method: 'GET',
        dataType: 'json',
        headers: headers
    }).then(function (data) {
        display('.js-api-result', data);
    }).catch(function (error) {
        display('.js-api-result', {
            status: error.status,
            statusText: error.statusText,
            response: error.responseJSON
        });
    });
});

$('.js-logout').on('click', function () {
    manager
        .signoutRedirect()
        .catch(function (error) {
            console.error('error while signing out user', error);
        });
});