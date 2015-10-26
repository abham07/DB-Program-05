<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitForm.aspx.cs" Inherits="Assign_5.SubmitForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/md5.js"></script>
    <script type="text/javascript">
        function GeneratePwd()
        {
            document.getElementById("txtPwd").value = hex_md5(document.getElementById("txtPwd").value);
            document.getElementById("submitform").submit();
        }
    </script>
</head>
<body>
    <form id="submitform" action="SubmitForm.aspx" onsubmit="GeneratePwd()" method="post">
        <b>USER LOGIN FORM</b>
        <br /><br />
        Enter username: <input id="txtName" name="txtName" type="text" />
        <br />
        Enter password: <input id="txtPwd" name="txtPwd" type="password" />
        <br /><br />
        <input id="btn_Submit" type="submit" value="Submit" />
    </form> 
</body>
</html>
