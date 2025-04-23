var swiper = new Swiper('.mySwiper', {
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    pagination: {
        el: '.swiper-pagination', // المنتی که pagination را در آن قرار داده‌اید
        clickable: true, // قابل کلیک بودن دکمه‌های pagination
    },
    loop: true,
    breakpoints: {

        200: {
            slidesPerView: 2.5, // نمایش ۱ اسلاید
            spaceBetween: 4,
        },
        768: {
            slidesPerView: 3, // نمایش ۲ اسلاید
            spaceBetween: 5,
        },
        1024: {
            slidesPerView: 4, // نمایش ۳ اسلاید
            spaceBetween: 5,
        },
    },
});
//------------------------------------------------------------------------
const swiper1 = new Swiper('.swiper1', {
    effect: 'cards',
    grabCursor: true,
    cardsEffect: {
        slideShadows: true,
    },
});

const swiper2 = new Swiper('.swiper2', {
    effect: 'cards',
    grabCursor: true,
    cardsEffect: {
        slideShadows: true,
    },
});

//------------------------------------------------------------------------
var thumbsSlider = new Swiper('.thumbs-slider', {
    loop: true,
    spaceBetween: 0,
    slidesPerView: 3,
    centeredSlides: true,
    slideToClickedSlide: true,
});
//------------------------------------------------------------------------
var mainSlider = new Swiper('.main-slider', {
    loop: true,
    spaceBetween: 1,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    thumbs: {
        swiper: thumbsSlider, // اینجا thumbsSlider باید بعد از تعریف آن به کار برود
    },
    autoplay: {
        delay: 3000,  // زمان تأخیر بین اسلایدها (بر حسب میلی‌ثانیه)
        disableOnInteraction: false,  // اسلایدر بعد از تعامل کاربر متوقف نشود
    },
});


//------------------------------------------------------------------------
var swiper = new Swiper('.swiper-container', {
    slidesPerView: 1,
    spaceBetween: 10,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    autoplay: {
        delay: 5000,
    },
    loop: true,
    effect: 'fade',
});