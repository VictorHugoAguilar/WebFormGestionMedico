<%@ Page Title="Especialidad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidad.aspx.cs" Inherits="WebGestionMedico.Especialidad" %>

<asp:Content ID="contEspecialidad" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Especialidad</h1>
        <hr />
        <div class="row">
            <div class="col-12 mt-2">
                <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ESPECIALIDAD]"></asp:SqlDataSource>
                <asp:GridView ID="TablaEspecialidad" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CodEsp" DataSourceID="SqlDataSource1" GridLines="Horizontal" Width="600px" OnSelectedIndexChanged="TablaEspecialidad_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="CodEsp" HeaderText="Codigo Especialidad" ReadOnly="True" SortExpression="CodEsp">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                            <HeaderStyle HorizontalAlign="Center" />
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
            <div class="col-md-1"></div>
            <div class="col-md-4">
                <div class="form-group col-md-12">
                    <label for="CodMedico">Código Especialidad Médica</label>
                    <asp:TextBox ID="txtCodEspecialidad" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-12">
                    <label for="inputAddress">Descripción de Especialidad</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="text-left">
                    <asp:Button class="btn btn-primary m-1" ID="btnNuevoE" runat="server" Text="Nuevo" Visible="true" OnClick="btnNuevoE_Click" />
                    <asp:Button class="btn btn-primary m-1" ID="btnEditarE" runat="server" Text="Editar" Visible="false" OnClick="btnEditarE_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnEliminarE" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarE_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnInsertarE" runat="server" Text="Insertar" Visible="false" OnClick="btnInsertarE_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnModificarE" runat="server" Text="Modificar" Visible="false" OnClick="btnModificarE_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnBorrarE" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrarE_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnCancelarE" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelarE_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
