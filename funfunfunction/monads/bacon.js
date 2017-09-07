const Bacon = require("baconjs");
const stream = new Bacon.Bus();

stream.map(w => w.toUpperCase()).onValue(w => console.log(w));

stream.push("cat");
stream.push("meal");
stream.push("trumpet");
