var botBuilder = require('claudia-bot-builder');
var excuse = require('huh');

module.exports = botBuilder(function(request) {
    console.log(request);
    return 'Thanks for sending ' + request.text  + 
      '. Your message is very important to us, but ' + 
      excuse.get();
});