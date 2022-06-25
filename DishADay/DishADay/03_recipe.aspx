<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03_recipe.aspx.cs" Inherits="DishADay._03_recipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Dish A Day - Recipe</title>

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


        <!-- Recipe -->
        <div class="recipe-content-wrap container-fluid">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
        <!-- close recipe-content-wrap -->

        <!-- ingredients -->
        <div class="recipe-content-wrap2">
            <div class="recipe-content-border">
                <h2 class="p-3">Ingredients</h2>
                <ul class="recipe-ingredient-list">
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                </ul>
            </div>
        </div>

        <!-- Steps -->
        <div class="recipe-content-wrap2">
            <h2 class="p-3">Steps</h2>
            <ul class="recipe-step-list">
                <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            </ul>
        </div>

        <!--cooking session -->
        <div class="recipe-content-wrap2 my-5">
            <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
        </div>

        <!-- comment -->
        <div class="recipe-content-wrap2">
            <h2 class="p-3">Comments</h2>

            <div class="input-group mb-3 comment-add">
                <asp:TextBox ID="commentTextBox" type="text" class="form-control"
                    placeholder="Type comment..." aria-label="User Comment"
                    aria-describedby="user-comment" runat="server"></asp:TextBox>

                <asp:Button ID="submitComment" class="btn add-comment-button"
                    type="button" runat="server" Text="Add Comment" OnClick="submitComment_Click" />

                <asp:Button ID="editComment" class="btn add-comment-button"
                    type="button" runat="server" Text="Edit Comment" OnClick="editComment_Click" />

                <asp:SqlDataSource
                    ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT * FROM [comments]"></asp:SqlDataSource>
            </div>

            <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>

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

        <!-- === MODAL START COOKING SESSION YURIKO GOTO =====================================================-->
        <div
            class="modal fade"
            id="startCookingSession"
            tabindex="-1"
            aria-labelledby="startCookingSessionLbl"
            aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content cooking-session-modal">
                    <div class="modal-header">
                        <h5 class="modal-title" id="startCookingSessionLbl">LET'S START COOKING SESSION !
                        </h5>
                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close">
                        </button>
                    </div>
                    <!-- modal-header -->
                    <div class="modal-body text-center">
                        <div class="container">
                            <div
                                class="step-button d-flex justify-content-around start-cooking-session-bg">
                                <div class="start-cooking-session-bg-white">
                                    <asp:Button ID="start_cooking_session_btn" runat="server" Text="START" type="button" class="btn" OnClick="start_cooking_session_btn_Click" />
                                </div>

                            </div>
                        </div>
                        <!-- modal-body -->
                    </div>
                </div>
                <!-- modal-dialog modal-dialog-centered -->
            </div>
        </div>


    </form>

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
