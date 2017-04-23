exports.handler = function(event, context) {
    console.log(event);
    context.succeed('Hello ' + event.name + '!' );
};