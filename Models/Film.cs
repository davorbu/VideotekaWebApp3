using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideotekaWebApp3.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string Naslov { get; set; }

        public string Zanr { get; set; }

        public DateTime Godina { get; set; }

        
        public List<Film>DohvatiFilmove(int count)
        {
            List<Film>filmovi = new List<Film>();
            Random random = new Random();

            for(int i = 0; i < count; i++)
            {
                filmovi.Add(
                    new Film
                    {
                        Godina = DateTime.Now.AddYears((random.Next(1,5)) * -1),
                        Id = i,
                        Naslov = "Naslov" + random.Next(i, 50),
                        Zanr = "Zanr" + random.Next(i, 50)


                    });

            }
            return filmovi;
        }


    }



    


}