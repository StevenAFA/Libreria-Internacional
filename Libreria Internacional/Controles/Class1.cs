
using Libreria_Internacional.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Libreria_Internacional.Controles
{
    public class Class1
    {
        private const string FirebaseApiKey = "AIzaSyBGLGFLoBlN3JysRjgdZzIyFnaIWp9ouTA";

        public bool RegisterUserInFirebase(FirebaseUser user)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyBGLGFLoBlN3JysRjgdZzIyFnaIWp9ouTA";
            string body = $"{{'email':'{user.email}','password':'{user.password}','returnSecureToken':true}}";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(Encoding.UTF8.GetBytes(body), 0, Encoding.UTF8.GetBytes(body).Length);
            }

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    FirebaseUser payload = JsonConvert.DeserializeObject<FirebaseUser>(reader.ReadToEnd());

                    // Validar si la respuesta fue exitosa y si contiene un ID de usuario
                    return !string.IsNullOrEmpty(payload.localId);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}