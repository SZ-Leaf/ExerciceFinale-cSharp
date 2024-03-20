using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    public class Camion : Vehicule
    {
        public int Poids { get; set; }
        public Camion(string modele, string marque, int numero, int poids) : base(modele, marque, numero)
        {
            //this.Modele = modele;
            //this.Marque = marque;
            //this.Numero = numero;
            this.Poids = poids;
        }

        public override string ToString()
        {
            return base.ToString() + $", Poids: {Poids}";
        }
    }
}
