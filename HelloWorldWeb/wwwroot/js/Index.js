// This JS file now uses jQuery. Pls see here: https://jquery.com/

$(document).ready(function () {
    // see https://api.jquery.com/click/
    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    setDelete();
    setEdit();

    connection.on("NewTeamMemberAdded", createNewLine);
    connection.on("TeamMemberDeleted", deleteMember);

    connection.start().then(function () {
        alert("signalr connected");
    }).catch(function (err) {
        return console.error(err.toString());
    });

    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });

    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "GET",
            url: "/Home/GetCount",

            success: (resultGet) => {
                $.ajax({
                    method: "POST",
                    url: "/Home/AddTeamMember",
                    data: {
                        "name": newcomerName
                    },
                    success: (resultPost) => {
                        $("#nameField").val("");
                        $('#createButton').prop('disabled', true);
                    }
                })
            }
        });
    })

    $("#editClassmate").on("click", "#submit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = $('#editClassmate').attr("data-member-id");
        var name = $('#classmateName').val();
        $.ajax({
            url: "/Home/EditTeamMemberName",
            method: "POST",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                targetMemberTag.find("memberName").text(name);
                location.reload();
            }
        })
    })


    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
});

function setDelete() {
    $("#teamList").on("click", ".delete", function () {
    
        var id = $(this).parent().attr("data-member-id");
        $.ajax({
            method: "DELETE",
            url: "/Home/DeleteTeamMember",
            data: {
                "id": id
            },
            success: (result) => {
                console.log("delete:" + id);
            }
        })
    }
    );
}

function setEdit() {
    $("#teamList").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })
}

var createNewLine = (name, id) => {
    $("#teamList").append(`<li class="member" data-member-id="${id}">
                        <span class="memberName">${name}</span>
                        <span class="delete fa fa-remove" id="deleteMember"></span>
                        <span class="pencil fa fa-pencil"></span>
                             </li>`);
    setDelete();
    setEdit();
}

var deleteMember = (id) => {
    $(`li[data-member-id=${id}]`).remove();
}