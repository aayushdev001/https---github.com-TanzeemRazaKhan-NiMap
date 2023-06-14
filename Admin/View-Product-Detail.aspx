<%@ Page Title="View Product Detail" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="View-Product-Detail.aspx.cs" Inherits="Departments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="sm1" ScriptMode="Release" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div class="page-wrapper" style="min-height: 568px;">
        <div class="content container-fluid">
            <div class="page-header">
                <div class="row align-items-center">
                    <div class="col">
                        <h3 class="page-title">View Product Detail</h3>
                    </div>
                     <div class="col-auto float-end ms-auto">
                        <asp:HyperLink class="btn add-btn" Text="Add Product" NavigateUrl="Add-Product.aspx" runat="server"></asp:HyperLink>
                    </div>
                </div>
            </div>
            <div id="table-datatables" class="table-responsive">
                <asp:GridView ID="gvv" runat="server" class="table table-nowrap mb-0" EmptyDataText="No records found"  AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Product ID" HeaderText="Product ID" SortExpression="Product ID" />
                        <asp:BoundField DataField="Product Name" HeaderText="Product Name" SortExpression="Product Name" />  
                        <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />                        
                        <asp:BoundField DataField="Edit" HeaderText="Edit" SortExpression="Edit" />
                        <asp:BoundField DataField="Delete" HeaderText="Delete" SortExpression="Delete" />
                    </Columns>
                    <RowStyle HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle HorizontalAlign="Center" />
                    <PagerStyle HorizontalAlign="Center" CssClass="gridpaging" />
                </asp:GridView>
            </div>
        </div>
    </div>      
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <link href="assets/css/popup.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.datatables.net/buttons/1.4.1/js/dataTables.buttons.min.js"></script>
    <script src="//cdn.datatables.net/buttons/1.4.1/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.1/js/buttons.html5.min.js"></script>


    <script type="text/javascript">
        $(function () {

            $.ajax({
                type: "POST",
                url: "View-Product-Detail.aspx/GetData",
                beforeSend: function () {
                },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                complete: function (data) {
                },
                failure: function (response) {
                },
                error: function (response) {
                }
            });
        });
        function OnSuccess(response) {
            //alert('proc..');
            $("[id*=gvv]").DataTable(
                {
                    dom: 'Blfrtip',
                    iDisplayLength: '20',
                    buttons: [
                        {
                            extend: 'excelHtml5',
                            text: 'Download Excel'
                        }
                    ],
                    bLengthChange: true,
                    lengthMenu: false,
                    bFilter: true,
                    bSort: true,
                    "aaSorting": [],
                    bPaginate: true,
                    data: response.d,
                    columns: [

                        {
                            data: 'productcode',
                            name: 'categoruycode',
                        },
                        {
                            data: 'productname',
                            name: 'cattegoryname',
                        },
                        {
                            data: 'category',
                            name: 'category',
                        },
                        {
                            data: 'id',
                            name: 'id',
                            render: function (data, type, row, meta) { return '<a class="d-inline-block fw-normal w-100 h-100 pe-auto" href="Edit-Product.aspx?id=' + row.id + '">Edit</a>'; },
                        },
                       
                        {
                            data: 'id',
                            name: 'id',
                            render: function (data, type, row, meta) { return '<a class="d-inline-block fw-normal w-100 h-100 pe-auto" href="View-Product-Detail.aspx?action=delete&id=' + row.id + '">Delete</a>'; },
                        }
                      ]
                });
        };
    </script>
  
    <style>
        @media only screen and (max-width:568px) {
            .dt-buttons {
                text-align: center;
            }
        }

        #cph_gvv_length {
            display: none !important;
        }

        button.dt-button, div.dt-button, a.dt-button {
            position: relative;
            display: inline-block;
            box-sizing: border-box;
            margin-right: 0.333em;
            padding: 0.3em 1em;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
            font-size: 0.88em;
            color: black;
            white-space: nowrap;
            overflow: hidden;
            background-color: #e9e9e9;
            background-image: -webkit-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -moz-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -ms-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: -o-linear-gradient(top, #fff 0%, #e9e9e9 100%);
            background-image: linear-gradient(to bottom, #fff 0%, #e9e9e9 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0,StartColorStr='white', EndColorStr='#e9e9e9');
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            text-decoration: none;
            outline: none;
        }

        table.dataTable tbody th, table.dataTable tbody td {
            text-align: center !important;
        }
    </style>

    <script type="text/javascript">function Showmenu(x, y) {
            y = y.replace(/,\s*$/, "");
            var res = x.split(",");
            var res2 = y.split(",");
            for (i = 0; i < res.length; i++) {
                document.getElementById(res[i]).style.display = "block";
            }
            for (i = 0; i < res2.length; i++) {
                document.getElementById(res2[i]).style.display = "block";
            }
        }
    </script>
       <script>
           function OpenConfirmDialog(a) {
               //alert('he;;o');
               $("#myModal2").modal('show');
           }
       </script>
      <div id="myModal2" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <p>
                        <asp:Literal ID="litid2" runat="server"></asp:Literal>
                    </p>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="input-field col s12 l12 m12">
                            <div class="row">
                                <div class="input-field col s12">
                                    <asp:Button ID="BtnDelete" OnClick="BtnDelete_Click1" BackColor="Red" ForeColor="White" class="mt-4 right btn waves-effect waves-light Click-here" runat="server" Text="Delete" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
