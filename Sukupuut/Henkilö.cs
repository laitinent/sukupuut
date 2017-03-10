using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sukupuut
{
    public class Henkilö
    {
        Henkilö isä;
        Henkilö äiti;
        string etunimi;
        string sukunimi;
        string patronyymi;
        DateTime syntymäaika;
        DateTime kuolinaika;
        string syntymäpaikka;

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
            isä = null;
            äiti = null;
        }

        public Henkilö Isä
        {
            get
            {
                return isä;
            }

            set
            {
                isä = value;
            }
        }

        public Henkilö Äiti
        {
            get
            {
                return äiti;
            }

            set
            {
                äiti = value;
            }
        }

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
