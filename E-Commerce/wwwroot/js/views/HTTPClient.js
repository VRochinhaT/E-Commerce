let HTTPClient = {
    post: function (url, data) {
        let config = {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        }


        return fetch(url, config);
    },

    get: function (url) {
        let config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        }

        return fetch(url, config);
    }
}