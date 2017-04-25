var ApiBuilder = require('claudia-api-builder');
var api = new ApiBuilder();

module.exports = api;

api.get('/hello', function () {
    return 'Hello World!';
});

api.get('/greet', function (request) {
  var superb = require('superb');
  return request.queryString.name + ' is ' + superb();
});
