namespace Vehicules
{
    public class Vehicule
    {
        public string? Modele { get; set; }
        public string? Marque { get; set; }
        public int? Numero { get; set; }

        public Vehicule(string modele, string marque, int numero)
        {
            this.Modele = modele;
            this.Marque = marque;
            this.Numero = numero;
        }

        public virtual string Afficher()
        {
            return $" Marque: {Marque}, Modele: {Modele}, Numer: {Numero}";
        }
        public override string ToString()
        {
            return Afficher();
        }
    }
}
