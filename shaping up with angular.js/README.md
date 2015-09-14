# Shaping up with angular.js


## 1.1 Ramp Up

### Directives

A directive is a marker on a HTML tag that tells Angular to run or reference some js code

### Modules

- Pieces of application
- Makes code maintainable, testable and readable
- Where we define dependencies for our app
- Modules can use other modules

`var app = angular.module('store', [ ])`

`store`: application name

`[ ]`: dependencies

### Expressions

Allow to insert dynamic values in HTML

```
<p>
  I am {{4 + 6}}
</p>
```
\+ More in

https://docs.angularjs.org/guide/expression
***


## 1.3 Index HTML Setup

### Controllers

Controllers are where we define app behavior defining functions and values

```javascript
(function() {
  var app = angular.module('store', []);
  app.controller('StoreController', function () {

  });
})();
```

`(function () {})();` : iife - wrapping your js in a closure is a good habit

`app.controller`: Notice that controller is attached to (inside) our app

```html
<body>
  <div ng-controller="StoreController as store">
    <h1>{{ store.product.name }}</h1>
    <p>{{ store.product.price }}</p>
  </div>
</body>
```

`ng-controller`: Directive

`StoreController`: Controller name

`store`: Alias for controller name
***


## 1.5 Built-in Directives

### ng-show Directive

Only show the element if the expression is true


```html
<button ng-show="store.product.canPurchase"> Add to Cart</button>
```
### ng-hide Directive

Only hide the element if the expression is true

```html
<div ng-hide="store.product.souldOut">
</div>
```

### ng-repeat

Receive a array for controller and iterate

```html
<div ng-repeat="product in store.products">
  <h1>{{product.name}}</h1>
</div>
```

### What we have learned

- Directives - HTML annotations that triggers Javascript behaviors
- Modules - Where our application components live
- Controllers -  Where we add application behaviors
- Expressions - How values get displayed within the page 
