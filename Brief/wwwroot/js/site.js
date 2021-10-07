// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


Vue.component("text-field", {
    props: {
        title: String
    },
    template: "#text-field"
});

Vue.component("fields-list", {
    data() {
        return {
            fields: [{
                title: "Контактна особа"
            }]
        }
    },
    template: "#fields-list"
});

const app = new Vue({
    el: "#app"
});