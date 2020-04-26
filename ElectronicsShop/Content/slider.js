var images = $(".imgHolder");
var count = images.length;
var i = 0;
var time = 5000;

for (var k = 0; k < count; k++) {
    $(".dotHolder").append("<div id=" + k + " class='dot'></div>");
}

var dots = $(".dot");
$(dots[0]).toggleClass("active");

var timer = setInterval(function () {
    rightArrow();
}, time);


$(".dot").click(function (e) {
    e.preventDefault;

    for (var w = 0; w < dots.length; w++) {
        $(images[w]).removeClass("imgShow");
        $(dots[w]).removeClass("active");
        if (!$(images[w]).hasClass("imgHidden")) {
            $(images[w]).addClass("imgHidden");
        }
    }

    var thisId = $(this).attr("id");
    i = parseInt(thisId);

    $(images[thisId]).addClass("imgShow");
    $(dots[thisId]).addClass("active");
    $(images[thisId]).removeClass("imgHidden");

    clearInterval(timer);
    timer = setInterval(rightArrow, time);
});

$(".left-arrow").on("click", function () {
    clearInterval(timer);
    timer = setInterval(rightArrow, time);
    leftArrow();
});

$(".right-arrow").on("click", function () {
    clearInterval(timer);
    timer = setInterval(rightArrow, time);
    rightArrow();
});

function leftArrow() {
    $(images[i]).toggleClass("imgHidden");
    $(images[i]).toggleClass("imgShow");
    $(dots[i]).toggleClass("active");

    if (i == 0) i = count;

    $(images[i - 1]).toggleClass("imgHidden");
    $(images[i - 1]).toggleClass("imgShow");
    $(dots[i - 1]).toggleClass("active");

    i--;
}

function rightArrow() {
    $(images[i]).toggleClass("imgHidden");
    $(images[i]).toggleClass("imgShow");
    $(dots[i]).toggleClass("active");
    $(images[i + 1]).toggleClass("imgHidden");
    $(images[i + 1]).toggleClass("imgShow");
    $(dots[i + 1]).toggleClass("active");

    i++;

    if (i == images.length) {
        i = 0;
        $(images[0]).toggleClass("imgShow");
        $(images[0]).toggleClass("imgHidden");
        $(dots[0]).toggleClass("active");
    }
}