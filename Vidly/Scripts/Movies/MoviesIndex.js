$(document).ready(function () {
  var movieTable = $('#movies').DataTable({
    ajax: {
      url: "/api/movies",
      dataSrc: ""
    },
    columns: [
      {
        data: "name",
        render: function (data, type, movie) {
          return "<a href=/movies/edit/" + movie.id + ">" + data + "</a>";
        },
      },
      {
        data: "genreId"
      },
      {
        data: "id",
        render: function (data) {
          return "<button class='btn-link js-delete link-danger border-0 rounded-2' data-movie-id=" + data +
            ">Delete</button>"
        }
      }

    ]
  });

  $("#movies").on("click", ".js-delete", function () {
    let button = $(this);

    bootbox.confirm("Are you sure you want to delete the movie?", function (result) {
      if (result) {
        //delete the row from data table and re draw it in UI
        movieDataAccess.delete(button.attr('data-movie-id'), button, movieTable);
      }
    });
  });
});