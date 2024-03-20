using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules 
{
    public class Voiture : Vehicule
    {
        public int Puissance { get; set; }
        public Voiture(string modele, string marque, int numero, int puissance):base( modele,  marque,  numero)
        {
            //this.Modele = modele;
            //this.Marque = marque;
            //this.Numero = numero;
            this.Puissance = puissance;
        }

        public override string ToString()
        {
            return base.ToString() + $", Puissance: {Puissance}";
        }
    }
}
