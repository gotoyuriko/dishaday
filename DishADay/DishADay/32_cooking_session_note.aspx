<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="32_cooking_session_note.aspx.cs" Inherits="DishADay._32_cooking_session_note" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Cooking Session Take Notes</title>

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
        <div class="takeNote-bg">
            <div class="timer-bg-white">
                <asp:Button class="btn lg-btn timer_go_back" ID="go_back_to_recipe" runat="server" Text="Go Back to Recipe" OnClick="go_back_to_recipe_Click" />
                <div class="takeNote-wrap">
                    <div class="container">
                        <p><b>Leave comment/notes for your cooking :)</b></p>
                        <br />
                        <div class="form-floating">
                            <asp:TextBox 
                                ID="cookingSessionNote" 
                                runat="server"
                                class="form-control"
                                placeholder="Leave your notes here"
                                style="height: 175px" TextMode="MultiLine"></asp:TextBox>
                            <label for="floatingTextarea2">Notes</label>
                        </div>
                        <br />
                        <asp:Button
                            ID="submitCookingSessionBtn"
                            runat="server"
                            Text="Record Your Note ;)"
                            type="submit"
                            class="btn submit-cooking-session-btn"
                            value="Submit" OnClick="submitCookingSessionBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
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
</body>
</html>
