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
});