////window.addEventListener("scroll", function () {
////    var header = document.querySelector("nav");
////    header.classList.toggle("sticky", window.scrollY > 570);
////    console.log("Hello world!");
////})



//function applyStickyNavigation() {
//    lnStickyNavigation = $('.icon-down-arrow-a').offset().top;

//    $(window).on('scroll', function () {
//        stickyNavigation();
//    });
//    console.log("Hello world!");
//      console.log("Hello world!");
//    stickyNavigation();
//}

//function stickyNavigation() {
//    if ($(window).scrollTop() > lnStickyNavigation) {
//        $('body').addClass('sticky');
//          console.log("Hello world!");
//    }
//    else {
//        $('body').removeClass('sticky');    
//    }
//}

$(window).scroll(function () {
    lnStickyNavigation = $('.icon-down-arrow-a').offset().top;
    if ($(this).scrollTop() >= lnStickyNavigation) {
        $('.navigation').addClass('sticky');
    } else {
        $('.navigation').removeClass('sticky');
    }
});


//jQuery(document).ready(function ($) {
//    $(window).on('scroll', function () {
//        if ($(window).scrollTop().top <= $('.icon-down-arrow-a').scrollTop()) {
//            $('.menu').addClass('addclass');
//        }
//        else {
//            $('.navigation').toggleClass('sticky');
//            //or use $('.menu').removeClass('addclass');
//        }
//    });
//});



// $(document).ready(function () {
//     $(document).on("scroll", onScroll);

//     //smoothscroll
//     $('a[href^="#"]').on('click', function (e) {
//         e.preventDefault();
//         $(document).off("scroll");

//         $('.menuItem').each(function () {
//             $(this).removeClass('active');
//         })
//         $(this).addClass('active');

//         var target = this.hash,
//             nav = target;
//         $target = $(target);
//         $('html, body').stop().animate({
//             'scrollTop': $target.offset().top+2
//         }, 500, 'swing', function () {
//             window.location.hash = target;
//             $(document).on("scroll", onScroll);
//         });
//     });
// });

// function onScroll(event){
//     var scrollPos = $(document).scrollTop();
//     $('.menuItem').each(function () {
//         var currLink = $(this);
//         var refElement = $(currLink.attr("href"));
//         if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
//             $('.menuItem').removeClass("active");
//             currLink.addClass("active");
//         }
//         else{
//             currLink.removeClass("active");
//         }
//     });
// }

/* Code for changing active 
            link on clicking */
var btns =
    $(".menuItem");

for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click",
        function () {
            var current = document
                .getElementsByClassName("active");

            current[0].className = current[0]
                .className.replace("active", "");

            this.className += "active";
        });
}

/* Code for changing active 
link on Scrolling */
$(window).scroll(function () {
    var distance = $(window).scrollTop();
    $('.navItem').each(function (i) {

        if ($(this).position().top
            <= distance + 250) {

            $('nav a.active')
                .removeClass('active');

            $('nav a').eq(i)
                .addClass('active');
        }
    });
}).scroll();