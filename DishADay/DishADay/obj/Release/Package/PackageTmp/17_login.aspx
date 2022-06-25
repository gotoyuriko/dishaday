<%@ page language="C#" autoeventwireup="true" codebehind="17_login.aspx.cs" inherits="DishADay._17_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>User Profile</title>

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

        <!-- login -->
        <div id="login-container">
            <div class="login-wrap p-5">
                <h1 class="text-center p-3"><em>Welcome</em></h1>
                <div>
                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="emailUsername" runat="server" class="form-control"
                            placeholder="Email or Username" required="required">
                        </asp:TextBox>

                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="loginPassword" runat="server" class="form-control"
                            placeholder="Password"
                            required="required" TextMode="Password">
                        </asp:TextBox>
                    </div>


                    <!-- Submit button -->
                    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                        <asp:Button ID="Button1" runat="server" Text="LOGIN" class="btn login-btn btn-block mb-4" OnClick="Button1_Click" />
                        
                    </div>
                    <p class="text-center">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </p>
                    <p class="text-center">
                        Don't have an account?
                    <span>
                        <a href="18_signup.aspx">Sign Up</a>
                    </span>
                    </p>

                    <p class="text-center p-2">
                        <a href="#" type="button" onclick="history.go(-1)"><i class="fa-solid fa-angles-left"></i>Back</a>
                    </p>
                </div>
            </div>
        </div>

        <!-- bootstrap js -->
        <script
            src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2"
            crossorigin="anonymous"></script>

        <!-- jsDelivr :: Sortable :: Latest (https://www.jsdelivr.com/package/npm/sortablejs) -->
        <script src="https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js"></script>

        <!-- === CUSTOM JS  ======================================-->
        <script src="custom.js"></script>

    </form>
</body>
</html>
