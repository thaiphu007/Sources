<%@ Control Language="C#" AutoEventWireup="true" Inherits="administrator_usercontrols_ucStatus" Codebehind="ucStatus.ascx.cs" %>
  <% if (Request["act"] == "edit")
   { %>
        <span class="status">Sữa</span> 
    <%}
   else
   { %>
        <span class="status">Thêm</span> 
    
    <%} %>
<hr />