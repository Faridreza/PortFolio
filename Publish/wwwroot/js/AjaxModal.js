function Modal(Info) {
    const NameImage = Info.querySelector('img').alt;
    $.ajax({
        type: "GET",
        url: "Home/ModalInformashion",
        data: { NameImage: NameImage },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data) {
        document.getElementById("title").innerHTML = data['title'];
        document.getElementById("discription").innerHTML = data['discription'];
        document.getElementById("content").innerHTML = data['content'];
        const Vedio = document.getElementById("vedio");
        Vedio.src = "/Project/" + data['vedio'];
    }

    function errorFunc() {
        alert('error');
    }
}