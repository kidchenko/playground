(function() {
  'use strict';
  var app = angular.module('gemStore', []);

  app.controller('StoreController', function () {
    this.products = gems;
  });

  var gems = [
    {
      name: 'Azurite',
      price: 100.50,
      canPurchase: false,
      souldOut: true
    },
    {
      name: 'Bloodstone',
      price: 5.95,
      canPurchase: true,
      souldOut: false
    },
    {
      name: 'Zircon',
      price: 3.95,
      canPurchase: true,
      souldOut: true
    }
  ];
}());
