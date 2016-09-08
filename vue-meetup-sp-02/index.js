var example = new Vue({
    el: '#app',
    data: {
        count: 1
    },
    computed: {
        comp: function () {
            return this.count + 1
        }
    }
})