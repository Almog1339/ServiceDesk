function btnSend() {
    function btnSend() {
        var password = document.getElementById("Password").value;
        var user = document.getElementById("User").value;

        var users = {
            UserName: user,
            Password: password
        };
        console.log(JSON.stringify(users));

        var url = "https://localhost:44317/api/login";
        var req = {
            type: "POST",
            url: url,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(users)
        };
        $.ajax(req).then(function (data) {
            console.log(data);
        });
    }
}