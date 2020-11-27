let product = {
    search: function () {
        $.fancybox.open({
            //src: 'http://unoeste.br',
            src: '/Insert/SearchProduct',
            type: 'iframe',
            smallBtn: true,
            iframe: {
                preload: false,
            }
        })
    },

    executeSearch: function () {

        let q = document.getElementById("txtSearch").value;
        q = encodeURIComponent(q);

        HTTPClient.get("ExecuteSearch?q="+q)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then(function (obj) {
                product.loadGrid(obj);
            })
            .catch(function () {
                //erro
                alert("Um erro ocorreu.");
            })
            .finally(function () {

            });
    },

    loadGrid: function (datas) {
        let tableResult = document.getElementById("tableResult");
        let tbodyResult = document.getElementById("tbodyResult");

        tbodyResult.innerHTML = "";

        let linhas = "";

        datas.forEach((item) => {

            linhas += 
                `<tr>
                    <td>${item.name}</td>
                    <td><a onclick="product.selectSearch(${item.id},'${item.name}','${item.category}',${item.sellPrice},${item.buyPrice})">X</a ></td >
                </tr>`;
        });

        tbodyResult.innerHTML = linhas;
        tableResult.style.display = "table";
    },

    selectSearch: function (id, name, category, sellPrice, buyPrice) {
        alert(id + " " + name + " " + category + " " + sellPrice + " " + buyPrice);

        window.parent.document.getElementById("id").value = id;
        window.parent.document.getElementById("name").value = name;
        window.parent.document.getElementById("category").value = category;
        window.parent.document.getElementById("sell_price").value = sellPrice;
        window.parent.document.getElementById("buy_price").value = buyPrice;

        window.parent.$.fancybox.close();
    },

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
