<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="31_cooking_session_timer.aspx.cs" Inherits="DishADay._31_cooking_session_timer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Kitchen Timer</title>

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
        <div class="timer-bg">
            <div class="timer-bg-white">
                <a class="btn lg-btn timer_go_back" onclick="closeTab()">Close Kitchen Timer</a>
                <div class="timer-wrap">
                    <p id="countdown"></p>
                    <p id="recipe_step_desc"></p>
                    <br />
                    <div class="d-flex justify-content-center">
                        <button
                            id="stopAudio"
                            class="btn stop-audio-btn"
                            onclick="onStopAudio()">
                            Stop Kitchen Timer
                        </button>
                    </div>
                    <p id="timer_message"></p>
                    <a id="lets_timer_go_back" onclick="closeTab()"></a>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="modal_steps_array" runat="server" />
        <asp:HiddenField ID="timer_min_id" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="timer_step_id" runat="server" />

        <script>

            
            //button
            let stopAudio = document.getElementById("stopAudio");
            stopAudio.style.display = "none";
            let audio_status = true;
            const audio = new Audio("./assets/Kitchen_sound.mp3");
            let time_alert = 30;

            function onPlayAudio() {
                audio.play(); // now we're safe to play it
                time_alert = 30;
            }
            function onStopAudio() {
                audio.pause();
                audio.currentTime = 0;
                audio_status = false;
                closeTab()
            }
            const startingMinutes = parseInt(document.getElementById("timer_min_id").value);
            let time = startingMinutes * 60;

            const countdownEl = document.getElementById("countdown");
            const recipe_step_desc = document.getElementById("recipe_step_desc");
            setInterval(updateCountdown, 1000);

            function updateCountdown() {
                recipe_step_desc.innerText = document.getElementById("timer_step_id").value;
                const minutes = Math.floor(time / 60);
                let seconds = time % 60;

                //if seconds are less than 10 then we combine 0 with number otherwise we just display seconds
                let displayMinutes = minutes < 10 ? "0" + minutes : minutes;
                let displaySeconds = seconds < 10 ? "0" + seconds : seconds;

                //documentEL
                countdownEl.innerHTML = `${displayMinutes}:${displaySeconds}`;
                time--;

                if (time < 0) {
                    if (audio_status) {
                        onPlayAudio();
                    }
                    countdownEl.innerHTML = "00:00";
                    document.getElementById("timer_message").innerHTML =
                        "Yayy! Finish! Let's move on to the next step!";
                    clearInterval(updateCountdown);
                    var lets_timer_go_back =
                        document.getElementById("lets_timer_go_back");
                    lets_timer_go_back.innerHTML = "Let's Go Back to continue cooking!";
                    stopAudio.style.display = "block";
                }
            }

            function closeTab() {
                window.close();
            }
        </script>
    </form>
</body>
</html>
