using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sukupuut
{
    [DataContract(Name = "Henkilö", Namespace = "http://www.contoso.com")]
    public class Henkilö
    {                       
        string etunimi;       
        string sukunimi;
        string patronyymi;
        
        DateTime syntymäaika;
        DateTime kuolinaika;
        string syntymäpaikka;

        int isä_index = -1;
        int äiti_index = -1;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(etunimi);
            sb.Append(" ");
            sb.Append(sukunimi);
            sb.Append(" \ns.");
            sb.Append(syntymäaika.Year);            

            return sb.ToString();
        }

        public Henkilö(String etunimi, String sukunimi)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            
        }

        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="toinen"></param>
        /// <returns>true if match</returns>
        public bool isSame(Henkilö toinen)
        {
            if (Etunimi.CompareTo(toinen.Etunimi) == 0 &&
                Sukunimi.CompareTo(toinen.Sukunimi) == 0 &&
                Syntymäaika.CompareTo(toinen.Syntymäaika) == 0) { 
                return true;
            }
            return false;
        }

        [DataMember]
        public int Isä
        {
            get
            {
                return isä_index;
            }

            set
            {
                isä_index = value;
            }
        }
        [DataMember]
        public int Äiti
        {
            get
            {
                return äiti_index;
            }

            set
            {
                äiti_index = value;
            }
        }

        [DataMember]
        public string Etunimi
        {
            get
            {
                return etunimi;
            }

            set
            {
                etunimi = value;
            }
        }
        [DataMember]
        public string Sukunimi
        {
            get
            {
                return sukunimi;
            }

            set
            {
                sukunimi = value;
            }
        }

        public string Patronyymi
        {
            get
            {
                return patronyymi;
            }

            set
            {
                patronyymi = value;
            }
        }

        [DataMember]
        public DateTime Syntymäaika
        {
            get
            {
                return syntymäaika;
            }

            set
            {
                syntymäaika = value;
            }
        }

        public DateTime Kuolinaika
        {
            get
            {
                return kuolinaika;
            }

            set
            {
                kuolinaika = value;
            }
        }

        public string Syntymäpaikka
        {
            get
            {
                return syntymäpaikka;
            }

            set
            {
                syntymäpaikka = value;
            }
        }
    }

    /*
     class TreeNode<T>
{
    List<TreeNode<T>> Children;

    T Item {get;set;}

    public TreeNode (T item)
    {
        Item = item;
    }

    public TreeNode<T> AddChild(T item)
    {
        TreeNode<T> nodeItem = new TreeNode<T>(item);
        Children.Add(nodeItem);
        return nodeItem;
    }
}
     */
     
}
