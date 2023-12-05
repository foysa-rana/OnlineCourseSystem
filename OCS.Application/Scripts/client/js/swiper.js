// swiper
let swiper = new Swiper('.swiper-horizontal', {
    // Default parameters
    slidesPerView: 1,
    spaceBetween: 10,
    centerSlide: 'true',
    fade: 'true',
    grabCursor: 'true',
    // Responsive breakpoints
    breakpoints: {
      // when window width is >= 480px
      480: {
        slidesPerView: 2,
        spaceBetween: 20
      },
      // when window width is >= 768px
      768: {
        slidesPerView: 3,
        spaceBetween: 20
      },
      // when window width is >= 992px
      992: {
        slidesPerView: 4,
        spaceBetween: 20
      },
      // when window width is >= 1200px
      1200: {
        slidesPerView: 4,
        spaceBetween: 50
      },
      // when window width is >= 1400px
      1400: {
        slidesPerView: 5,
        spaceBetween: 30
      },
    },
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    },
    loop: true,
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
      dynamicBullets : true,
    },
    autoplay: {
      delay: 5000,
    },
  })
  
  // seminar swiper
  let  seminarSwiper = new Swiper(".swiper-seminar", {
    direction: "vertical",
    spaceBetween: 20,
    centerSlide: 'true',
    fade: 'true',
    grabCursor: 'true',
    loop: true,
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
      dynamicBullets : true,
    },
    autoplay: {
      delay: 5500,
    },
  });