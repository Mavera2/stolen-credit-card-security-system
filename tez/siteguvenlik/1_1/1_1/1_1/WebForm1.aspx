<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_1_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="Stylesheet" type="text/css" href="StyleSheet1.css"/>
    <title>Ana Sayfa</title>
</head>
<body>
        <h2>Kullanıcı Doğrulama Formu</h2>

    <p>Lütfen aşağıdaki alanlara doğru ve eksiksiz bilgi girişi yapınız! </p>

    <div class="row">
        <div class="col-75">
            <div class="container">
                <form id="form1" runat="server">

                    <div class="row">
                        <div class="col-50">

                            <h3>Genel Bilgiler</h3>

                            <div class="row">
                                <div class="col-50">
                                    <label for="ad">Ad</label>
                                    
                                    <asp:TextBox CssClass="text" ID="TextBox1" runat="server" placeholder="Örn: Eren"></asp:TextBox>   
                                </div>
                                <div class="col-50"/>
                                    <label for="sad">Soyad</label>
                                
                                    <asp:TextBox CssClass="text" ID="TextBox2" runat="server" placeholder="Örn: TORUN"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <label for="email"><i class="fa"></i>Email</label>
                        
                            <asp:TextBox CssClass="text" ID="TextBox3" runat="server" placeholder="Örn: erentorun455@gmail.com">@gmail.com</asp:TextBox>
                            

                            <label for="adres"><i class="fa"></i> Adres</label>
                        
                            <asp:TextBox CssClass="text" ID="TextBox4" runat="server" placeholder="Örn: Halide edip adıvar mahallesi"></asp:TextBox>
                            

                            <label for="sehir"><i class="fa"></i> Şehir</label>
                        
                            <asp:TextBox CssClass="text" ID="TextBox5" runat="server" placeholder="Örn: İstanbul"></asp:TextBox>
                            

                            <div class="row">
                                <div class="col-50">
                                    <label for="dogumt">Doğum Tarihi</label>
                                    
                                    <asp:TextBox CssClass="text" ID="TextBox6" runat="server" placeholder="Örn: 29.01.2002"></asp:TextBox>
                                    
                                </div>
                                <div class="col-50">
                                    <label for="telno">Telefon Numarası</label>
                                    
                                    <asp:TextBox CssClass="text" ID="TextBox7" runat="server" placeholder="Örn: 5349625865"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>

                        <div class="col-50">
                            <h3>Kart Bilgileri</h3>

                            <label for="kartnum">Kart Numarası</label>
                            
                            <asp:TextBox CssClass="text" ID="TextBox8" runat="server" placeholder="Örn: 1111111111111111" OnTextChanged="TextBox8_TextChanged" MaxLength="16"></asp:TextBox>
                            

                            <div class="row">
                                <div class="col-50">
                                    <label for="sonkull">Son Kullanma Tarihi</label>
                                    
                                    <asp:TextBox CssClass="text" ID="TextBox9" runat="server" placeholder="Örn: 06.2026" MaxLength="5" ></asp:TextBox>
                                    
                                </div>

                                <div class="col-50">
                                    <label for="cvv">CVV</label>
                                    
                                    <asp:TextBox CssClass="text" ID="TextBox10" runat="server" placeholder="Örn: 333" MaxLength="3"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>

                    </div>
                    
                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" /> Yukarıdaki bilgilerin doğru ve eksiksiz olduğunu kabul ediyorum ve sözleşmeyi onaylıyorum.
                    
                        <br/>
                        <br/>
                        

                    <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click"/>

                </form>
            </div>
        </div>
    </div>
</body>
</html>
