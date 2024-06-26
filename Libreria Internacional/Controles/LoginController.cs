﻿using Libreria_Internacional.Modelos;
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
    public class LoginController
    {
        public bool FirebaseAuth(FirebaseUser user)
        { //admin123
            string url = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBGLGFLoBlN3JysRjgdZzIyFnaIWp9ouTA";
            string body = "{'email':'" + user.email + "','password':'" + user.password + "','returnSecureToken':true}";

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

                    return payload.registered;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}