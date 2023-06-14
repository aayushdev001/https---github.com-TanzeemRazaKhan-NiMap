<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="~/Admin/Edit-Category.aspx.cs" Inherits="Add_Branch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="sm1" ScriptMode="Release" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div class="page-wrapper" style="min-height: 568px;">
        <div class="content container-fluid">
            <div class="page-header">
                <div class="row">
                    <div class="col">
                        <h3 class="page-title">Edit Category</h3>
                    </div>
                    <div class="col-auto float-end ms-auto">
                        <asp:HyperLink class="btn add-btn" Text="View Category" NavigateUrl="View-Category-Detail.aspx" runat="server"></asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-12 d-flex">
                    <div class="card flex-fill">
                        <div class="card-body">
                                    <div class="form-group row">
                                      
                                        <div class="col-lg-4">
                                            <label class="col-form-label">Category ID<asp:RequiredFieldValidator ID="rqtxtfirst" Font-Size="9" runat="server" ControlToValidate="txtfirst" Text="*" ForeColor="Red"  Display="Dynamic" ErrorMessage="Enter Pendency">
                                    </asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtfirst" class="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftxtfirst" FilterMode="ValidChars" TargetControlID="txtfirst" ValidChars="qwertyuioplkjhgfdsazxcvbnm QWERTYUIOPLKJHGFDSAZXCVBNM 1234567890" runat="server"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="col-form-label">Category Name<asp:RequiredFieldValidator ID="rqtxtlast" Font-Size="9" runat="server" ControlToValidate="txtlast" Text="*" ForeColor="Red"  Display="Dynamic" ErrorMessage="Enter Pendency">
                                    </asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtlast" class="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftxtlast" FilterMode="ValidChars" TargetControlID="txtlast" ValidChars="qwertyuioplkjhgfdsazxcvbnm QWERTYUIOPLKJHGFDSAZXCVBNM" runat="server"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>                                         
                                    </div>
                                   
                                    <div style="text-align: end;">
                                        <asp:LinkButton ID="LinkButton1" class="btn btn-primary account-btn" OnClick="LinkButton1_Click"  runat="server">Submit</asp:LinkButton>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link href="assets/plugins/sweetalert/sweetalert.css" type="text/css" rel="stylesheet" media="screen,projection" />
    <script type="text/javascript" src="assets/plugins/sweetalert/sweetalert.min.js"></script>
    <script type="text/javascript">
        function successmsg(a, b, c) {
            swal(a, b, c);
        }
        function errormsg(a, b) { swal({ title: a, text: b, imageUrl: "images/Error.png" }); }


    </script>
</asp:Content>
