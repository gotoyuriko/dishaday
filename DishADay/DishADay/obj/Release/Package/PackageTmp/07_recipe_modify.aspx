<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="07_recipe_modify.aspx.cs" Inherits="DishADay._07_recipe_modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<a href="07_recipe_modify.aspx">07_recipe_modify.aspx</a>
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Modify</title>

    <!--bootstrap css-->
    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"
        rel="stylesheet"
        integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor"
        crossorigin="anonymous" />

    <!-- CUSTOM css -->
    <link rel="stylesheet" href="style.css" />

    <!-- font awsome -->
    <script
        src="https://kit.fontawesome.com/8ebce8f613.js"
        crossorigin="anonymous"></script>
</head>
<body class="vanilla-bg">
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
        <asp:HiddenField ID="HiddenField_id" runat="server" />

        <!-- === RECIPE CONTENT Yuriko Goto ================================================ -->
        <div class="recipe-content-wrap container-fluid">
            <!-- === Recipe Upload =================================================== -->
            <div
                class="recipe-top-of-image p-3 d-flex justify-content-between align-items-center">
                <!-- === go-back-button ========= -->
                 <asp:Literal ID="back_btn_literal" runat="server"></asp:Literal>
                <!-- start-cooking-session-button -->
            </div>

            <!-- === RECIPE UPLOAD CONTENT  ======================================-->
            <!-- recipe-content-item -->
            <div class="recipe-hero-wrap">
                <div class="image-upload-wrap position-realative">
                    
                    <asp:PlaceHolder ID="PlaceHolderImage" runat="server"></asp:PlaceHolder>

                </div>
                <!-- image-upload-wrap -->

                <!-- recipe content -->
                <div class="recipe-upload-content">
                    <div class="form-floating my-5">
                        <asp:TextBox
                            ID="recipeTitle"
                            runat="server"
                            type="text"
                            class="form-control"
                            placeholder="Recipe Title"
                            required="required"></asp:TextBox>
                        <label for="recipeTitle">Recipe Title</label>

                    </div>
                    <!-- form-floating  -->
                    <div class="form-floating my-5">
                        <asp:TextBox
                            ID="recipeDescription"
                            runat="server"
                            class="form-control"
                            placeholder="Caption about your dishes."
                            Style="height: 100px"
                            required="required" TextMode="MultiLine"></asp:TextBox>
                        <label for="recipeDescription">Caption about your dishes. </label>
                    </div>
                    <!-- form-floating -->
                    <div class="input-group my-5 d-flex flex-row align-items-center">
                        <div class="col-sm-2">
                            <label for="durationTime" class="pe-5">
                                <strong>Cook Time</strong></label>
                        </div>
                        <div class="col-sm">
                            <asp:TextBox
                                ID="durationTime"
                                runat="server"
                                type="number"
                                class="form-control"
                                placeholder="30"
                                aria-label="Time Duration"
                                min="0"
                                max="360"
                                required="required"
                                TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-sm">
                            <span class="ps-2">minutes</span>
                        </div>
                        <div class="col-sm-8"></div>
                    </div>
                    <!-- form-floating -->
                </div>
                <!-- recipe-upload-content -->
            </div>
            <!-- recipe-hero-wrap -->
        </div>
        <!-- recipe-content-wrap -->

        <!-- === INGREDIENTS  ======================================-->
        <div class="recipe-content-wrap2">
            <div class="recipe-content-border">
                <h2 class="p-3">Ingredients</h2>
                <div class="recipe-ingredient-box-form mb-3">
                    <div class="input-group is-invalid">
                        <input
                            type="text"
                            name="ingredient-input"
                            id="ingredient-input"
                            class="form-control"
                            placeholder="E.g. 250g flour"
                            aria-label="E.g. 250g flour"
                            aria-describedby="ingredient-add-btn" />
                        <button
                            class="btn recipe-ingredient-add-btn"
                            type="button"
                            id="ingredient-add-btn"
                            onclick="addIngredient()">
                            Add
                        </button>
                    </div>
                    <div class="invalid-feedback ps-3" id="ingredient-invalid"></div>
                </div>

                <div class="recipe-ingredient-list-box">
                    <ul id="recipe-ingredient-list">
                        <asp:PlaceHolder ID="PlaceHolderIngredient" runat="server"></asp:PlaceHolder>
                    </ul>
                </div>
                <!-- recipe-ingredient-list-box -->
            </div>
            <!-- recipe-content-border -->
        </div>
        <!-- recipe-content-wrap2 -->

        <!-- === STEPS  ======================================-->
        <div class="recipe-content-wrap2">
            <div class="recipe-content-border">
                <h2 class="p-3">Steps</h2>
                <div class="recipe-step-box-form mb-3">
                    <div class="input-group is-invalid">
                        <input
                            type="text"
                            name="step-input"
                            id="step-input"
                            class="form-control"
                            placeholder="E.g. Heat a pan and oil lightly."
                            aria-label="E.g. Heat a pan and oil lightly."
                            aria-describedby="step-add-btn" />
                        <button
                            class="btn recipe-step-add-btn"
                            type="button"
                            id="step-add-btn"
                            onclick="addStep()">
                            Add
                        </button>
                    </div>
                    <div class="invalid-feedback ps-3" id="step-invalid"></div>
                </div>

                <!-- timer -->
                <div class="recipe-timer-box-form mb-3">
                    <div class="input-group is-invalid">
                        <input
                            type="number"
                            name="timer-input"
                            id="timer-input"
                            class="form-control"
                            placeholder="3"
                            aria-label="3"
                            aria-describedby="timer-add-btn"
                            min="0" />
                        <span class="input-group-text">min</span>
                        <input
                            type="text"
                            name="timer-step-input"
                            id="timer-step-input"
                            class="form-control"
                            placeholder="E.g. Boild the water"
                            aria-label="E.g. Boild the water"
                            aria-describedby="timer-add-btn" />
                        <button
                            class="btn recipe-timer-add-btn"
                            type="button"
                            id="timer-add-btn"
                            onclick="addTimer()">
                            Add
                        </button>
                    </div>
                    <div class="invalid-feedback ps-3" id="timer-invalid"></div>
                </div>

                <div class="recipe-step-list-box">
                    <ul id="recipe-step-list">
                        <asp:PlaceHolder ID="PlaceHolderStep" runat="server"></asp:PlaceHolder>
                    </ul>
                </div>
            </div>
            <!-- recipe-content-border -->
        </div>
        <!-- recipe-content-wrap2 -->

        <div class="recipe-content-wrap2">
            <div class="row d-flex justify-content-around">
                <div class="col d-flex justify-content-center">
                    <asp:Button
                        ID="submit"
                        runat="server"
                        Text="Update"
                        class="btn uploadRecipeSubmitBtn"
                        type="submit"
                        OnClick="modify_Click"
                        OnClientClick="takeArray()" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [recipe]"></asp:SqlDataSource>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="data_ingredient_array" runat="server" />
        <asp:HiddenField ID="data_step_array" runat="server" />

    </form>

    <!-- ====================Header======================= -->
    <nav class="navbar navbar-expand-lg bg-light fixed-top">
        <div class="container-fluid d-flex justify-content-between">
            <a class="navbar-brand" href="01_home.aspx">
                <div class="header-logo img-fluid">
                    <img src="./ASSETS/small.png" />
                    <h1>Dish A Day</h1>
                </div>
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#dishADayMenuToggler" aria-controls="dishADayMenuToggler" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="dishADayMenuToggler">
                <ul class="navbar-nav ms-auto mb-2  mb-lg-0">
                    <li class="nav-item mx-3">
                        <a class="nav-link active" aria-current="page" href="01_home.aspx">Home</a>
                    </li>
                    <li class="nav-item mx-3">
                        <a class="nav-link" href="02_recipe_gallery.aspx">Recipe Gallery</a>
                    </li>
                    <li class="nav-item mx-3">
                        <a class="nav-link" href="08_FAQ_enquiry_form.aspx">FAQ/Enquiry</a>
                    </li>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Footer -->
    <footer>
        <div class="row d-flex justify-content-around align-items-center">
            <div class="col-sm d-flex justify-content-center p-5">
                <a href="02_recipe_gallery.aspx">Recipe Gallery</a>
            </div>
            <div class="col-sm d-flex justify-content-center p-5">
                <a href="08_FAQ_enquiry_form.aspx">FAQ/Enquiry</a>
            </div>
            <div class="col-sm d-flex justify-content-center p-5">
                <a href="01_home.aspx">
                    <h1 class="text-center">DISH A DAY</h1>
                </a>
            </div>
            <div class="col-sm d-flex justify-content-center p-5">
                <a href="17_login.aspx">Log in</a>
            </div>
            <div class="col-sm d-flex justify-content-center p-5">
                <a href="18_signup.aspx">Sign Up</a>
            </div>
        </div>
        <!-- row -->
        <!-- <hr class="footer-hr" /> -->
        <div class="footer-cr p-3">
            <p>APU-MMT @2022 All Right Reserved</p>
        </div>
    </footer>

    <!-- bootstrap js -->
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2"
        crossorigin="anonymous"></script>

    <!-- jquery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- jsDelivr :: Sortable :: Latest (https://www.jsdelivr.com/package/npm/sortablejs) -->
    <script src="https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js"></script>

    <!-- === CUSTOM JS  ======================================-->
    <script src="custom.js"></script>

    <script type="text/javascript"> 
        // Create a "close" button and append it to each ingredient list item
        var myIngredientList = document.getElementsByClassName("recipe-ingredient-list-item");
        for (var item = 0; item < myIngredientList.length; item++) {
            const button2 = document.createElement("button");
            const i2 = document.createElement("i");
            const span2 = document.createElement("span");
            span2.classList.add("span-recipe-ingredient");
            button2.classList.add("recipe-ingredient-delete");
            i2.classList.add("fa-solid");
            i2.classList.add("fa-x");
            button2.appendChild(i2);
            myIngredientList[item].appendChild(button2);
        }

        const recipe_ingredient_list2 = document.getElementById("recipe-ingredient-list"
        );
        // Click on a close button to hide the current list item
        var ingredient_delete = document.getElementsByClassName("recipe-ingredient-delete");
        for (item2 = 0; item2 < ingredient_delete.length; item2++) {
            ingredient_delete[item2].onclick = function (event) {
                event.preventDefault();
                recipe_ingredient_list2.removeChild(event.target.closest("li"));
            }
        }

        // Create a "close" button and append it to each step list item
        var myIngredientList2 = document.getElementsByClassName("recipe-step-list-item");
        for (var item3 = 0; item3 < myIngredientList2.length; item3++) {
            const button3 = document.createElement("button");
            const i3 = document.createElement("i");
            const span3 = document.createElement("span");
            span3.classList.add("span-recipe-step");
            button3.classList.add("recipe-step-delete");
            i3.classList.add("fa-solid");
            i3.classList.add("fa-x");
            button3.appendChild(i3);
            myIngredientList2[item3].appendChild(button3);
        }

        const recipe_step_list2 = document.getElementById("recipe-step-list");
        // Click on a close button to hide the current list item
        var ingredient_delete2 = document.getElementsByClassName("recipe-step-delete");
        for (item4 = 0; item4 < ingredient_delete2.length; item4++) {
            ingredient_delete2[item4].onclick = function (event) {
                event.preventDefault();
                recipe_step_list2.removeChild(event.target.closest("li"));
            }
        }

        //Recipe Ingredients add =================================== Yuriko Goto
        //sortable list from Sortable.js
        var element = document.getElementById("recipe-ingredient-list");
        var sortable = Sortable.create(element, {
            animation: 150,
        });

        //Recipe Steps add =================================== Yuriko Goto
        //sortable list from Sortable.js
        var element2 = document.getElementById("recipe-step-list");
        var sortable2 = Sortable.create(element2, {
            animation: 150,
        });
    </script>

</body>
</html>
