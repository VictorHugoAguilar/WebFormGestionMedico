<%@ Page Title="Aseguradora" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aseguradoras.aspx.cs" Inherits="WebGestionMedico.Aseguradoras" %>

<asp:Content ID="contAseguradora" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Aseguradora</h1>
        <hr />
        <div class="row">
            <div class="col-12 mt-2">
                <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ASEGURADORA]"></asp:SqlDataSource>
                <asp:GridView ID="TablaAseguradora" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CodAseg" DataSourceID="SqlDataSource1" GridLines="Horizontal" Width="600px" OnSelectedIndexChanged="TablaAseguradora_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                        <asp:BoundField DataField="CodAseg" HeaderText="Código" ReadOnly="True" SortExpression="CodAseg">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PrecHora" DataFormatString="{0:C}" HeaderText="Precio" SortExpression="PrecHora">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </div>
            <br />
            <div class="col-md-1" ></div>
            <div class="col-md-4">
                <div class="form-group col-md-12">
                    <label for="txtCodAseguradora">Código Aseguradora</label>
                    <asp:TextBox ID="txtCodAseguradora" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-12">
                    <label for="txtNombreAseguradora">Nombre de Aseguradora</label>
                    <asp:TextBox ID="txtNombreAseguradora" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-12">
                    <label for="txtPrecioServicio">Precio Servicio Hora</label>
                    <asp:TextBox ID="txtPrecioServicio" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="text-left">
                    <asp:Button class="btn btn-primary m-1" ID="btnNuevoA" runat="server" Text="Nuevo" Visible="true" OnClick="btnNuevoA_Click" />
                    <asp:Button class="btn btn-primary m-1" ID="btnEditarA" runat="server" Text="Editar" Visible="false" OnClick="btnEditarA_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnEliminarA" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarA_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnInsertarA" runat="server" Text="Insertar" Visible="false" OnClick="btnInsertarA_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnModificarA" runat="server" Text="Modificar" Visible="false" OnClick="btnModificarA_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnBorrarA" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrarA_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnCancelarA" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelarA_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
