<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucStatus.ascx.cs" Inherits="administrator_usercontrols_ucStatus" %>
  <% if (Request["act"] == "edit")
   { %>
        <span class="status">Sữa</span> 
    <%}
   else
   { %>
        <span class="status">Thêm</span> 
    
    <%} %>
<hr />