<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="04_user_profile_recipe.aspx.cs" Inherits="DishADay._04_user_profile_recipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Profile</title>

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
    <form id="form1" runat="server">
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
                            <a class="nav-link" aria-current="page" href="01_home.aspx">Home</a>
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

        <!-- === RECIPE GALLERY Goh Kai Ling ================================================ -->

        <!-- PROFILE INFO -->

        <div class="profile-info-box">
            <div class="profile-info">
                <div class="profile-info-text">
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                </div>
                <!--Create Recipe Button for Registered User-->
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </div>
        </div>

        <!-- PROFILE OPTION for Registered User-->

        <asp:Literal ID="LiteralProfileOption" runat="server"></asp:Literal>



        <!-- RECIPE GALLERY -->
        <div class="recipe-gallery-wrap">
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <!-- single recipe option -->
                <asp:PlaceHolder ID="PlaceHolderRecipeGallery" runat="server"></asp:PlaceHolder>
            </div>
        </div>


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
