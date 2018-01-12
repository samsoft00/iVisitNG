$.typeahead({
    input: '.js-typeahead',
    minLength: 0,
    order: "asc",
    dynamic: true,
    delay: 500,
    backdrop: {
        "background-color": "#fff"
    },
    template: function(query, item) {

        var color = "#777";

        console.log(query);

        return '<span class="row">' +
            '<span class="avatar">' +
            '<img src="{{ImageUrl}}">' +
            "</span>" +
            '<span class="username">{{FirstName}} {{LastName}} <small style="color: ' + color + ';">({{RefNumber}})</small></span>' +
            '<span class="id">({{Id}})</span>' +
            "</span>";
    },
    emptyTemplate: "No Result for {{query}}",
    source: {
        user: {
            display: "RefNumber",
            data: [{
                "id": 415849,
                "FirstName": "Olabimpe",
                "LastName": "Omolola",
                "ImageUrl": "https://avatars3.githubusercontent.com/u/415849",
                "RefNumber": "DPR-467515"
            }],
            ajax: function (query) {
                return {
                    type: "GET",
                    url: "/api/visitors/getVisitorByRef?callback=?",
                    path: "data",
                    data: {
                        q: "{{query}}"
                    },
                    callback: {
                        done: function (data) {
                            console.log(data);
                            return data;
                        }
                    }
                }
            }

        }
    },
    callback: {
        onClick: function(node, a, item, event) {

            // You can do a simple window.location of the item.href
            alert(JSON.stringify(item));

        },
        onSendRequest: function(node, query) {
            console.log('request is sent');
        },
        onReceiveRequest: function(node, query) {
            console.log('request is received');
        }
    },
    debug: true
});