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
