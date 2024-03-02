const customerDataAccess = {
  delete: function (id, element, table) {
    $.ajax({
      url: "/api/customers/" + id,
      method: 'DELETE',
      success: function () {
        table.row(element.parents('tr')).remove().draw();
        //below line deletes the table row in UI only not in DataTable
        //button.parents('tr').remove();
        console.log('DELETED SUCCESSFULLY');
      }
    });
  }
}