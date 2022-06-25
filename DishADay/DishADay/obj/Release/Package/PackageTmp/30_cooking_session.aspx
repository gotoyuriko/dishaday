<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="30_cooking_session.aspx.cs" Inherits="DishADay._30_cooking_session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Cooking Session</title>

    <!--bootstrap css-->
    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"
        rel="stylesheet"
        integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor"
        crossorigin="anonymous" />

    <!-- CUSTOM css -->
    <link rel="stylesheet" href="style.css" />

    <!-- Font Awsome -->
    <script
        src="https://kit.fontawesome.com/8ebce8f613.js"
        crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="progress-bg">
            <div class="timer-bg-white">
                <!--Back to Recipe-->
                <asp:Button class="btn lg-btn timer_go_back" ID="go_back_to_recipe" runat="server" Text="Go Back to Recipe" onclientclick="target='_self'" OnClick="go_back_to_recipe_Click" />
                <div class="timer-wrap">
                    <div class="container">
                        <h1>Cooking Session</h1>
                        <div class="progress-parameter d-flex justify-content-between">
                            <span>0%</span>
                            <span>100%</span>
                        </div>
                        <div class="progress">
                            <div
                                class="progress-bar"
                                id="progress_bar"
                                role="progressbar"
                                aria-valuenow="0"
                                aria-valuemin="0"
                                aria-valuemax="100">
                            </div>
                        </div>
                        <div id="progress_step"></div>
                        <div class="step-description p-5">
                            <p id="step_description" class="fs-6 text-center">
                            </p>
                            <asp:Button
                                ID="go_to_timer_btn"
                                runat="server"
                                Text="Start Kitchen Timer"
                                class="btn go_to_timer_btn mx-auto"
                                OnClientClick="target='_blank'; soundPermission();" 
                                OnClick="go_to_timer_btn_Click"/>
                        </div>
                        <div class="step-button d-flex justify-content-around">
                            <button id="previousBtn" type="button" class="btn">Back</button>
                            <button id="nextBtn" type="button" class="btn">Next</button>
                            <asp:Button
                                ID="finishBtn"
                                runat="server"
                                Text="Finish"
                                type="button"
                                class="btn"
                                OnClientClick="target='_self';"
                                OnClick="finishBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="modal_steps_array" runat="server" />
        <asp:HiddenField ID="timerMinHiddenControl" runat="server" />
        <asp:HiddenField ID="timerStepHiddenControl" runat="server" />
    </form>

    <!-- bootstrap js -->
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2"
        crossorigin="anonymous"></script>

    <!-- jquery -->
    <script src="https://ajax.googleapis.com/ajax/libs/cesiumjs/1.78/Build/Cesium/Cesium.js"></script>

    <!-- bootstrap js -->
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2"
        crossorigin="anonymous"></script>

    <!-- jquery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- === CUSTOM JS  ======================================-->
    <script src="custom.js"></script>

    <script>
        //======== Progress Bar
        //Modal Cooking Session
        //Get Array
        var steps_array = document.getElementById("modal_steps_array").value.replaceAll('"', "").split(";,");

        const previousBtn = document.getElementById("previousBtn");
        const nextBtn = document.getElementById("nextBtn");
        const finishBtn = document.getElementById("finishBtn");
        const progress_step = document.getElementById("progress_step");
        const progress_bar = document.getElementById("progress_bar");
        const step_desc = document.getElementById("step_description");
        const go_to_timer_btn = document.getElementById("go_to_timer_btn");
        go_to_timer_btn.style.display = "none";
        previousBtn.disabled = true;
        finishBtn.disabled = true;


        //Steps Number
        const MAX_STEPS = steps_array.length;
        let currentStep = 1;
        progress_step.innerText = `Step ${currentStep} of ${MAX_STEPS}`;

        //Steps Description
        let step_desc_index = 0;
        step_desc.innerText = steps_array[step_desc_index];

        //Progress Bar Percentage
        let current_percentage = 0;
        let amountOfPercentages = Math.round(100 / MAX_STEPS);
        progress_bar.style.width = 0 + "%";

        let min_num;
        let timer_step;

        //Pass timer minuites to c#
        
        
        
        

        function checkRegularExpressionOfTimer(check_step) {
            //Regular Expression done by JS
            var regex = new RegExp(/[0-9] min \:/i);
            if (regex.test(check_step)) {
                const replacedMin_num = check_step.match(/^[0-9]+/);
                
                if (replacedMin_num[0] !== '') {
                    min_num = replacedMin_num[0]; //object
                    //console.log(min_num);
                    var timerMinHiddenControl = '<%= timerMinHiddenControl.ClientID %>';
                    document.getElementById(timerMinHiddenControl).value = min_num;
                }
                const replacedTimer_step = check_step.replace(/[0-9] min \:/i, '').trim();
                if (replacedTimer_step !== '') {
                    timer_step = replacedTimer_step;
                    //console.log(timer_step);
                    var timerStepHiddenControl = '<%= timerStepHiddenControl.ClientID %>';
                    document.getElementById(timerStepHiddenControl).value = timer_step;
                }
                return true;
            }
            return false;
        }

        
        

        //Go to the next Button
        nextBtn.addEventListener("click", () => {
            //percentages
            current_percentage += amountOfPercentages;

            //Upddate Steps
            step_desc_index++;
            step_desc.innerText = steps_array[step_desc_index];

            //Check if timer button needs to show or not
            if (checkRegularExpressionOfTimer(step_desc.innerText)) {
                go_to_timer_btn.style.display = "block";
            } else {
                go_to_timer_btn.style.display = "none";
            }

            currentStep++;
            //enable previous button
            previousBtn.disabled = false;
            if (currentStep === (MAX_STEPS + 1)) {
                //disable next button
                nextBtn.disabled = true;
                //enable fiish button
                finishBtn.disabled = false;

                progress_step.innerText = `Step ${MAX_STEPS} of ${MAX_STEPS}`;
                progress_bar.style.width = 100 + "%";
                step_desc.innerText = "Hooray! You Finished !";
            } else {
                progress_step.innerText = `Step ${currentStep} of ${MAX_STEPS}`;
                progress_bar.style.width = current_percentage + "%";
            }
        });

        previousBtn.addEventListener("click", () => {
            current_percentage -= amountOfPercentages;

            //percentages
            step_desc_index--;
            step_desc.innerText = steps_array[step_desc_index];

            //Check if timer button needs to show or not
            if (checkRegularExpressionOfTimer(step_desc.innerText)) {
                go_to_timer_btn.style.display = "block";
            } else {
                go_to_timer_btn.style.display = "none";
            }

            currentStep--;
            //enable previous button
            nextBtn.disabled = false;
            finishBtn.disabled = true;
            if (currentStep === 1) {
                //disable button
                previousBtn.disabled = true;
                progress_step.innerText = `Step 1 of ${MAX_STEPS}`;
                progress_bar.style.width = 0 + "%";
            } else {
                progress_step.innerText = `Step ${currentStep} of ${MAX_STEPS}`;
                progress_bar.style.width = current_percentage + "%";
            }
        });


      
        //AUDIO SETTING =====================================
        const audio = new Audio("./ASSETS/Kitchen_sound.mp3");
        let time_alert = 30;
        function onend() {
            audio.play(); // now we're safe to play it
            time_alert = 5;
        }
        function soundPermission() {
            // mark our audio element as approved by the user
            audio.play().then(() => {
                // pause directly
                audio.pause();
                audio.currentTime = 0;
            });
        }


    </script>
</body>
</html>
