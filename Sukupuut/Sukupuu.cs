using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sukupuut
{
    public class Sukupuu
    {
        List<Henkilö> jäsenet = new List<Henkilö>();

        private static Sukupuu mInstance;

        private Sukupuu()
        {

        }

        public static Sukupuu getInstance()
        {
            if (mInstance == null)
            {
                mInstance = new Sukupuu();
            }
            return mInstance;
        }

        public void Add(Henkilö henkilö)
        {
            jäsenet.Add(henkilö);
        }

        public List<Henkilö> GetAll()
        {
            return jäsenet;
        }
    }
}
