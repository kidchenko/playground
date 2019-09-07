const express = require('express');

const app = express();

app.get('/', (req, res) => res.send('Hello world!'));

app.get('/pg', (req, res) => {
  const query = await pgClient.query('select * from table');
  res.send(query.rows[0].message)
});

app.get('/redis', (req, res) => {
  client.get("myValue", function (err, value) {
    res.send(value)
  });
});