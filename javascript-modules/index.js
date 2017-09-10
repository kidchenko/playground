var Westeros;
(function(Westeros) {
    console.log('westeros', Westeros);
    (function(Structure) {
        console.log('structure', Structure);
        var Castle = (function(){
            function Castle(name) {
                this.name = name;
            }

            Castle.prototype.build = function() {
                console.log('Castle build: ' + this.name);
            }
            return Castle;
        })();
        Structure.Castle = Castle;
        var Wall = (function() {
            function Wall() {
                console.log('Wall constructed');
            }
            return Wall;
        })();
        Structure.Wall = Wall;
        console.log('structure', Structure);        
    })(Westeros.Structure || (Westeros.Structure = {}));
    console.log('westeros', Westeros);    
})(Westeros || (Westeros = {}));

var castle = new Westeros.Structure.Castle('king castle');
castle.build();
var wall = new Westeros.Structure.Wall();