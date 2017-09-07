const fetch = require("node-fetch");
const Bacon = require("baconjs");

const getInPortuguese = word => {
  const url = `https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=pt&dt=t&q=${encodeURIComponent(
    word
  )}`;

  const promise = fetch(url)
    .then(response => response.json())
    .then(json => json[0][0][0]);

  const stream = Bacon.fromPromise(promise);
  return stream;
};

const stream = new Bacon.Bus();

stream
  .flatMap(word => getInPortuguese(word))
  // .map(word => getInPortuguese(word)) // map vs flatMap
  .onValue(word => console.log(word));

stream.push("cat");
stream.push("meal");
stream.push("trumpet");
