using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmaAdmin
{
    class Demande
    {
        private int id;
        private string date;
        private string debut;
        private string fin;
        private string remarque;
        private string status;
        private string remarqueGSB;
        private int idProd;
        private int idPharma;
        private int idDemande;

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

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Debut
        {
            get
            {
                return debut;
            }

            set
            {
                debut = value;
            }
        }

        public string Fin
        {
            get
            {
                return fin;
            }

            set
            {
                fin = value;
            }
        }

        public string Remarque
        {
            get
            {
                return remarque;
            }

            set
            {
                remarque = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string RemarqueGSB
        {
            get
            {
                return remarqueGSB;
            }

            set
            {
                remarqueGSB = value;
            }
        }

        public int IdProd
        {
            get
            {
                return idProd;
            }

            set
            {
                idProd = value;
            }
        }

        public int IdPharma
        {
            get
            {
                return idPharma;
            }

            set
            {
                idPharma = value;
            }
        }

        public int IdDemande
        {
            get
            {
                return idDemande;
            }

            set
            {
                idDemande = value;
            }
        }

        public Demande(int i,string d,string de,string f,string r,string s,string gsb,int prod,int pharma,int dem)
        {
            Id = i;
            Date = d;
            Debut = de;
            Fin = f;
            Remarque = r;
            Status = s;
            RemarqueGSB = gsb;
            IdProd = prod;
            IdPharma = pharma;
            IdDemande = dem;
        }
    }
}
