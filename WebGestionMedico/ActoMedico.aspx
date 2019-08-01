<%@ Page Title="Acto Médico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActoMedico.aspx.cs" Inherits="WebGestionMedico.ActoMedico" %>

<asp:Content ID="contActMedico" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Acto médico</h1>
        <hr />
        <div class="row">
            <div class="col-12 mt-2">
                <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ACTOMEDICO]"></asp:SqlDataSource>
                <asp:GridView ID="TablaActo" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CodActMed" DataSourceID="SqlDataSource1" GridLines="Horizontal" Width="600px" OnSelectedIndexChanged="TablaActo_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="CodActMed" HeaderText="Código" ReadOnly="True" SortExpression="CodActMed" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CodEsp" HeaderText="Cód. Especialidad" SortExpression="CodEsp">
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
                    <label for="txtCodAct">Código Acto Médico</label>
                    <asp:TextBox ID="txtCodAct" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-12">
                    <label for="txtDesAct">Descripción Acto Médico</label>
                    <asp:TextBox ID="txtDesAct" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-12">
                    <label for="txtCodEspAct">Especialidad Médica</label><br />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ESPECIALIDAD]"></asp:SqlDataSource>
                    <asp:DropDownList ID="ddlCodEspAct" runat="server" DataSourceID="SqlDataSource2" DataTextField="Descripcion" DataValueField="CodEsp" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="text-left">
                    <asp:Button class="btn btn-primary m-1" ID="btnNuevoAc" runat="server" Text="Nuevo" Visible="true" OnClick="btnNuevoAc_Click" />
                    <asp:Button class="btn btn-primary m-1" ID="btnEditarAc" runat="server" Text="Editar" Visible="false" OnClick="btnEditarAc_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnEliminarAc" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarAc_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnInsertarAc" runat="server" Text="Insertar" Visible="false" OnClick="btnInsertarAc_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnModificarAc" runat="server" Text="Modificar" Visible="false" OnClick="btnModificarAc_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnBorrarAc" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrarAc_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnCancelarAc" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelarAc_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
