# Directives

A directive is a marker on a HTML tag that tells Angular to run or reference some js code

### Modules

- Pieces of application
- Makes code maintanable, testable and readable
- Where we define dependencies for our app
- Modules can use other modules

`var app = angular.module('store', [ ])`

*store* application name

*[ ]* dependencies

### Expressions

Allow to insert dynamic values in HTML

```
<p>
  I am {{4 + 6}}
</p>
```
\+ More in

https://docs.angularjs.org/guide/expression
