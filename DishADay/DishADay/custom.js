"use strict";

// TOOLTIP === YURIKO GOTO
var tooltipTriggerList = [].slice.call(
    document.querySelectorAll('[data-bs-toggle="tooltip"]')
);
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
});

//Preview Function
function preview() {
    frame.src = URL.createObjectURL(event.target.files[0]);
}

//When User submit recipe, the data of ingredients and steps will be sent to c# first
let data_ingredient_array;
let data_step_array;
function takeArray() {
    let data_ingredient_item = document.querySelectorAll('.span-recipe-ingredient');
    let ingredient_array = [];
    data_ingredient_item.forEach(item => { ingredient_array.push(item.textContent + ";"); });
    data_ingredient_array = ingredient_array.toString();
    document.getElementById('data_ingredient_array').value = data_ingredient_array;

    let data_step_item = document.querySelectorAll('.span-recipe-step');
    let step_array = [];
    data_step_item.forEach(item => { step_array.push(item.textContent + ";"); });
    data_step_array = step_array.toString();
    document.getElementById('data_step_array').value = data_step_array;
}

//clear recipe function
function confirm_clear() {
    if (confirm("Do you want to clear your recipe?")) {
        window.location.href = '06_recipe_upload.aspx';
    }
}

//Add a new ingredient
const ingredient_input = document.getElementById("ingredient-input");
const recipe_ingredient_list = document.getElementById("recipe-ingredient-list"
);
let ingredients_data = [];

//Add a new list
function addIngredient() {
    const ingredient = ingredient_input.value.trim();
    //The trim() method removes whitespace from both sides of a string.
    if (ingredient == "") {
        document.getElementById("ingredient-invalid").innerHTML =
            "Add a new ingredient ! :)";
        return;
    } else {
        document.getElementById("ingredient-invalid").innerHTML = "";
    }

    const li = document.createElement("li");
    const span = document.createElement("span");
    const button = document.createElement("button");
    const i = document.createElement("i");

    li.classList.add("recipe-ingredient-list-item");
    span.textContent = ingredient;
    span.classList.add("span-recipe-ingredient");
    button.classList.add("recipe-ingredient-delete");
    i.classList.add("fa-solid");
    i.classList.add("fa-x");

    //Delete Event
    button.addEventListener("click", (e) => {
        //delete element on browser
        recipe_ingredient_list.removeChild(e.target.closest("li"));
        ingredient_input.value = "";
    });

    //add new element on browser
    li.appendChild(span);
    button.appendChild(i);
    li.appendChild(button);
    recipe_ingredient_list.appendChild(li);
    ingredient_input.value = "";
}

//Add a new Steps
const step_input = document.getElementById("step-input");
const recipe_step_list = document.getElementById("recipe-step-list");
let steps_data = [];

//Add a new list
function addStep() {
    const step = step_input.value.trim();
    //The trim() method removes whitespace from both sides of a string.
    if (step == "") {
        document.getElementById("step-invalid").innerHTML =
            "Tell me your new step ! :)";
        return;
    } else {
        document.getElementById("step-invalid").innerHTML = "";
    }

    const li = document.createElement("li");
    const span = document.createElement("span");
    const button = document.createElement("button");
    const i = document.createElement("i");

    li.classList.add("recipe-step-list-item");
    span.textContent = step;
    span.classList.add("span-recipe-step");
    button.classList.add("recipe-step-delete");
    i.classList.add("fa-solid");
    i.classList.add("fa-x");

    //Delete Event
    button.addEventListener("click", (e) => {
        //delete element on browser
        recipe_step_list.removeChild(e.target.closest("li"));
        step_input.value = "";

        let data_step_item = document.querySelectorAll('.span-recipe-step');
        let step_array = [];
        data_step_item.forEach(item => { step_array.push(item.textContent); });
        data_step_array = step_array.toString();
        console.log("document.getElementById(data_step_array).value is ", document.getElementById("data_step_array").value = data_step_array);
        console.log("data_step_array is ", data_step_array);
    });

    //add new element on browser
    li.appendChild(span);
    button.appendChild(i);
    li.appendChild(button);
    recipe_step_list.appendChild(li);
    step_input.value = "";
}

//Recipe Timers Add =================================== Yuriko Goto
//Timer
//Add a new Steps
var timer_input = document.getElementById("timer-input");
var timer_step_input = document.getElementById("timer-step-input");

function addTimer() {
    console.log(typeof timer_input);
    let timer = timer_input.value.trim();
    let timer_step = timer_step_input.value.trim();
    //The trim() method removes whitespace from both sides of a string.
    if (timer == "" || timer_step == "") {
        document.getElementById("timer-invalid").innerHTML =
            "How many minutes and how do you want to cook? :)";
        return;
    } else {
        document.getElementById("timer-invalid").innerHTML = "";
    }

    const li = document.createElement("li");
    const span = document.createElement("span");
    const button = document.createElement("button");
    const i = document.createElement("i");

    li.classList.add("recipe-step-list-item");
    span.textContent = `${timer} min : ${timer_step}`;
    span.classList.add("span-recipe-step");
    button.classList.add("recipe-timer-delete");
    i.classList.add("fa-solid");
    i.classList.add("fa-x");

    //Delete Event
    button.addEventListener("click", (e) => {
        //delete element on browser
        recipe_step_list.removeChild(e.target.closest("li"));
        timer_input.value = "";
        timer_step_input.value = "";
    });

    //add new element on browser
    li.appendChild(span);
    button.appendChild(i);
    li.appendChild(button);
    recipe_step_list.appendChild(li);

    timer_input.value = "";
    timer_step_input.value = "";
}


