var ApiBuilder = require('claudia-api-builder');
var api = new ApiBuilder();

module.exports = api;

api.get('/hello', function () {
    return 'Hello World!';
});
