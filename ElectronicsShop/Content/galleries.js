//Edit gallery name
var galleryName = $(".galleryName");
var galleryId  = $("#galleryId").val();

$(galleryName).change(function () {
    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        url: "/Galleries/Edit/"+galleryId,
        type: 'POST',
        data: { GalleryId: galleryId, Name: galleryName.val(), __RequestVerificationToken: token }
    });
});


//Edit order of image in gallery
var images = $(".imageToSend");
var imgs = $(".imgId");

$(images).change(function () {
    var token = $("[name='__RequestVerificationToken']").val();

    var imageIndex = images.index(this);
    var imageId = imgs[imageIndex].value;
    var value = images[imageIndex].value;

    $.ajax({
        url: "/Galleries/SetPositionOfImageInGallery/",
        type: 'POST',
        data: { GalleryId: galleryId, order: value, imageId: imageId, __RequestVerificationToken: token },
        success: function() {
            window.location.reload();
        }
    });
});


var buttonsAdd = $(".btnAdd");
var buttonsSubstract = $(".btnSubstract");

buttonsAdd.on("click", function() {
    var btnIndex = buttonsAdd.index(this);
    var value = images[btnIndex].value;

    SetPositionOfImageInGallery(parseInt(value) + 1, btnIndex);
});

buttonsSubstract.on("click", function () {
    var btnIndex = buttonsSubstract.index(this);
    var value = images[btnIndex].value;

    SetPositionOfImageInGallery(parseInt(value) - 1, btnIndex);
});

function SetPositionOfImageInGallery(value, index) {
    var token = $("[name='__RequestVerificationToken']").val();
    var imageId = imgs[index].value;

    $.ajax({
        url: "/Galleries/SetPositionOfImageInGallery/",
        type: 'POST',
        data: { GalleryId: galleryId, order: value, imageId: imageId, __RequestVerificationToken: token },
        success: function () {
            window.location.reload();
        }
    });
}


//Delete image from gallery
var buttonsDelete = $(".btnDelete");

buttonsDelete.on("click", function() {
    var btnIndex = buttonsDelete.index(this);
    var imageId = imgs[btnIndex].value;

    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        url: "/Galleries/DeleteImageFromGallery/",
        type: 'POST',
        data: { GalleryId: galleryId, imageId: imageId, __RequestVerificationToken: token },
        success: function () {
            window.location.reload();
        }
    });
});