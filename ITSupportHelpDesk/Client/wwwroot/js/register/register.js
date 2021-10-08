$("#register").click(function (event) {
    event.preventDefault();
    var obj = new Object();
    obj.Name = $("#inputName").val();
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.BirthDate = $("#inputBirthDate").val();
    obj.Gender = parseInt($("#inputGender").val());
    obj.Phone = $("#inputPhone").val();
    obj.Address = $("#inputAddress").val();
    obj.Department = $("#inputDepartment").val();
    obj.Company = $("#inputCompany").val();
    console.log(obj);
    if (obj.Name == "" && obj.Email == "" && obj.Password == "" && obj.BirthDate == "" &&
        obj.Gender == "" && obj.Phone == "" && obj.Address == "" && obj.Department == "" &&
        obj.Company == ""
    ) {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44329/API/Users/Register',
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(obj)
        }).done((result) => {
            //alert(result);
            Swal.fire({
                title: 'Success!',
                text: 'Register Berhasil. mohon tunggu akan pindah otomatis ke page login',
                type: 'success',
                timer: 5000,
                showConfirmButton: false
            }).then(function () {
                window.location.href = "/login";
            })
        }).fail((error) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Gagal menambahkan data',
                    icon: 'error',
                    confirmButtonText: 'Retry'
                });
                console.log(error);
            });
        }
    })
