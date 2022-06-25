<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="18_signup.aspx.cs" Inherits="DishADay._18_signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="./ASSETS/favicon.ico" />
    <title>User Profile</title>

    <!--bootstrap css-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous" />

    <!-- CUSTOM css -->
    <link rel="stylesheet" href="style.css" />

    <!-- Font Awsome -->
    <script
        src="https://kit.fontawesome.com/8ebce8f613.js"
        crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" oninput='registerRepeatPassword.setCustomValidity(registerPassword.value != registerRepeatPassword.value ? "Passwords do not match." : "")'>
        <div id="signup-container">
            <div class="signup-wrap p-5">
                <h1 class="text-center p-3"><em>Create New</em></h1>

                <!-- Name input -->
                <div class="form-outline mb-4 row">
                    <div class="col">
                        <asp:TextBox ID="firstName" runat="server" class="form-control"
                            placeholder="First Name" required ="required"></asp:TextBox>

                    </div>
                    <div class="col">
                        <asp:TextBox ID="lastName" runat="server" class="form-control"
                            placeholder="Last Name" required  ="required"></asp:TextBox>

                    </div>
                </div>

                <!-- Username input -->
                <div class="form-outline mb-4">
                    <asp:TextBox ID="registerUsername" runat="server" class="form-control" placeholder="Username" required="required"></asp:TextBox>
                    <asp:Label ID="usernameError" runat="server" Text=""></asp:Label>
                </div>



                <!-- Email input -->
                <div class="form-outline mb-4">
                    <asp:TextBox ID="registerEmail" runat="server" class="form-control"
                        placeholder="Email" TextMode="Email" required="required"></asp:TextBox>
                </div>

                <!-- Password input -->
                <div class="form-outline mb-4">
                    <asp:TextBox ID="password" runat="server" class="form-control"
                        placeholder="Password" TextMode="Password" required="required"></asp:TextBox>
                </div>

                <!-- Repeat Password input -->
                <div class="form-outline mb-4">
                    <asp:TextBox ID="registerRepeatPassword" runat="server" class="form-control"
                        placeholder="Confirm Password" TextMode="Password" required="required"></asp:TextBox>
                    <asp:Label ID="registerRepeatPasswordErrorMsg" runat="server" Text=""></asp:Label>
                </div>

                <!-- Birthday input -->
                <div class="form-outline mb-4">
                    <asp:TextBox ID="birthDate" runat="server" class="form-control"
                        placeholder="Birth Date"
                        TextMode="Date" required="required"></asp:TextBox>
                </div>
                <!-- Submit button -->
                <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                    <asp:Button ID="Button1" runat="server" Text="SIGN UP" class="btn signup-btn btn-block mb-3" OnClick="Button1_Click" />

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>

                </div>

                <p class="text-center">
                    Already have an account?
            <span>
                <a href="./17_login.aspx">Log In</a>
            </span>
                </p>

                <p class="text-center p-2">
                    <a href="#" type="button" onclick="history.go(-1)"><i class="fa-solid fa-angles-left"></i>Back</a>
                </p>

            </div>
        </div>


        <!-- bootstrap js -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

        <!-- jquery -->
        <script src="https://ajax.googleapis.com/ajax/libs/cesiumjs/1.78/Build/Cesium/Cesium.js"></script>

        <!-- custom js -->
        <script src="./custom.js"></script>
    </form>
</body>
</html>
