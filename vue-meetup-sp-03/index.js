var MeetupComponent = Vue.extend({
    template: '<div>Meetup Vue SP!</div>'
})

Vue.component('meetup', MeetupComponent)

new Vue({
    el: '#app'
})