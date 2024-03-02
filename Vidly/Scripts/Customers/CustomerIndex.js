$(document).ready(function () {

  var table = $('#customers').DataTable({
    ajax: {
      url: "/api/customers/",
      dataSrc: "" //if the object itself source, else if any property to be the result like customer:[], then it would be customer
    },
    columns: [
      {
        data: "name",
        render: function (data, type, customer) {
          return "<a href='/customers/edit/" + customer.id + "'>" + data + "</a>";
        }
      },
      {
        data: "membershipType.name"
      },
      {
        data: "membershipType.discountRate"
      },
      {
        data: "id",
        render: function (data) {
          return "<button class='link-danger js-delete border-0 rounded-2' data-customer-id=" + data + ">Delete</button>";
        }
      }
    ]
  });

  $("#customers").on("click", ".js-delete", function () {
    let button = $(this);

    bootbox.confirm("Are you sure you want to delete the customer?", function (result) {
      if (result) {
        //delete the row from data table and re draw it in UI
       customerDataAccess.delete(button.attr('data-customer-id'), button, table);
      }
    });
  });
});