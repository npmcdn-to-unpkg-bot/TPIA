$(function () {
  $('#_container').imagesLoaded(function () {
    $('#_container').masonry({
      itemSelector: '.content_box',
      columnWidth: 364,
      animate: true
    });
  });
});