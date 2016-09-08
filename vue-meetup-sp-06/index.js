new Vue({
  el: '#app',
  data: {
    message: 'Meetup Vue.js SP!'
  },
  methods: {
    reverseMessage: function () {
      this.message = this.message.split('').reverse().join('')
    }
  }
})
