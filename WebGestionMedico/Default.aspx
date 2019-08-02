<%@ Page Title="Página Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebGestionMedico._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Gestión de Médicos</h1>
        <p>La herramienta definitiva para la gestión de las visitas y la comunicación con sus pacientes.</p>
        <a runat="server" class="btn btn-primary btn-lg" href="~/Medicos">ir a Médicos...<span class="sr-only">(current)</span></a>

    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Ahorre tiempo en la gestión de su consulta.</h2>
            <p>Gestione su agenda médica de forma fácil e intuitiva. </p>
            <p>La herramienta definitiva para la gestión de las visitas y la comunicación con sus pacientes.</p>
        </div>
        <div class="col-md-4">
            <h2>El sistema que necesita</h2>
            <p>
                En la agenda médica de Doctoralia podrá incluir todas las consultas en las que trabaja, los horarios de cada una de ellas y podrá elegir qué días y horas quiere mostrar para la solicitud de citas online.           
            </p>
        </div>
        <div class="col-md-4">
            <h2>Añada o modifique visitas de forma sencilla</h2>
            <p>
                Las visitas que se reservan de forma online desde su perfil de Doctoralia se añadirán automáticamente en su agenda. Podrá modificarlas fácilmente y se notificarán los cambios a los pacientes sin ningún esfuerzo.
            </p>
        </div>
        <div class="col-md-4">
            <h2>La mejor opción para las visitas cíclicas</h2>
            <p>
                Programe de forma sencilla aquellas visitas que se repiten, por ejemplo, una vez al mes. Podrá, además, informar de forma automática a los pacientes sobre las próximas visitas programadas.           
            </p>
        </div>
        <div class="col-md-4">
            <h2>Acceda desde cualquier lugar
            </h2>
            <p>
                Podrá acceder a la agenda online y todas sus funcionalidades desde cualquier dispositivo.           
            </p>
        </div>
    </div>
</asp:Content>
