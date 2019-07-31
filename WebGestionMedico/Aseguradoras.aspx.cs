using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGestionMedico
{
    public partial class Aseguradoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnDeshabilitarControles();
        }

        protected void TablaAseguradora_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = TablaAseguradora.SelectedRow.Cells[1].Text;
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/Medicos.mdf") +
            ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "select CodAseg, Nombre, PrecHora FROM ASEGURADORA " +
            " WHERE CodAseg = '" + StrIdProducto + "';";
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
                        txtCodAseguradora.Text = reader.GetString(0);
                        txtNombreAseguradora.Text = reader.GetString(1);
                        txtPrecioServicio.Text = string.Format("{0:C}", reader.GetDecimal(2)); ;
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevoA.Visible = true;
                    btnEditarA.Visible = true;
                    btnEliminarA.Visible = true;
                    btnInsertarA.Visible = false;
                    btnModificarA.Visible = false;
                    btnBorrarA.Visible = false;
                    btnCancelarA.Visible = false;
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
            txtCodAseguradora.Enabled = false;
            txtNombreAseguradora.Enabled = false;
            txtPrecioServicio.Enabled = false;

        }

        protected void FnHabilitarControles()
        {
            txtCodAseguradora.Enabled = true;
            txtNombreAseguradora.Enabled = true;
            txtPrecioServicio.Enabled = true;
        }

        protected string FnComaPorPunto(string Numero)
        {
            string StrNumero = Convert.ToString(Numero);
            string stNumeroConPunto = String.Format("{0}", StrNumero.Replace(',', '.'));
            return (stNumeroConPunto);
        }

        protected void reInicioBtn()
        {
            btnNuevoA.Visible = true;
            btnEditarA.Visible = false;
            btnEliminarA.Visible = false;
            btnInsertarA.Visible = false;
            btnModificarA.Visible = false;
            btnBorrarA.Visible = false;
            btnCancelarA.Visible = false;
        }

        protected void btnNuevoA_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoA.Visible = false;
            btnEditarA.Visible = false;
            btnEliminarA.Visible = false;
            btnInsertarA.Visible = true;
            btnModificarA.Visible = false;
            btnBorrarA.Visible = false;
            btnCancelarA.Visible = true;
            txtCodAseguradora.Text = "";
            txtNombreAseguradora.Text = "";
            txtPrecioServicio.Text = Convert.ToString(0);
            TablaAseguradora.SelectedIndex = -1;
            FnHabilitarControles();
            txtCodAseguradora.Focus();
        }

        protected void btnInsertarA_Click(object sender, EventArgs e)
        {
            if (!(txtCodAseguradora.Text.Length == 0) && !(txtNombreAseguradora.Text.Length == 0) && !(txtPrecioServicio.Text.Length == 0))
            {
                lblMensajes.Text = "";
                string strCodAse, strNombre;
                decimal dcPrecio;
                strCodAse = txtCodAseguradora.Text;
                strNombre = txtNombreAseguradora.Text;
                dcPrecio = Convert.ToDecimal(txtPrecioServicio.Text);

                string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/Medicos.mdf") +
                    ";Integrated Security=True;Connect Timeout=30";
                string strComandoSql = "INSERT ASEGURADORA (CodAseg, Nombre, PrecHora) " +
                "VALUES('" + strCodAse + "', '" + strNombre + "', '" + dcPrecio + "')";
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

        protected void btnEditarA_Click(object sender, EventArgs e)
        {
            FnHabilitarControles();
            btnModificarA.Visible = true;
            btnCancelarA.Visible = true;
            btnInsertarA.Visible = false;
            btnNuevoA.Visible = false;
            btnEditarA.Visible = false;
            btnEliminarA.Visible = false;
            btnInsertarA.Visible = false;
            btnBorrarA.Visible = false;
            txtCodAseguradora.Enabled = false;
        }

        protected void btnEliminarA_Click(object sender, EventArgs e)
        {
            btnBorrarA.Visible = true;
            btnCancelarA.Visible = true;
            btnModificarA.Visible = false;
            btnInsertarA.Visible = false;
            btnNuevoA.Visible = false;
            btnEditarA.Visible = false;
            btnEliminarA.Visible = false;
            btnInsertarA.Visible = false;
        }


        protected void btnModificarA_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaAseguradora.SelectedRow.Cells[1].Text;
            string strCodAse, strNombre, strPrecio;
            decimal dcPrecio;
            strCodAse = txtCodAseguradora.Text;
            strNombre = txtNombreAseguradora.Text;
            strPrecio = txtPrecioServicio.Text.ToString().Replace("€", "");

            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "UPDATE ASEGURADORA SET Nombre = '" + strNombre.Trim() + "'," +
                " PrecHora = " + FnComaPorPunto(strPrecio) + " WHERE CodAseg = '" + StrIdProducto + "'";

            if (!(txtCodAseguradora.Text.Length == 0) && !(txtNombreAseguradora.Text.Length == 0) && !(txtPrecioServicio.Text.Length == 0))
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

        protected void btnBorrarA_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            string StrIdProducto = TablaAseguradora.SelectedRow.Cells[1].Text;
            string strCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/Medicos.mdf") +
                 ";Integrated Security=True;Connect Timeout=30";
            string strComandoSql = "DELETE FROM ASEGURADORA " +
                "WHERE CodAseg = '" + StrIdProducto + "'";
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

        protected void btnCancelarA_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevoA.Visible = true;
            btnEditarA.Visible = false;
            btnEliminarA.Visible = false;
            btnInsertarA.Visible = false;
            btnModificarA.Visible = false;
            btnBorrarA.Visible = false;
            btnCancelarA.Visible = false;
            txtCodAseguradora.Text = "";
            txtNombreAseguradora.Text = "";
            txtPrecioServicio.Text = Convert.ToString(0);
            TablaAseguradora.DataBind();
            TablaAseguradora.SelectedIndex = -1;
            FnDeshabilitarControles();
        }

        private void restaurar()
        {
            FnDeshabilitarControles();
            txtCodAseguradora.Text = "";
            txtNombreAseguradora.Text = "";
            txtPrecioServicio.Text = Convert.ToString(0);
            TablaAseguradora.DataBind();
            TablaAseguradora.SelectedIndex = -1;
        }
    }
}