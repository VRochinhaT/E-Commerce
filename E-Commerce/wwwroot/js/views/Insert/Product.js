let product = {
    insert: function () {
        //let id = document.querySelector("#id");
        let name = document.querySelector("#name");
        let category = document.querySelector("#category");
        let sellPrice = document.querySelector("#sell_price");
        let buyPrice = document.querySelector("#buy_price");

        //if (id.value.trim() == "" || name.value.trim() == "" || sellPrice.value.trim() == "" || buyPrice.value.trim() == "") {
        if (name.value.trim() == "" || sellPrice.value.trim() == "" || buyPrice.value.trim() == "") {
            document.querySelector("#divError").innerHTML = "Forneça todos os dados";
            document.querySelector("#divError").style.display = "block";
        }
        else {

            let data = {
                //id: id.value,
                name: name.value,
                category: category.value,
                sellPrice: sellPrice.value,
                buyPrice: buyPrice.value
            };

            HTTPClient.post("insert/Insert", data)
                .then(function (retornoServidor) {
                    return retornoServidor.json();
                })
                .then(function (obj) {
                    //sucesso
                    if (obj.operation) {
                        window.location.href = "index"; //controller/action
                        alert(obj.msg);
                    }
                    else {
                        alert(obj.msg);
                    }
                })
                .catch(function () {
                    //erro
                    alert("Um erro ocorreu.");
                })
                .finally(function () {

                });

            document.querySelector("#divError").style.display = "none";
        }
    }
}
