<%@ page language="C#" autoeventwireup="true" codebehind="13_admin_report_recipe.aspx.cs" inherits="DishADay._13_admin_report_recipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Admin - Reported Recipe</title>

    <!--bootstrap css-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous" />

    <!-- CUSTOM css -->
    <link rel="stylesheet" href="style.css" />

    <!-- font awsome -->
    <script src="https://kit.fontawesome.com/8ebce8f613.js" crossorigin="anonymous"></script>
</head>
<body>
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
                        <a class="nav-link active" aria-current="page" href="01_home.aspx">Home</a>
                    </li>
                    <li class="nav-item mx-3">
                        <a class="nav-link" href="02_recipe_gallery.aspx">Recipe Gallery</a>
                    </li>
                    <li class="nav-item mx-3">
                        <a class="nav-link" href="08_FAQ_enquiry_form.aspx">FAQ/Enquiry</a>
                    </li>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </nav>

    <!-- === ADMIN PAGE Goh Kai Ling ================================================ -->
    <div class="admin-page">
        <!-- admin sidebar -->
        <nav class="admin-nav">
            <a class="active_btn" href="09_admin_home.aspx">Home</a>
            <a href="10_admin_recipe_approval_list.aspx">Recipe Approval</a>
            <a href="12_admin_enquiry.aspx">Enquiries</a>

            <button class="dropdown-btn">
                Report<i class="fa fa-caret-down"></i>
            </button>
            <div class="dropdown-container">
                <a href="13_admin_report_recipe.aspx">Recipe</a>
                <a href="14_admin_report_comment.aspx">Comment</a>
            </div>

            <button class="dropdown-btn">
                Information<span class="fa fa-caret-down"></span>
            </button>
            <div class="dropdown-container">
                <a href="15_admin_info_recipe.aspx">Recipe</a>
                <a href="16_admin_info_user.aspx">User</a>
            </div>
        </nav>

        <!-- ADMIN REPORTED RECIPE CONTENT-->
        <form id="admin_report_recipe_form" runat="server" class="admin-content">
            <div>
                <h2>Reported Recipes</h2>
                <br />
                <table class="table table-color table-striped">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">RECIPE TITLE</th>               
                            <th scope="col">AUTHOR</th>
                            <th scope="col">UPLOADED DATE</th>
                            <th scope="col"> </th>
                            
                        </tr>
                    </thead>
                    <tbody>
                         <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>         
                    </tbody>
                </table>
            </div>
        </form>
    </div>
    


    <!-- bootstrap js -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

    <!-- jquery -->
    <script src="https://ajax.googleapis.com/ajax/libs/cesiumjs/1.78/Build/Cesium/Cesium.js"></script>

    <!-- custom js -->
    <script src="./custom.js"></script>

    <!-- admin sidebar dropdown js -->
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
