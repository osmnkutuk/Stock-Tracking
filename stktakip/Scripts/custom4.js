$(function () {
    $("#tblProductStock").on("click", ".btnUrunstoksil", function () {
        if (confirm("Silmek istediğinize emin misiniz")) {

            var id = $(this).data("id");
            alert(id);
            var btn = $(this);
            $.ajax({
                type: "GET",
                url: "/ProductStock/Sil/" + id,
                success: function () {
                    btn.parent().parent().remove();
                }

            });
        }
    });
});