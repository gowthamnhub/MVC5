$("#customers").on("click", ".js-delete", function () {
  let button = $(this);

  bootbox.confirm("Are you sure you want to delete the customer?", function (result) {
    if (result) {
      $.ajax({
        url: "/api/customers/" + button.attr('data-customer-id'),
        method: 'DELETE',
        success: function () {
          //delete the row from data table and re draw it in UI

          table.row(button.parents('tr')).remove().draw();
          //below line deletes the table row in UI only not in DataTable
          //button.parents('tr').remove();
          console.log('DELETED SUCCESSFULLY');
        }
      });
    }
  });
});