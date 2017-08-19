const dragon = (name, size, element) => 
    `${name} is a ${size} dragon that breathes ${element}`

const curriedDragon = 
  name =>
    size =>
      element =>
        `${name} is a ${size} dragon that breathes ${element}`

const charizard = curriedDragon('charizard');
const mediumCharizard = charizard('medium');
const bigCharizard = charizard('big');
const waterCharizard = mediumCharizard('water'); 
const windCharizard = bigCharizard('wind');


console.log('normal:', dragon('charizard', 'big', 'fire'));
console.log('currying:', curriedDragon('dragonite')('medium')('lightning'));
console.log('currying:', waterCharizard);
console.log('currying:', windCharizard);
