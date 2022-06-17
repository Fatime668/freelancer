'use strict'
let bar = document.querySelector(".bar i")
let navbar = document.querySelector(".navbar")
let closes = document.querySelector(".close")
console.log("okay");
bar.onclick = function(){
    navbar.classList.remove("d-none")
    
}
closes.onclick = function(){
    navbar.classList.add("d-none")
}
// $(".bar").click(function(){
//     $(".navbar").css("display","block")
// })