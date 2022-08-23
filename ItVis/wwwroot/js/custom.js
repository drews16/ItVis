function searchPanel() {
    document.querySelector(".search-panel").classList.toggle("show-search-panel");
}

/**************** 
  Home Slider.
 ***************/
let slideIndex = 1;
showSlides(slideIndex);

function plusSlide() {
    showSlides(slideIndex += 1);
}

function minusSlide() {
    showSlides(slideIndex -= 1);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    let slides = document.querySelectorAll(".home-slider-container")
    let dots = document.querySelectorAll("slider-dots-item");

    if (n > slides.length) {
        slideIndex = 1
    }
    if (n < 1) {
        slideIndex = slides.length
    }
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (let i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    //dots[slideIndex - 1].className += "active";
}

let timer = 0;

makeTimer();

function makeTimer() {
    clearInterval(timer)
    timer = setInterval(function () {
        slideIndex++;
        showSlides(slideIndex);
    }, 5000);
}