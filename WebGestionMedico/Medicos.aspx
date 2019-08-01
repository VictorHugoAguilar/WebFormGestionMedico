<%@ Page Title="Medicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebGestionMedico.Medicos" %>

<asp:Content ID="contMedicos" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Médicos</h1>
        <hr />
        <div class="row">
            <div class="col-12 mt-2">
                <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            <div class="col-12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [MEDICO] WHERE ([Activo] = @Activo)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="s" Name="Activo" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="TablaMedico" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CodMed" DataSourceID="SqlDataSource1" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" Width="100%" OnSelectedIndexChanged="TablaMedico_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="CodMed" HeaderText="Código" ReadOnly="True" SortExpression="CodMed" />
                        <asp:BoundField DataField="Nif" HeaderText="Nif" SortExpression="Nif" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                        <asp:BoundField DataField="CodPostal" HeaderText="Cod Postal" SortExpression="CodPostal">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaNac" HeaderText="Fecha Nacimiento" SortExpression="FechaNac" DataFormatString="{0:dd-MM-yyyy}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CodEsp" HeaderText="Cod Especialista" SortExpression="CodEsp">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CodAseg" HeaderText="Cod Asegurado" SortExpression="CodAseg ">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerSettings FirstPageText="Primera" LastPageText="Última" Mode="NextPreviousFirstLast" NextPageText="Siguiente" PreviousPageText="Anterior" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" BorderStyle="Solid" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </div>
            <br />
            <div class="col-12 mt-4">
                <h4>Gestionar</h4>
                <div class="row">
                    <div class="form-group col-md-4">
                        <label for="CodMedico">Código Médico</label>
                        <asp:TextBox ID="txtCodMedico" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="inputAddress">Nombre Médico</label>
                        <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4">
                        <label for="Nif">Nif/Cif Médico</label>
                        <asp:TextBox ID="txtNif" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="Direccion">Dirección Consulta</label>
                        <asp:TextBox ID="txtDireccion" runat="server" Width="100%"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-4">
                        <label for="Direccion">Código Postal</label>
                        <asp:TextBox ID="txtCP" runat="server" Width="100%"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4">
                        <label for="Direccion">Teléfono Móvil</label>
                        <asp:TextBox ID="txtTelefono" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="Direccion">Fecha Nacimiento Médico</label>
                        <asp:TextBox ID="txtFecNac" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="my-1 mr-2" for="inlineFormCustomSelectPref">Código Especilista</label>&nbsp;
                        <asp:DropDownList ID="ddlCodEsp" Width="100%" runat="server" DataSourceID="SqlDataSource2" DataTextField="Descripcion" DataValueField="CodEsp">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ESPECIALIDAD]"></asp:SqlDataSource>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="my-1 mr-2" for="inlineFormCustomSelectPref">Código Asegurado</label>&nbsp;
                        <asp:DropDownList ID="ddlCodAseg" runat="server" DataSourceID="SqlDataSource3" DataTextField="Nombre" DataValueField="CodAseg" Width="100%">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ASEGURADORA]"></asp:SqlDataSource>
                    </div>
                    <div class="form-group col-md-4">
                        <div class="form-check">
                            <asp:CheckBox ID="chkActivo" runat="server" />
                            <label class="form-check-label" for="Activo">
                                Activo
                            </label>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button class="btn btn-primary m-1" ID="btnNuevo" runat="server" Text="Nuevo" Visible="true" OnClick="btnNuevo_Click" />
                    <asp:Button class="btn btn-primary m-1" ID="btnEditar" runat="server" Text="Editar" Visible="false" OnClick="btnEditar_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnEliminar" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnInsertar" runat="server" Text="Insertar" Visible="false" OnClick="btnInsertar_Click" />
                    <asp:Button class="btn btn-success m-1" ID="btnModificar" runat="server" Text="Modificar" Visible="false" OnClick="btnModificar_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnBorrar" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrar_Click" />
                    <asp:Button class="btn btn-danger m-1" ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar_Click" />
                </div>
            </div>
            <br />

        </div>
    </div>
</asp:Content>
