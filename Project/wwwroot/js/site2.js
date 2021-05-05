var startVisibleDirectionOne = 0;
var startVisibleDirectionTwo = 0;
var startVisibleDirectionThree = 0;

function plusSlidesDirectionOne(n) {
    var slides = document.getElementsByClassName("direction-slides-1");
    if (startVisibleDirectionOne + 2 + n < slides.length) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionOne + n; i < startVisibleDirectionOne + n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionOne += n;
    }
}

function minusSlidesDirectionOne(n) {
    var slides = document.getElementsByClassName("direction-slides-1");

    if (startVisibleDirectionOne - n >= 0) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionOne - n; i < startVisibleDirectionOne - n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionOne -= n;
    }
}

function plusSlidesDirectionTwo(n) {
    var slides = document.getElementsByClassName("direction-slides-2");
    if (startVisibleDirectionTwo + 2 + n < slides.length) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionTwo + n; i < startVisibleDirectionTwo + n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionTwo += n;
    }
}

function minusSlidesDirectionTwo(n) {
    var slides = document.getElementsByClassName("direction-slides-2");

    if (startVisibleDirectionTwo - n >= 0) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionTwo - n; i < startVisibleDirectionTwo - n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionTwo -= n;
    }
}

function plusSlidesDirectionThree(n) {
    var slides = document.getElementsByClassName("direction-slides-3");
    if (startVisibleDirectionThree + 2 + n < slides.length) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionThree + n; i < startVisibleDirectionThree + n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionThree += n;
    }
}

function minusSlidesDirectionThree(n) {
    var slides = document.getElementsByClassName("direction-slides-3");

    if (startVisibleDirectionThree - n >= 0) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionThree - n; i < startVisibleDirectionThree - n + 3; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionThree -= n;
    }
}