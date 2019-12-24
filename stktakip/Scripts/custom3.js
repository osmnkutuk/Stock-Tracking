$(function() {
    $("#tblProduct").on("click", ".btnUrunsil", function () {
        if (confirm("Silmek istediğinize emin misiniz")) {

            var id = $(this).data("id");
            alert(id);
            var btn = $(this);
            $.ajax({
                type: "GET",
                url: "/Product/Sil/" + id,
                success: function () {
                    btn.parent().parent().remove();
                }

            });
        }
    });
});
