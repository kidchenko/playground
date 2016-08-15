'use strict';

var _slackbots = require('slackbots');

var _slackbots2 = _interopRequireDefault(_slackbots);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var settings = {
  name: 'noris',
  token: process.env.NORIS_BOT_TOKEN
};

var bot = new _slackbots2.default(settings);

bot.on('start', function () {
  bot.postMessageToChannel('dinheiro', 'Hoje vou bater nuns cara e pegar todo o dinheiro!!!');
});