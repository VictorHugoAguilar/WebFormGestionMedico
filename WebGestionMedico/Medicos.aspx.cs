using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace WebGestionMedico
{
    public partial class Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnDeshabilitarControles();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void TablaMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = TablaMedico.SelectedRow.Cells[1].Text;
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/Medicos.mdf") +
            ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "select M.CodMed, M.Nif, M.Nombre, M.Direccion, M.Telefono, M.CodPostal, M.FechaNac, M.Activo, E.Descripcion, A.Nombre " +
            " from MEDICO as M inner join ESPECIALIDAD as E on M.CodEsp = E.CodEsp inner join ASEGURADORA as A on M.CodAseg = A.CodAseg " +
            " where CodMed = '" + StrIdProducto + "';";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtCodMedico.Text = reader.GetString(0);
                        txtNif.Text = reader.GetString(1);
                        txtNombre.Text = reader.GetString(2);
                        txtDireccion.Text = reader.GetString(3);
                        txtTelefono.Text = reader.GetString(4);
                        txtCP.Text = reader.GetString(5);
                        txtFecNac.Text = (reader.GetDateTime(6).ToShortDateString()).ToString();
                        if (reader.GetString(7).Equals("S") || reader.GetString(7).Equals("s"))
                            chkActivo.Checked = true;
                        else
                            chkActivo.Checked = false;
                        ddlCodEsp.SelectedItem.Selected = false;
                        ddlCodEsp.SelectedItem.Text = reader.GetString(8);
                        ddlCodAseg.SelectedItem.Selected = false;
                        ddlCodAseg.SelectedItem.Text = reader.GetString(9);
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevo.Visible = true;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    btnInsertar.Visible = false;
                    btnModificar.Visible = false;
                    btnBorrar.Visible = false;
                    btnCancelar.Visible = false;
                }
                catch (SqlException ex)
                {
                    lblMensajes.Text = error(ex);
                    return;
                }
            }
        }

        protected string error(SqlException ex)
        {
            string StrError = "<div class='alert alert-danger'>";
            StrError += "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError += "<div>Código: " + ex.Number + "</div>";
            StrError += "<div>Descripción: " + ex.Message + "</div>";
            StrError += "</div>";
            return StrError;
        }

        protected void FnDeshabilitarControles()
        {
            txtCodMedico.Enabled = false;
            txtNombre.Enabled = false;
            txtNif.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtCP.Enabled = false;
            txtFecNac.Enabled = false;
            chkActivo.Enabled = false;
            ddlCodEsp.Enabled = false;
            ddlCodAseg.Enabled = false;
        }

        protected void FnHabilitarControles()
        {
            txtCodMedico.Enabled = true;
            txtNombre.Enabled = true;
            txtNif.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCP.Enabled = true;
            txtFecNac.Enabled = true;
            chkActivo.Enabled = true;
            ddlCodEsp.Enabled = true;
            ddlCodAseg.Enabled = true;
        }

        protected void btnGestionVerOcultar_Click(object sender, EventArgs e)
        {
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = true;
            txtCodMedico.Text = "";
            txtNombre.Text = "";
            txtNif.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCP.Text = "";
            txtFecNac.Text = "";
            chkActivo.Enabled = true;
            ddlCodEsp.DataBind();
            ddlCodAseg.DataBind();
            TablaMedico.SelectedIndex = -1;
            FnHabilitarControles();
            txtCodMedico.Focus();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!(txtCodMedico.Text.Length == 0) && !(txtFecNac.Text.Length == 0) && !(txtNombre.Text.Length == 0))
            {
                lblMensajes.Text = "";
                string strCodMedico, strNombre, strDateFecNac, strNif, strDireccion, strTelefono, strCP, strCheck, strCodEsp, strCodAse;
                DateTime dateFecNac;
                strCodMedico = txtCodMedico.Text;
                strNombre = txtNombre.Text;
                strNif = txtNif.Text;
                strDireccion = txtDireccion.Text;
                strTelefono = txtTelefono.Text;
                strCP = txtCP.Text;
                if (chkActivo.Enabled)
                    strCheck = "S";
                else
                    strCheck = "N";
                strCodEsp = ddlCodEsp.SelectedItem.Value;
                strCodAse = ddlCodAseg.SelectedItem.Value;
                dateFecNac = DateTime.Parse(txtFecNac.Text);
                strDateFecNac = String.Format("{0:yyyy-MM-dd}", dateFecNac);
                string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/Medicos.mdf") +
                    ";Integrated Security=True;Connect Timeout=30";
                string strComandoSql = "INSERT MEDICO (CodMed, Nif, Nombre, Direccion, Telefono, CodPostal, FechaNac, Activo, CodEsp, CodAseg) " +
                "VALUES('" + strCodMedico + "', '" + strNif + "', '" + strNombre + "', '" + strDireccion +
                "', '" + strTelefono + "', '" + strCP + "', '" + strDateFecNac + "', '" + strCheck +
                "', '" + strCodEsp + "', '" + strCodAse + "')";
                using (SqlConnection conexion = new SqlConnection(strCadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = conexion.CreateCommand();
                        comando.CommandText = strComandoSql;
                        int inRegistrosAfectados = comando.ExecuteNonQuery();
                        if (inRegistrosAfectados == 1)
                            lblMensajes.Text = "<p class='alert alert-success'>Registro insertado correctamente</p>";
                        else
                            lblMensajes.Text = "<p class='alert alert-danger'>Error al insertar el registro</p>";
                        reInicioBtn(); ;
                    }
                    catch (SqlException ex)
                    {
                        lblMensajes.Text = error(ex);
                        return;
                    }
                }
                TablaMedico.DataBind();
                TablaMedico.SelectedIndex = -1;
                FnDeshabilitarControles();
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder insertar nuevo registro reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
            txtCodMedico.Text = "";
            txtNombre.Text = "";
            txtNif.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCP.Text = "";
            txtFecNac.Text = "";
            chkActivo.Enabled = true;
            ddlCodEsp.DataBind();
            ddlCodAseg.DataBind();
            TablaMedico.SelectedIndex = -1;
            FnDeshabilitarControles();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            FnHabilitarControles();
            btnModificar.Visible = true;
            btnCancelar.Visible = true;
            btnInsertar.Visible = false;
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnBorrar.Visible = false;
            txtCodMedico.Enabled = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaMedico.SelectedRow.Cells[1].Text;
            string strCodMedico, strNombre, strDateFecNac, strNif, strDireccion, strTelefono, strCP, strCheck, strCodEsp, strCodAse;
            DateTime dateFecNac;
            strCodMedico = txtCodMedico.Text;
            strNombre = txtNombre.Text;
            strNif = txtNif.Text;
            strDireccion = txtDireccion.Text;
            strTelefono = txtTelefono.Text;
            strCP = txtCP.Text;
            if (chkActivo.Checked == true)
                strCheck = "S";
            else
                strCheck = "N";
            strCodEsp = ddlCodEsp.SelectedItem.Value;
            strCodAse = ddlCodAseg.SelectedItem.Value;
            dateFecNac = DateTime.Parse(txtFecNac.Text);
            strDateFecNac = String.Format("{0:yyyy-MM-dd}", dateFecNac);
            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "UPDATE MEDICO SET Nif = '" + strNif.Trim() +
                "', Nombre = '" + strNombre.Trim() + "', Direccion='" + strDireccion.Trim() + "', Telefono = '" + strTelefono.Trim() +
                "', CodPostal = '" + strCP.Trim() + "', FechaNac = '" + strDateFecNac.Trim() + "', Activo='" + strCheck.Trim() +
                "', CodEsp='" + strCodEsp.Trim() + "', CodAseg = '" + strCodAse.Trim() + "'" +
                "WHERE CodMed = '" + StrIdProducto + "'";
            if (!(txtCodMedico.Text.Length == 0) && !(txtFecNac.Text.Length == 0) && !(txtNombre.Text.Length == 0))
            {
                using (SqlConnection conexion = new SqlConnection(strCadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = conexion.CreateCommand();
                        comando.CommandText = strComandoSql;
                        int inRegistrosAfectados = comando.ExecuteNonQuery();
                        if (inRegistrosAfectados == 1)
                            lblMensajes.Text = "<p class='alert alert-success'>Registro modificado correctamente</p>";
                        else
                            lblMensajes.Text = "<p class='alert alert-alert'>Error al modificar el registro<p>";
                        reInicioBtn();
                    }
                    catch (SqlException ex)
                    {
                        lblMensajes.Text = error(ex);
                        return;
                    }
                }
                TablaMedico.DataBind();
                TablaMedico.SelectedIndex = -1;
                FnDeshabilitarControles();
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder modificar el registro, reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void reInicioBtn()
        {
            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            btnBorrar.Visible = true;
            btnCancelar.Visible = true;
            btnModificar.Visible = false;
            btnInsertar.Visible = false;
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaMedico.SelectedRow.Cells[1].Text;
            string strCodMedico, strNombre, strDateFecNac, strNif, strDireccion, strTelefono, strCP, strCheck, strCodEsp, strCodAse;
            DateTime dateFecNac;
            strCodMedico = txtCodMedico.Text;
            strNombre = txtNombre.Text;
            strNif = txtNif.Text;
            strDireccion = txtDireccion.Text;
            strTelefono = txtTelefono.Text;
            strCP = txtCP.Text;
            if (chkActivo.Checked == true)
                strCheck = "S";
            else
                strCheck = "N";
            strCodEsp = ddlCodEsp.SelectedItem.Value;
            strCodAse = ddlCodAseg.SelectedItem.Value;
            dateFecNac = DateTime.Parse(txtFecNac.Text);
            strDateFecNac = String.Format("{0:yyyy-MM-dd}", dateFecNac);

            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "UPDATE MEDICO SET CodMed = '" + strCodMedico.Trim() + "', Nif = '" + strNif.Trim() +
                "', Nombre = '" + strNombre.Trim() + "', Direccion='" + strDireccion.Trim() + "', Telefono = '" + strTelefono.Trim() +
                "', CodPostal = '" + strCP.Trim() + "', FechaNac = '" + strDateFecNac.Trim() + "', Activo='" + "N" +
                "', CodEsp='" + strCodEsp.Trim() + "', CodAseg = '" + strCodAse.Trim() + "'" +
                "WHERE CodMed = '" + StrIdProducto + "'";
            if (!(txtCodMedico.Text.Length == 0) && !(txtFecNac.Text.Length == 0) && !(txtNombre.Text.Length == 0))
            {
                using (SqlConnection conexion = new SqlConnection(strCadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = conexion.CreateCommand();
                        comando.CommandText = strComandoSql;
                        int inRegistrosAfectados = comando.ExecuteNonQuery();
                        if (inRegistrosAfectados == 1)
                            lblMensajes.Text = "<p class='alert alert-success'>Registro Eliminado correctamente</p>";
                        else
                            lblMensajes.Text = "<p class='alert alert-alert'>Error al Eliminar el registro<p>";
                        reInicioBtn();
                    }
                    catch (SqlException ex)
                    {
                        lblMensajes.Text = error(ex);
                        return;
                    }
                }
                TablaMedico.DataBind();
                TablaMedico.SelectedIndex = -1;
                FnDeshabilitarControles();
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder eliminar el registro, reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }
    }
}
