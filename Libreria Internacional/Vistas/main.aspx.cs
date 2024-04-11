using Libreria_Internacional.Controles;
using Libreria_Internacional.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libreria_Internacional.Vistas
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibreriaController libreriacontroller = new LibreriaController();

            List<Libreria> libreriaLista = libreriacontroller.GetLibrerias();

            repLibreria.DataSource = libreriaLista;
            repLibreria.DataBind();

        }
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            FirebaseUser user = new FirebaseUser()
            {
                email = txtEmail.Value,
                password = txtPwd.Value
            };

            LoginController loginController = new LoginController();

            if (loginController.FirebaseAuth(user))
            {
                Session["session"] = true;

                //Mostranto el boton logout
                divLogout.Attributes.Remove("hidden");
                //Ocultando el login
                divLogin.Attributes.Add("hidden", "hidden");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login approved')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login denied')", true);
            }
        }
        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string userEmail = txtemail2.Value;
                string userPassword = txtPwd2.Value;

                // Validación de entrada
                if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Por favor, complete todos los campos')", true);
                    return;
                }

                FirebaseUser newUser = new FirebaseUser()
                {
                    email = userEmail,
                    password = userPassword,
                };

                Class1 loginController = new Class1();

                if (loginController.RegisterUserInFirebase(newUser))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro fallido')", true);
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Error durante el registro: {ex.Message}')", true);
            }
        }
        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            //Mostrando el login
            divLogin.Attributes.Remove("hidden");
            //Ocultando el boton logout
            divLogout.Attributes.Add("hidden", "hidden");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session has been closed')", true);
            Session.Clear();
        }
    }
}