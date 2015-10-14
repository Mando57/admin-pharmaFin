using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace pharmaAdmin
{
    class DAOAnim
{
        private MySqlConnection conn;
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=pharma;";

        public DAOAnim()
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        public bool conecAdmin(string mdp, string login)
        {
            string req = "select count(*) from admin where login like '" + login + "' and mdp='" + mdp + "'";
            MySqlCommand cmd = new MySqlCommand(req, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (Convert.ToInt16(rdr[0].ToString()) == 1)
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
        public List<Animateur> getAllAnim()
        {
            List<Animateur> lreturn = new List<Animateur>();
            string req = "select * from animateur";
            MySqlCommand cmd = new MySqlCommand(req, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Animateur a = new Animateur();
                a.Id =Convert.ToInt16(rdr[0].ToString());
                a.Nom = rdr[1].ToString();
                lreturn.Add(a);

            }
            rdr.Close();

            return lreturn;
        }
        public DataSet getAllanim2()
        {
            DataSet dataSet1 = new DataSet(myConnectionString);
            dataSet1.Tables.Clear();
            string req = "select * from animateur";

            //on prépare la commande (texte de la requete passée en paramètre, connection)
            MySqlCommand requete = new MySqlCommand(req, conn);
            //on réceptionne le résultat dans le dataset
            MySqlDataAdapter resultat = new MySqlDataAdapter(requete);
            resultat.Fill(dataSet1);

            return dataSet1;

        }

    }
    
}
/*
public void ChargerCombo(string req)
{
    OuvrirConnection();
    //on crée un dataset associé à cette connexion
    DataSet dataSet1 = new DataSet(myConnectionString);
    dataSet1.Tables.Clear();
    //on prépare la commande (texte de la requete passée en paramètre, connection)
    MySqlCommand requete = new MySqlCommand(req, connect);
    //on réceptionne le résultat dans le dataset
    MySqlDataAdapter resultat = new MySqlDataAdapter(requete);
    resultat.Fill(dataSet1);
    // on associe dataset et datagrid
    comboBox1.DataSource = dataSet1.Tables[0];
    comboBox1.ValueMember = "numerotriathlon";
    comboBox1.DisplayMember = "nomtriathlon";

    //on se déconnecte  connect.close()
    FermerConnection();
}*/
