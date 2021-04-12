var startVisible = 0;

function plusSlides(n) {
    var slides = document.getElementsByClassName("slide");
    if (startVisible + 3 + n < slides.length) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisible + n; i < startVisible + n + 4; ++i) {
            slides[i].style.display = "block"
        }
        startVisible += n;
    }
}

function minusSlides(n) {
    var slides = document.getElementsByClassName("slide");

    if (startVisible - n >= 0) {
        for (var i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        for (var i = startVisible - n; i < startVisible - n + 4; ++i) {
            slides[i].style.display = "block"
        }
        startVisible -= n;
    }
}