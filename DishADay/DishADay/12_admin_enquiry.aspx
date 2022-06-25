<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12_admin_enquiry.aspx.cs" Inherits="DishADay._12_admin_enquiry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>Admin - Enquiry</title>

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


        <!--ADMIN ENQUIRIES CONTENT-->
        <form id="admin_enquiry_form" runat="server" class="admin-content">
            <div>
                <h2>Enquiries</h2>
                <br />
                <table class="table table-color table-striped">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">ENQUIRIES</th>
                            <th scope="col">NAME</th>
                            <th scope="col">EMAIL</th>
                            <th scope="col">DATE</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </div>
        </form>
    </div>

 

    <!-- ADMIN ENQUIRIES MODAL -->
    <div
      class="modal fade"
      id="viewEnquiriesModal"
      aria-hidden="true"
      tabindex="-1"
      aria-labelledby="stCoSeModalLabel"
    >
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Enquiry</h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <p><b>Name: </b> <span id="modal_name"></span></p>
            <p><b>Email: </b><span id="modal_email"></span></p>
            <p><b>Enquiry: </b><span id="modal_enquiry"></span></p>
            <br />

            <div class="reply-enquiry-btn-box">
              <a class="reply-enquiry-btn"
                >Reply</a
              >
            </div>
          </div>
        </div>
      </div>
    </div>


    <!-- bootstrap js -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

    <!-- jquery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>

    <!-- custom js -->
    <script src="./custom.js"></script>

    <!-- admin sidebar dropdown -->
    <script>
        //Drop Down
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


        //Modal
        $(function () {
            $(".td_enquiry").on('click', function () {
                let name = $(this).closest('tr').children(".td_name").text();
                let email = $(this).closest('tr').children(".td_email").text();
                let enquiry = $(this).closest('tr').children(".td_enquiry").text();


                $('#modal_name').html(name);
                $('#modal_enquiry').html(enquiry);
                $('#modal_email').html(email);
                $(".reply-enquiry-btn").attr("href", "mailto:" + email);
            });
        })

    </script>

</body>
</html>
