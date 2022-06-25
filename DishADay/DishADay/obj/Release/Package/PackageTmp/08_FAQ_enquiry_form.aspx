<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="08_FAQ_enquiry_form.aspx.cs" Inherits="DishADay._08_FAQ_enquiry_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - FAQ/Enquiry</title>

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
        <!-- === HEADER Christian Tjandra =========================================================-->
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
                            <a class="nav-link active" href="08_FAQ_enquiry_form.aspx">FAQ/Enquiry</a>
                        </li>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- === FAQ & ENQUIRY Goh Kai Ling ================================================ -->
        <!-- FAQ -->
        <div class="faq">
            <div class="faq-title">
                <h2>FAQ</h2>
            </div>

            <!-- single question -->
            <a
                class="btn faq-btn"
                data-bs-toggle="collapse"
                href="#question1"
                role="button"
                aria-expanded="false"
                aria-controls="collapseExample">What is “DISHADAY” ?
        <i class="fa-solid fa-angle-down"></i>
            </a>
            <div class="collapse" id="question1">
                <div class="card card-body">
                    We “DISHADAY” provide platform that you can explore recipes and share your recipes.
                </div>
            </div>
            <!------>

            <a
                class="btn faq-btn"
                data-bs-toggle="collapse"
                href="#question2"
                role="button"
                aria-expanded="false"
                aria-controls="collapseExample">What is “Cooking Session ?
        <i class="fa-solid fa-angle-down"></i>
            </a>
            <div class="collapse" id="question2">
                <div class="card card-body">
                    “Cooking Session” guides you to cook step by step.
                </div>
            </div>

            <a
                class="btn faq-btn"
                data-bs-toggle="collapse"
                href="#question3"
                role="button"
                aria-expanded="false"
                aria-controls="collapseExample">I cannot login to my account.
        <i class="fa-solid fa-angle-down"></i>
            </a>
            <div class="collapse" id="question3">
                <div class="card card-body">
                    Please contact our admin to get your account back.
                </div>
            </div>

            <a
                class="btn faq-btn"
                data-bs-toggle="collapse"
                href="#question4"
                role="button"
                aria-expanded="false"
                aria-controls="collapseExample">Why my recipe is rejected?
        <i class="fa-solid fa-angle-down"></i>
            </a>
            <div class="collapse" id="question4">
                <div class="card card-body">
                    Your recipe may contain inappropriate content. For further information, please contact our admin.
                </div>
            </div>

            <!-- ENQUIRY -->
            <div class="faq-title">
                <h2>Enquiry Form</h2>
            </div>
            <div id="enquiry-form">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="enquiryName" runat="server" type="text" class="form-control"
                        placeholder="Username" required="required"></asp:TextBox>
                    <label for="enquiryName">Name</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="enquiryEmail" runat="server" class="form-control"
                        placeholder="Email" required="required" TextMode="Email"></asp:TextBox>
                    <label for="enquiryEmail">Email</label>
                </div>

                <div class="form-floating">
                    <asp:TextBox ID="enquiry" runat="server" TextMode="MultiLine" class="form-control"
                        placeholder="Leave a comment here" Style="height: 100px"></asp:TextBox>
                    <label for="enquiry">Enquiries</label>
                </div>

                <!-- Submit button -->
                <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                    <asp:Button ID="enquirySubmit" class="btn enquiry-send-btn" runat="server"
                        Text="SEND" type="submit" OnClick="enquirySubmit_Click" />
                    <asp:SqlDataSource
                        ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT * FROM [enquiry]"></asp:SqlDataSource>
                </div>
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
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

        <!-- jquery -->
        <script src="https://ajax.googleapis.com/ajax/libs/cesiumjs/1.78/Build/Cesium/Cesium.js"></script>

        <!-- custom js -->
        <script src="./custom.js"></script>
    </form>
</body>
</html>
