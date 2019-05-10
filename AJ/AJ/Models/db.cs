using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJ.Models
{
    public class db
    {
       public List<Grupo> grupos = new List<Grupo>();
      public  List<Subgrupo> subgrupos = new List<Subgrupo>();

        public db()
        {
            Grupo g = new Grupo();
            g.id = 1;g.nome = "Todos";

            grupos.Add(g);
            Subgrupo s = new Subgrupo();
            s.id = 1;
            s.groupid = 1;
            s.name = "Todos";
            subgrupos.Add(s);


        }

    }
}