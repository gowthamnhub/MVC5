const movieDataAccess = {
  delete: function (id, element, table) {
    $.ajax({
      url: "/api/movies/" + id,
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