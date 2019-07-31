using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGestionMedico
{
    public partial class Especialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnDeshabilitarControles();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void TablaEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = TablaEspecialidad.SelectedRow.Cells[1].Text;
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/Medicos.mdf") +
            ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "select codEsp, descripcion FROM ESPECIALIDAD " +
            " WHERE codEsp = '" + StrIdProducto + "';";
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
                        txtCodEspecialidad.Text = reader.GetString(0);
                        txtDescripcion.Text = reader.GetString(1);
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevoE.Visible = true;
                    btnEditarE.Visible = true;
                    btnEliminarE.Visible = true;
                    btnInsertarE.Visible = false;
                    btnModificarE.Visible = false;
                    btnBorrarE.Visible = false;
                    btnCancelarE.Visible = false;
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
            txtCodEspecialidad.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        protected void FnHabilitarControles()
        {
            txtCodEspecialidad.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        protected void btnNuevoE_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoE.Visible = false;
            btnEditarE.Visible = false;
            btnEliminarE.Visible = false;
            btnInsertarE.Visible = true;
            btnModificarE.Visible = false;
            btnBorrarE.Visible = false;
            btnCancelarE.Visible = true;
            txtCodEspecialidad.Text = "";
            txtDescripcion.Text = "";
            TablaEspecialidad.SelectedIndex = -1;
            FnHabilitarControles();
            txtCodEspecialidad.Focus();
        }

        protected void btnEditarE_Click(object sender, EventArgs e)
        {
            FnHabilitarControles();
            btnModificarE.Visible = true;
            btnCancelarE.Visible = true;
            btnInsertarE.Visible = false;
            btnNuevoE.Visible = false;
            btnEditarE.Visible = false;
            btnEliminarE.Visible = false;
            btnInsertarE.Visible = false;
            btnBorrarE.Visible = false;
            txtCodEspecialidad.Enabled = false;
        }

        protected void btnCancelarE_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoE.Visible = true;
            btnEditarE.Visible = false;
            btnEliminarE.Visible = false;
            btnInsertarE.Visible = false;
            btnModificarE.Visible = false;
            btnBorrarE.Visible = false;
            btnCancelarE.Visible = false;
            txtCodEspecialidad.Text = "";
            txtDescripcion.Text = "";
            TablaEspecialidad.SelectedIndex = -1;
            FnDeshabilitarControles();
        }

        protected void btnEliminarE_Click(object sender, EventArgs e)
        {
            btnBorrarE.Visible = true;
            btnCancelarE.Visible = true;
            btnModificarE.Visible = false;
            btnInsertarE.Visible = false;
            btnNuevoE.Visible = false;
            btnEditarE.Visible = false;
            btnEliminarE.Visible = false;
            btnInsertarE.Visible = false;
        }

        protected void btnInsertarE_Click(object sender, EventArgs e)
        {
            if (!(txtCodEspecialidad.Text.Length == 0) && !(txtDescripcion.Text.Length == 0))
            {
                lblMensajes.Text = "";
                string strCodEsp, strDesEsp;
                strCodEsp = txtCodEspecialidad.Text;
                strDesEsp = txtDescripcion.Text;
                string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/Medicos.mdf") +
                    ";Integrated Security=True;Connect Timeout=30";
                string strComandoSql = "INSERT ESPECIALIDAD (CodEsp, Descripcion) " +
                "VALUES('" + strCodEsp + "', '" + strDesEsp + "')";
                using (SqlConnection conexion = new SqlConnection(strCadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = conexion.CreateCommand();
                        comando.CommandText = strComandoSql;
                        int inRegistrosAfectados = comando.ExecuteNonQuery();
                        if (inRegistrosAfectados == 1)
                            lblMensajes.Text = "<p class='alert alert-success'>Registro Insertado correctamente</p>";
                        else
                            lblMensajes.Text = "<p class='alert alert-danger'>Error al Insertar el registro</p>";
                        reInicioBtn();
                    }
                    catch (SqlException ex)
                    {
                        lblMensajes.Text = error(ex);
                        return;
                    }
                }
                txtDescripcion.Text = "";
                txtCodEspecialidad.Text = "";
                TablaEspecialidad.DataBind();
                TablaEspecialidad.SelectedIndex = -1;
                FnDeshabilitarControles();
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder insertar nuevo registro reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void btnModificarE_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaEspecialidad.SelectedRow.Cells[1].Text;
            string strCodEsp, strDesEsp;
            strCodEsp = txtCodEspecialidad.Text;
            strDesEsp = txtDescripcion.Text;
            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "UPDATE ESPECIALIDAD SET Descripcion = '" + strDesEsp.Trim() + "'" +
                "WHERE CodEsp = '" + StrIdProducto + "'";
            if (!(txtCodEspecialidad.Text.Length == 0) && !(txtDescripcion.Text.Length == 0))
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
                TablaEspecialidad.DataBind();
                TablaEspecialidad.SelectedIndex = -1;
                FnDeshabilitarControles();
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder modificar el registro, reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void reInicioBtn(){
            btnNuevoE.Visible = true;
            btnEditarE.Visible = false;
            btnEliminarE.Visible = false;
            btnInsertarE.Visible = false;
            btnModificarE.Visible = false;
            btnBorrarE.Visible = false;
            btnCancelarE.Visible = false;
        }

        protected void btnBorrarE_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaEspecialidad.SelectedRow.Cells[1].Text;
            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "DELETE FROM ESPECIALIDAD " +
                "WHERE CodEsp = '" + StrIdProducto + "'";
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
            txtCodEspecialidad.Text = "";
            txtDescripcion.Text = "";
            TablaEspecialidad.DataBind();
            TablaEspecialidad.SelectedIndex = -1;
            FnDeshabilitarControles();
        }
    }
}