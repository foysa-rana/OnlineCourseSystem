// navbar 
let navigation = () => {
    let navbarToggler = document.querySelector('.navbar-toggler');
    let collapse = document.querySelector('.collapse')
    
    navbarToggler.addEventListener('click', () => {
        collapse.classList.toggle('show');
    })
}
// navigation();

// searchbar 
let searchBar = () => {
    let searchBtnDesktop = document.querySelector('.search-btn-desktop');
    let searchClose = document.querySelector('.search-close');
    let searchDesktop = document.querySelector('.search-desktop');

    searchBtnDesktop.addEventListener('click', () => {
        searchBtnDesktop.classList.add('hide');
        searchClose.classList.remove('hide');
        searchDesktop.classList.add('search-show');
    })

    searchClose.addEventListener('click', () => {
        searchBtnDesktop.classList.remove('hide');
        searchClose.classList.add('hide');
        searchDesktop.classList.remove('search-show');
    })
}
searchBar();

// sign in sign up
let sign = () => {
    let signInBtn = document.querySelector('.sign-in-btn');
    let signUpBtn = document.querySelector('.sign-up-btn');
    let sigIn = document.querySelector('.signin');
    let sigUp = document.querySelector('.signup');

    signInBtn.addEventListener('click', () => {
      signInBtn.classList.add('active');
      signUpBtn.classList.remove('active');
      sigIn.classList.add('show');
      sigUp.classList.remove('show');
    })
    signUpBtn.addEventListener('click', () => {
      signInBtn.classList.remove('active');
      signUpBtn.classList.add('active');
      sigIn.classList.remove('show');
      sigUp.classList.add('show');
    })
}
sign();

// sidebar
let sidebar = () => {
  let bar = document.querySelector('.sidebar');
  let showIcon = document.querySelector('.show-icon');
  let hideIcon = document.querySelector('.hide-icon');

  showIcon.addEventListener('click', () => {
    showIcon.style.display = 'none';
    bar.classList.add('shrink');
  })
  hideIcon.addEventListener('click', () => {
    showIcon.style.display = 'block';
    bar.classList.remove('shrink');
  })
}
sidebar();