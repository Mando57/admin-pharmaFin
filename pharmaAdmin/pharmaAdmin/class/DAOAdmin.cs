using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace pharmaAdmin
{
    class DAOAdmin
    {
        private MySqlConnection conn;
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=pharma;";
        public string test;
        public DAOAdmin()
        {
            
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        public bool conecAdmin(string mdp,string login)
        {
            string req = "select count(*) from admin where login like '" +login+ "' and mdp='"+mdp+"'";
            MySqlCommand cmd = new MySqlCommand(req, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                if(Convert.ToInt16(rdr[0].ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        public DataSet GetAllDemandesInDataSet()
        {
            DataSet dataSet1;
            string req = "select * from demande";
            //on crée un  dataset associé à cette connexion
            dataSet1 = new DataSet(myConnectionString);
            dataSet1.Tables.Clear();
            //on prépare la commande (texte de la requete passée en paramètre, connection)
            MySqlCommand requete = new MySqlCommand(req, conn);
            //on réceptionne le résultat dans le dataset
            MySqlDataAdapter resultat;
            resultat = new MySqlDataAdapter(requete);
            resultat.Fill(dataSet1);

            return dataSet1;
        }

        public void insertDemande(Demande d)
        {
            string dt = (d.Date.Substring(0, 10));
            DateTime dateValue = DateTime.Parse(dt);
            dt = dateValue.ToString("yyyy-MM-dd");
           

            
            string req = "INSERT INTO `pharma`.`demande` (`date`, `debut`, `fin`, `remarque`, `status`, `remarqueGSB`, `idProd`, `idPharma`, `idDemande`) VALUES ('"+dt+ "', '" + d.Debut + "', '" + d.Fin + "' , '" + d.Remarque + "' , '" + d.Status + "', '" + d.RemarqueGSB + "', " + d.IdProd + "," + d.IdPharma + "," + d.IdDemande + ")";
            test = req;
            MySqlCommand myCommand = new MySqlCommand(req);
            myCommand.Connection = conn;
            myCommand.ExecuteNonQuery();
            refuserDemande(d.IdDemande, "contre offre");
        }        
        
        public void refuserDemande(int i, string s)
        {
            string upd = "call p_refuserD("+i+",'"+s+"')";
            MySqlCommand myCommand = new MySqlCommand(upd);
            myCommand.Connection = conn;
            myCommand.ExecuteNonQuery();
        }
        public void accepterDemande(int i,string s,int d)
        {
            string upd = "call p_accepterD(" + i + ",'" + s + "')";
            MySqlCommand myCommand = new MySqlCommand(upd);
            myCommand.Connection = conn;
            myCommand.ExecuteNonQuery();
        }


    }

   
}
