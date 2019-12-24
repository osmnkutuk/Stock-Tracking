$(function () {
    $(document).ready(function () { 
        $("#tblUser").DataTable();

});
    $("#tblUser").on("click", ".btnKullanicisil", function () {
        if(confirm("Silmek istediğinize emin misiniz")) {

        var id = $(this).data("id");
        alert(id);
        var btn = $(this);
           $.ajax({
               type: "GET",
                url: "/User/Sil/" + id,
                success: function () {
                   btn.parent().parent().remove();
                }

            });
        }
   });
});
 



