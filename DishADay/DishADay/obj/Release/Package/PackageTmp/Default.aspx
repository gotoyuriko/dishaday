<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DishADay._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Home</title>

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
<body>
    <form id="form1" runat="server">
        <div class="home-container">
            <div class="home-search shadow-sm ">
                <div class="welcome-greet">
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                    <h3>What will you cook today?</h3>
                    <br />
                </div>
                <div class="input-group">
                    <asp:TextBox ID="homeSearchTextBox" runat="server" type="search" class="form-control rounded"
                        placeholder="Search by name/recipe" aria-label="Search" aria-describedby="search-addon"></asp:TextBox>
                    <asp:Button ID="homeSearchButton" runat="server" Text="Search" type="button" class="btn" OnClick="homeSearchButton_Click" />

                </div>
            </div>
        </div>

        <div class="home-content p-5">
            <div class="container">
                <div class="circular-features-home row d-flex justify-content-around">
                    <div
                        class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                        <img class="img-fluid" src="ASSETS/explore recipe2.jpg" />
                        <h1 class="home-first-text">Explore Recipe</h1>
                    </div>
                    <div
                        class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                        <img
                            class="img-fluid"
                            src="ASSETS/home_public/istockphoto-1363638825-170667a.jpg" />
                        <h1 class="home-second-text">Share Recipe</h1>
                    </div>
                    <div
                        class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                        <img
                            class="img-fluid"
                            src="ASSETS/home_public/food-fruit-healthy-acorn-wallpaper-preview.jpg" />
                        <h1 class="home-third-text">Cooking Session Feature</h1>
                    </div>
                </div>

                <div class="home-recent-recipes">
                    <h1 class="home-recipes-title text-center">Recent Recipes</h1>
                </div>
            </div>
        </div>

        <div class="home-recipe-content p-5">
            <div class="home-image-button row d-flex justify-content-around">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>

            <div class="home-more-recipes">
                
                <div class="home-more-recipe row d-flex justify-content-center">
                   <a class="text-center col" href="02_recipe_gallery.aspx">
                       More Recipe ->
                   </a>
                </div>
                

                <div class="home-cooking-session">
                    <h1 class="home-session-title">Cooking Session Features</h1>
                    <div class="circular-features-home row d-flex justify-content-around">
                        <div
                            class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                            <img class="img-fluid" src="ASSETS/home_public/guidance.jpg" />
                            <h1 class="home-first-text">Guidance</h1>
                        </div>
                        <div
                            class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                            <img class="img-fluid" src="ASSETS/home_public/timer.png" />
                            <h1 class="home-second-text">Timer</h1>
                        </div>
                        <div
                            class="circular-features-images col-sm d-flex flex-column justify-content-center align-items-center">
                            <img class="img-fluid" src="ASSETS/home_public/notes.jpg" />
                            <h1 class="home-third-text">Notes</h1>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="home-recipe-content p-5">
            <div class="row d-flex justify-content-center align-items-center mx-auto">            
                <div class="col-9">
                    <p class="d-flex justify-content-center sign-up-caption text-center">Join us to Share your Recipe, Learn to Cook, & Have a Good Meal !</p>
                </div>
                <div class="col-3 d-flex justify-content-center">
                    <a class="btn btn-lg sign-in-btn d-flex justify-content-center" href="18_signup.aspx" role="button">Sign Up</a>
                </div>
            </div>
        </div>

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

        <!-- === CUSTOM JS  ======================================-->
        <script src="custom.js"></script>
    </form>
</body>
</html>
