<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_2_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="Stylesheet" type="text/css" href="StyleSheet1.css"/>
    <title>CHECKOUT</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
        <div class="checkout_wrapper">
            <div class="product_info">
                <img src="https://i.imgur.com/Jqq0Osu.png" alt="product">
                <div class="content">
                    <h3>Puma Men's <br/>Sneakers</h3>
                    <p>₺1000</p>
                </div>
            </div>
            <div class="checkout_form">
                <p>Ödeme Bölümü</p>
                <div class="details">
                    <div class="section">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Kart Numarası" MaxLength="16" ></asp:TextBox>
                    </div>
                    <div class="section">
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="Kart Üzerindeki İsim" OnTextChanged="TextBox2_TextChanged" ></asp:TextBox>
                    </div>
                    <div class="section last_section">
                        <div class="item">
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="SKT" MaxLength="5" ></asp:TextBox>
                        </div>
                        <div class="item">
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="CVV" MaxLength="3" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">ÖDE</asp:LinkButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="220px" BorderColor="White" BorderStyle="None" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
