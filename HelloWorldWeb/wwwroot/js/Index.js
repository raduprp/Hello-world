$(document).ready(function () {
    
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();



        
        $("#teamList").append(`<li>${newcomerName}</li>`);



        $("#nameField").val("");
    })
});