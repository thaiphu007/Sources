<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="KhaoSatHSSV.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="http://www.futabuslines.com.vn/Router.aspx" method="post">
    <div>
        <input id="cbbDiemDi_VI" name="cbbDiemDi_VI" type="hidden" value="38">
         <input id="cbbDiemDi_I" name="cbbDiemDi" type="hidden" value="Cà Mau">
        <input id="cbbDiemDen_VI" name="cbbDiemDen_VI" type="hidden" value="12">
         <input id="cbbDiemDen_I" name="cbbDiemDen" type="hidden" value="Cần Thơ">
        
        <input id="Submit1" type="submit" value="submit" />
    </div>
    </form>
</body>
</html>
