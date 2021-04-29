var startVisibleDirectionOne = 0;

function plusSlides(n) {
    var slides = document.getElementsByClassName("slide");
    if (startVisibleDirectionOne + 3 + n < slides.length) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionOne + n; i < startVisibleDirectionOne + n + 4; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionOne += n;
    }
}

function minusSlides(n) {
    var slides = document.getElementsByClassName("slide");

    if (startVisibleDirectionOne - n >= 0) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisibleDirectionOne - n; i < startVisibleDirectionOne - n + 4; ++i) {
            slides[i].style.display = "block"
        }
        startVisibleDirectionOne -= n;
    }
}