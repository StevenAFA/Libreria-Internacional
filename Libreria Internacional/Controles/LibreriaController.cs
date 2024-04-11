using Libreria_Internacional.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria_Internacional.Controles
{
    public class LibreriaController
    {
        public List<Libreria> GetLibrerias()
        {
            List<Libreria> libreriaLista = new List<Libreria>();

            Libreria libreria = new Libreria()
            {
                ISBN = 1,
                nombreLibro = "Hola Mundo",
                autorLibro = "Steven and Brian",
                Foto = "../Assets/Imagenes/1.jpg",
                Precio = 2820
            };
            Libreria libreria2 = new Libreria()
            {
                ISBN = 2,
                nombreLibro = "Hola Mundo#2",
                autorLibro = "Steven and Brian#2",
                Foto = "../Assets/Imagenes/2.jpg",
                Precio = 2291
            };

            Libreria libreria3 = new Libreria()
            {
                ISBN = 3,
                nombreLibro = "Hola Mundo#3",
                autorLibro = "Steven and Brian#3",
                Foto = "../Assets/Imagenes/3.jpg",
                Precio = 2291
            };

            libreriaLista.Add(libreria);
            libreriaLista.Add(libreria2);
            libreriaLista.Add(libreria3);

            return libreriaLista;
        }
            public List<Libreria> GetLibreria(int isbn)
            {
                List<Libreria> tripList = GetLibrerias();

                foreach (Libreria trip in tripList)
                {
                    if (trip.ISBN == isbn)
                    {
                        tripList.Clear();
                        tripList.Add(trip);
                        return tripList;
                    }
                }

                return null;
            }
        
    }
}