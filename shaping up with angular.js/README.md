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

Repeat a section for each item an Array

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
***


## 2.1 Filters and a New Directive

### Directives we know & love

- ng-app - attach the app module to the page `<html ng-app="store">`
- ng-controller - attach a Controller function to the page `<body ng-controller="StoreController as store">`
- ng-show / ng-hide - display a section based on an Expression `<h1 ng-show="hasName"> Hello, {{name}}</h1>`
- ng-repeat - repeat a section for each item an Array

### Our first filter

```html
  <em class="pull-right">{{product.price | currency}}</em>
```

- ` | ` Pipe - "send the output into". *Notice it gives the dollar sign (localized). Specifies number of decimals*
- `currency` - format to currency

### Formatting with Filters

**Our recipe '{{ data* | filter:options}}'**

- date
- uppercase & lowercase
- limitTo
- orderBy

### Using ng-src for images

**Using an expression inside `src` attribute causes an error!**
***


## 2.6 Tabs Inside Out

### Introducing a new directive

`ng-click`: `ng-click="tab = 1"` assigning a value to *variable*

When `ng-click` changes the value of a variable...

... the `{{variable}}` expression automatically gets updated!

Expression define a 2-way data biding

### Setting the initial value

`ng-init` allows us to use an expression in the current scope

```html
<section ng-init="tab = 1">
  {{tab}}
  <a href ng-click="tab = 2">Click</a>
<section>
```

### ng-class directive

`ng-class="{ active:tab == 1 }"`

- `active`: name of the class to set
- `tab == 1`: expression to evaluate, if true, set the class

### Feels dirty, doesn't it?

**The best choice to put your app logic is in controller**
***


## 3.1 Forms and Models

### Introducing ng-model

`ng-model`: bind the form element value to a property

### Two more binding examples

- checkbox
  - set value to true or false
- radio buttons
  - set value based on which is selected
***


## 3.5 Accepting Submissions

- We could do ng-init, but we're better of creating a controller
- Shortcut to `SomeController` is `someCtrl`

`ng-submit` allows us to call a function when the form is submitted. e.g. `ng-submit="reviewCtrl.addReview(product)"`
***


## 3.8 Form Validations 101

- Angular has great client side validations
- Turn off default html validation `<form name="reviewForm" novalidate><form>`
- `$valid` comes with angular and return `true` or `false` if form is valid

```html
<div>
  reviewForm is {{reviewForm.$valid}}
</div>
```

### Preventing the submit

```html
<form name="reviewForm" ng-submit="reviewForm.$valid && reviewCtrl.addReview(product)"></form>
```

- `ng-submit="reviewForm.$valid && ..."` if valid is false, then addReview is never called

### The input classes

Angular add classes to input

- `ng-valid` to valid fields
- `ng-invalid` to invalid fields
- `ng-pristine` to intact form
- `ng-dirty` to altered form (even if you delete the value)
***


## 4.1 Directives

### Using `ng-include` for templates

`ng-include`, fetch, compiles and includes an external HTML fragment.

### Why write a directive?

Directives allow you to write  HTML that expresses the behavior of your application. Expresses is the real power off directives.

**dash** in HTML translate to ...**camelCase** in JavaScript

*notice, prefer not using  self-closing tag...`<product-title />`...some browsers don't like self-closing tags*

- Use elements directives for UI widgets and attribute directives for mixin behaviors... like a tooltip
- When you're writing the behavior and intent from just the HTML
