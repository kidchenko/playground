const { Client } = require('pg');
const redis = require("redis"),

const PORT = 3000;
const HOST = '0.0.0.0';

const pgClient = new Client();
const redisClient = redis.createClient();

redisClient.on("error", function (err) {
  console.log("Error " + err);
});

await pgClient.connect();
client.set("myValue", "jucaValue", redis.print);

app.listen(PORT, HOST);
console.log(`Server running on http://${HOST}:${PORT}`);

module.exports = app;