using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmaAdmin
{
    class Animateur
    {
        private int id;
        private string nom;
        
        public Animateur(int i,string n)
        {
            Id = i;
            Nom = n;
        }
        public Animateur()
            {

        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }
    }
}
