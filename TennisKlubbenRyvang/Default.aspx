<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TennisKlubbenRyvang._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="display: flex; flex-direction: column">

        <h1>Registrer en bruger</h1>
        <p>Udfyld venligst formlen for at oprette en bruger.</p>
        <hr>
        
        <label for="navnTextBox"><b>Navn</b></label>
        <asp:TextBox runat="server" type="text" placeholder="Navn" name="navnTextBox" ID="navnTextBox"></asp:TextBox>
        
        <label for="bdayTextBox"><b>Fødselsdato</b></label>
        <asp:TextBox runat="server" type="text" placeholder="Dag/Måned/År" name="bdayTextBox" ID="bdayTextBox"></asp:TextBox>

        <label for="adresseTextBox"><b>Adresse</b></label>
        <asp:TextBox runat="server" type="text" placeholder="Adresse" name="adresseTextBox" ID="adresseTextBox"></asp:TextBox>
        
        <label for="telefonTextBox"><b>Telefon</b></label>
        <asp:TextBox runat="server" type="text" placeholder="Telefon" name="telefonTextBox" ID="telefonTextBox"></asp:TextBox>

        <label for="emailTextBox"><b>Email</b></label>
        <asp:TextBox runat="server" type="text" placeholder="Email" name="emailTextBox" ID="emailTextBox"></asp:TextBox>

        <label for="pswTextBox"><b>Kodeord</b></label>
        <asp:TextBox runat="server" type="password" placeholder="Kodeord" name="pswTextBox" ID="pswTextBox"></asp:TextBox>

        <label for="psw-repeatTextBox"><b>Gentag kodeord</b></label>
        <asp:TextBox runat="server" type="password" placeholder="Gentag kodeord" name="pswRepeatTextBox" ID="pswRepeatTextBox"></asp:TextBox>
        <hr>

        <asp:TextBox runat="server" name="warningText" ID="warningText" Visible="false"></asp:TextBox>

        <asp:Button type="submit" class="registerbtn" runat="server" Text="Opret login" OnClick="Submit_Click"></asp:Button>

    </div>

</asp:Content>
