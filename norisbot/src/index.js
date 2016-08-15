import Bot from 'slackbots';

let settings = {
  name: 'noris',
  token: process.env.NORIS_BOT_TOKEN,
}

var bot = new Bot(settings);

bot.on('start', () => {
  bot.postMessageToChannel('dinheiro', 'Hoje vou bater nuns cara e pegar todo o dinheiro!!!');
});
