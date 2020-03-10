//import things
import Header from "./components/Header";



pageBuild();

function pageBuild(){
    header();

}

function header() {
    const header = document.querySelector("#header");
    header.innerHTML = Header();
}