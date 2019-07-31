using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGestionMedico
{
    public partial class ActoMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnDeshabilitarControles();
        }

        protected void TablaActo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = TablaActo.SelectedRow.Cells[1].Text;
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/Medicos.mdf") +
            ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "select CodActMed, Descripcion, CodEsp FROM ACTOMEDICO " +
            " WHERE CodActMed = '" + StrIdProducto + "';";
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
                        txtCodAct.Text = reader.GetString(0);
                        txtDesAct.Text = reader.GetString(1);
                        ddlCodEspAct.SelectedItem.Selected = false;
                        ddlCodEspAct.SelectedItem.Text = reader.GetString(2);
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevoAc.Visible = true;
                    btnEditarAc.Visible = true;
                    btnEliminarAc.Visible = true;
                    btnInsertarAc.Visible = false;
                    btnModificarAc.Visible = false;
                    btnBorrarAc.Visible = false;
                    btnCancelarAc.Visible = false;
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
            txtCodAct.Enabled = false;
            txtDesAct.Enabled = false;
            ddlCodEspAct.Enabled = false;

        }

        protected void FnHabilitarControles()
        {
            txtCodAct.Enabled = true;
            txtDesAct.Enabled = true;
            ddlCodEspAct.Enabled = true;
        }
        protected void reInicioBtn()
        {
            btnNuevoAc.Visible = true;
            btnEditarAc.Visible = false;
            btnEliminarAc.Visible = false;
            btnInsertarAc.Visible = false;
            btnModificarAc.Visible = false;
            btnBorrarAc.Visible = false;
            btnCancelarAc.Visible = false;
        }

        protected void btnNuevoAc_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoAc.Visible = false;
            btnEditarAc.Visible = false;
            btnEliminarAc.Visible = false;
            btnInsertarAc.Visible = true;
            btnModificarAc.Visible = false;
            btnBorrarAc.Visible = false;
            btnCancelarAc.Visible = true;
            txtCodAct.Text = "";
            txtDesAct.Text = "";
            ddlCodEspAct.DataBind();
            TablaActo.SelectedIndex = -1;
            FnHabilitarControles();
            txtCodAct.Focus();
        }

        protected void btnEditarAc_Click(object sender, EventArgs e)
        {
            FnHabilitarControles();
            btnModificarAc.Visible = true;
            btnCancelarAc.Visible = true;
            btnInsertarAc.Visible = false;
            btnNuevoAc.Visible = false;
            btnEditarAc.Visible = false;
            btnEliminarAc.Visible = false;
            btnInsertarAc.Visible = false;
            btnBorrarAc.Visible = false;
            txtCodAct.Enabled = false;
        }

        protected void btnEliminarAc_Click(object sender, EventArgs e)
        {
            btnBorrarAc.Visible = true;
            btnCancelarAc.Visible = true;
            btnModificarAc.Visible = false;
            btnInsertarAc.Visible = false;
            btnNuevoAc.Visible = false;
            btnEditarAc.Visible = false;
            btnEliminarAc.Visible = false;
            btnInsertarAc.Visible = false;

        }

        protected void btnInsertarAc_Click(object sender, EventArgs e)
        {
            if (!(txtCodAct.Text.Length == 0) && !(txtDesAct.Text.Length == 0))
            {
                lblMensajes.Text = "";
                string strCodAct, strDesc, strCodEsp;
                strCodAct = txtCodAct.Text;
                strDesc = txtDesAct.Text;
                strCodEsp = ddlCodEspAct.SelectedItem.Value;

                string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/Medicos.mdf") +
                    ";Integrated Security=True;Connect Timeout=30";
                string strComandoSql = "INSERT ACTOMEDICO (CodActMed, Descripcion, CodEsp) " +
                "VALUES('" + strCodAct + "', '" + strDesc + "', '" + strCodEsp + "')";
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
                    finally
                    {
                        restaurar();
                    }
                }
            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder insertar nuevo registro reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void btnModificarAc_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string strCodAct = TablaActo.SelectedRow.Cells[1].Text;
            string strDesc, strCodEsp;
            strDesc = txtDesAct.Text;
            strCodEsp = ddlCodEspAct.SelectedItem.Value;

            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "UPDATE ACTOMEDICO SET Descripcion = '" + strDesc.Trim() + "'," +
                " CodEsp = '" + strCodEsp + "' WHERE CodActMed = '" + strCodAct + "'";

            if (!(txtCodAct.Text.Length == 0) && !(txtDesAct.Text.Length == 0))
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
                    finally
                    {
                        restaurar();
                    }
                }

            }
            else
            {
                string StrErrorCamposVacios = "<p class='alert alert-danger'> Hay Campos Necesarios para poder modificar el registro, reviselo </p>";
                lblMensajes.Text = StrErrorCamposVacios;
            }
        }

        protected void btnBorrarAc_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string strCodAct = TablaActo.SelectedRow.Cells[1].Text;
            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "DELETE FROM ACTOMEDICO " +
                "WHERE CodActMed = '" + strCodAct + "'";
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
                finally
                {
                    restaurar();
                }
            }

        }

        protected void btnCancelarAc_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoAc.Visible = true;
            btnEditarAc.Visible = false;
            btnEliminarAc.Visible = false;
            btnInsertarAc.Visible = false;
            btnModificarAc.Visible = false;
            btnBorrarAc.Visible = false;
            btnCancelarAc.Visible = false;
            restaurar();
        }

        private void restaurar()
        {
            FnDeshabilitarControles();
            txtCodAct.Text = "";
            txtDesAct.Text = "";
            ddlCodEspAct.DataBind();
            TablaActo.DataBind();
            TablaActo.SelectedIndex = -1;
        }
    }
}