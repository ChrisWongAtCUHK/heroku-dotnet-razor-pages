﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
  /////// Prevent closing from click inside dropdown
  document.querySelectorAll(".dropdown-menu").forEach(function (element) {
    element.addEventListener("click", function (e) {
      e.stopPropagation();
    });
  });

  // make it as accordion for smaller screens
  if (window.innerWidth < 992) {
    // close all inner dropdowns when parent is closed
    document
      .querySelectorAll(".navbar .dropdown")
      .forEach(function (everydropdown) {
        everydropdown.addEventListener("hidden.bs.dropdown", function () {
          // after dropdown is hidden, then find all submenus
          this.querySelectorAll(".submenu").forEach(function (everysubmenu) {
            // hide every submenu as well
            everysubmenu.style.display = "none";
          });
        });
      });

    document.querySelectorAll(".dropdown-menu a").forEach(function (element) {
      element.addEventListener("click", function (e) {
        let nextEl = this.nextElementSibling;
        if (nextEl && nextEl.classList.contains("submenu")) {
          // prevent opening link if link needs to open dropdown
          e.preventDefault();
          console.log(nextEl);
          if (nextEl.style.display == "block") {
            nextEl.style.display = "none";
          } else {
            nextEl.style.display = "block";
          }
        }
      });
    });
  }
  // end if innerWidth
});
// DOMContentLoaded  end
// add row of actor
function addRow(actor) {
  let rowCount = parseInt($("#total").val());
  rowCount++;
  $("#total").val(rowCount);
  const $input = $(`<input type="text" name="[${rowCount - 1}].Name"></input>`);
  $input.val(actor.replace('&#x27;', '\''));
  const $div = $('<div id="inputRow" style="padding-bottom: 5px"></div>');
  $div.append($input);
  $div.append('<span>&nbsp;</span>');
  $div.append('<button id="removeRow" type="button" class="btn btn-danger">Remove</button>');

  $('#newRow').append($div);
  // $('input[name="[ +' (rowCount - 1) '+]Name"').val(actor);
}