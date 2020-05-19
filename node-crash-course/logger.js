console.log(module);

const log = (name) => console.log(name);

log("Kidchenko");
console.log(__filename);
console.log(__dirname);
// Angular
module.name = "logger";
exports.log = log;
