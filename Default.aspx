<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (role == Role.Admin) { %>
          <input type="file" name="templateFile" id ="templateFile" value=""  multiple="multiple"  />
      <% }%>
    <%else{ %>
     <input type="file" name="templateFile" id ="templateFile" value="" />
    <%} %>
 
    <input type="button" name="btnFileUpload" id="btnFileUpload" value="Upload" />
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnFileUpload").click(function () {
                debugger;
                var files = $("#templateFile")[0].files;
                if (files.length > 0) {
                    var formData = new FormData();
                    for (var i = 0; i < files.length; i++) {
                            formData.append(files[i].name, files[i])
                    }
                }
                $.ajax({
                    url: "/Upload.ashx",
                    method: "post",
                    data:formData,
                    contentType: false,
                    processData: false,
                    success: function (data) { },
                    error: function (err) { alert(err.responseText);}
                });

            });
        });

    </script>

</asp:Content>
