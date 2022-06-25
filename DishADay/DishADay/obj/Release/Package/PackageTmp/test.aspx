<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="DishADay.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!--bootstrap css-->
    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"
        rel="stylesheet"
        integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor"
        crossorigin="anonymous" />

    <!-- ICON css -->
    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <!-- CUSTOM css -->
    <link rel="stylesheet" href="style.css" />

    <title>recipe approval list</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- === Christian Tjandra =========================================================-->
        <!-- ====================Header======================= -->
        <nav class="navbar navbar-expand-lg bg-light fixed-top">
            <div class="container-fluid d-flex justify-content-between">
                <a class="navbar-brand" href="01_home_public.html">
                    <div class="header-logo img-fluid">
                        <img src="./ASSETS/small.png" />
                        <h1>Dish A Day</h1>
                    </div>
                </a>
                <button
                    class="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#dishADayMenuToggler"
                    aria-controls="dishADayMenuToggler"
                    aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="dishADayMenuToggler">
                    <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li class="nav-item mx-3">
                            <a
                                class="nav-link active"
                                aria-current="page"
                                href="01_home_public.html">Home</a>
                        </li>
                        <li class="nav-item mx-3">
                            <a class="nav-link" href="./02_recipe_gallery.html">Recipe Gallery</a>
                        </li>
                        <li class="nav-item mx-3">
                            <a class="nav-link" href="./11_FAQ_contact_form.html">FAQ/Contact</a>
                        </li>
                        <li class="nav-item mx-3">
                            <a href="./20_login.html">
                                <button class="btn loginsignup-button" type="menu">
                                    Log In / Sign Up
                                </button>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- === ADMIN PAGE Goh Kai Ling ================================================ -->
        <div class="admin-page">
            <!-- ADMIN SIDEBAR -->
            <nav class="admin-nav">
                <a href="09_admin_home.html">Home</a>
                <a class="active-btn" href="10_admin_recipe_approval_list.html">Recipe Approval</a>
                <a href="12_admin_enquiries.html">Enquiries</a>

                <button class="dropdown-btn">
                    Report<i class="fa fa-caret-down"></i>
                </button>
                <div class="dropdown-container">
                    <a href="13_admin_report_recipe.html">Recipe</a>
                    <a href="14_admin_report_comment.html">Comment</a>
                </div>

                <button class="dropdown-btn">
                    Information<span class="fa fa-caret-down"></span>
                </button>
                <div class="dropdown-container">
                    <a href="15_admin_info_recipe.html">Recipe</a>
                    <a href="16_admin_info_user.html">User</a>
                </div>
            </nav>

            <!--admin recipe approval content-->
            <div class="admin-content">
                <h2>Recipe Approval</h2>
                <br />
                <table class="table table-color table-striped">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">TITLE</th>
                            <th scope="col">USER NAME</th>
                            <th scope="col">DATE SUBMITTED</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>RA1</td>
                            <td>
                                <a href="11_admin_recipe_approval.html">Kimchi Fried Rice</a>
                            </td>
                            <td>john04</td>
                            <td>17012022</td>
                        </tr>
                        <tr>
                            <td>RA2</td>
                            <td><a href="#">Hawaiian Chicken Chop</a></td>
                            <td>kellyTan</td>
                            <td>24012022</td>
                        </tr>
                        <tr>
                            <td>RA3</td>
                            <td><a href="#">Prawn Curry Noodle</a></td>
                            <td>Cabby33</td>
                            <td>05022022</td>
                        </tr>
                        <tr>
                            <td>RA4</td>
                            <td><a href="#">Asam Laksa</a></td>
                            <td>Mary</td>
                            <td>08022022</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        
    </form>
    <!-- bootstrap js -->
        <script
            src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2"
            crossorigin="anonymous"></script>

        <script src="custom.js"></script>
        <!-- admin sidebar dropdown -->
        <script>
            var dropdown = document.getElementsByClassName("dropdown-btn");
            var i;

            for (i = 0; i < dropdown.length; i++) {
                dropdown[i].addEventListener("click", function () {
                    this.classList.toggle("active");
                    var dropdownContent = this.nextElementSibling;
                    if (dropdownContent.style.display === "block") {
                        dropdownContent.style.display = "none";
                    } else {
                        dropdownContent.style.display = "block";
                    }
                });
            }
        </script>
</body>
</html>
