//object JS
let index = {
    login: function () {
        //var email = document.getElementById("email");
        //var password = document.getElementById("password");
        //vetor
        //var elementos = document.getElementsByClassName("vermelho");

        var email = document.querySelector("#email");
        var password = document.querySelector("#password");

        //vetor
        //var elementos = document.querySelectorAll(".vermelho");

        if (email.value.trim() == "" || password.value.trim() == "") {
            document.querySelector("#divError").innerHTML = "Forneça os dados";
            document.querySelector("#divError").style.display = "block";
        }
        else {

            let data = {
                email: email.value,
                password: password.value
            };

            HTTPClient.post("login/Login", data)
                .then(function (retornoServidor) {
                    return retornoServidor.json();
                })
                .then(function (obj) {
                    //sucesso
                    if (obj.operation) {
                        window.location.href = "home"; //controller/action
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
    },

    recoverPassword: function () {

    }
}