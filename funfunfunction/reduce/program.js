/** 
 * https://youtu.be/1DMolJ2FrNY
 * 
 * Transform data.txt from pipe-separated file 
 mark jhonson|waffle iron|80|2
 ...
 Nikita smith|pot|20|3
 to a json where the key is the name of customer and the products is a array
 {
   'mark jhonson': [
     { name : 'waffle iron', price: '80', quantity: '2' },
     { name : 'blender', price: '200', quantity: '1' },
     ...
   ],
   'Nikita smith': [
     { name : 'waffle iron', price: '80', quantity: '1' },
     { name : 'knife', price: '10', quantity: '2' },
   ]
 }
*  
*/
import fs from 'fs';
const content = fs.readFileSync('data.txt', 'utf-8')
  .trim()
  .split('\n')
  .map(line => line.split('|'))
  .reduce((customers, line) => {
    const name = line[0];
    const product = line[1];
    const price = line[2];
    const quantity = line[3];
    customers[name] = customers[name] || [];
    customers[name].push({ product, price, quantity });
    return customers;
  }, {})

console.log('result', JSON.stringify(content, null, 2));