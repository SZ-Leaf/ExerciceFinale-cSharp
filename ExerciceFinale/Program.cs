using System;
using System.Collections.Generic;
using Vehicules;
using System.Linq;
using System.Text.Json;
using System.IO;


namespace FinalExercice
{
    class Program
    {
        static void Main()
        {
            List<Vehicule> listeVehicules = new List<Vehicule>();

            Vehicule[] originalList = new Vehicule[5];
            originalList[0] = new Voiture("SS", "Tesla", 5555, 550);
            originalList[1] = new Voiture("e320", "Mercedes", 505050, 460);
            originalList[2] = new Voiture("M4", "BWM", 404040, 400);
            originalList[3] = new Camion("P-310", "Scania", 3535, 4850);
            originalList[4] = new Camion("P-310", "Scania", 3540, 4850);

            listeVehicules.AddRange(originalList);

            while (true)
            {
                Console.WriteLine("Bienvenue, quelle action ?\n" +
                "1 - Crée Vehicule\n" +
                "2 - Voir un marque de Vehicules\n" +
                "3 - Supprimer un Vehicule\n" +
                "4 - Mettre a jour un Vehicule\n" +
                "5 - Trier les Vehicules\n" +
                "6 - Filtrer les Vehicules\n" +
                "7 - Sauvegarder les Vehicules\n" +
                "0 - Exit the program");

                Console.WriteLine("Entrer la valeur: ");
                int picker;
                string? input = Console.ReadLine();

                try
                {
                    if (input == "0")
                    {
                        Console.WriteLine("Goodbye!");
                        return;
                    }
                    else if (!int.TryParse(input, out picker) || picker < 1 || picker > 7)
                    {
                        Console.WriteLine("Input must be between 1 and 7.");
                        continue;
                    }

                    Console.WriteLine("You entered: " + picker);

                    switch (picker)
                    {
                        case 1:
                            // Call GetVehicleDetails to create a new vehicle
                            (string marque, string modele, int numero, int pp, char vehiculeType) = GetVehicleDetails();

                            if (listeVehicules.Any(v => v.Numero == numero))
                            {
                                Console.WriteLine($"Vehicule with numero {numero} already exists. Please enter a unique numero.");
                                break;
                            }

                            // Based on the type of vehicle, create an instance and add it to the list
                            if (vehiculeType == 'v')
                            {
                                Voiture v1 = new Voiture(modele, marque, numero, pp);
                                listeVehicules.Add(v1);
                            }
                            else if ((vehiculeType == 'c'))
                            {
                                Camion c1 = new Camion(modele, marque, numero, pp);
                                listeVehicules.Add(c1);
                            }
                            break;

                        case 2:
                            string marqueToView = Prompts.PromptForString("Enter the Marque you want to view:");
                            List<Vehicule> vehiculeToView = listeVehicules.Where(v => v.Marque == marqueToView).ToList();
                            if (vehiculeToView.Count == 0)
                            {
                                Console.WriteLine("No vehicles found with the specified marque.");
                            }
                            else
                            {
                                // Display the details of the vehicles found
                                Console.WriteLine($"Vehicles de la marque '{marqueToView}':");
                                foreach (var vehicle in vehiculeToView)
                                {
                                    Console.WriteLine(vehicle);
                                }
                            }
                            break;

                        case 3:
                            int numeroToDelete = Prompts.PrompForNumero("Enter the numero for vehicule to delete: ");
                            var vehiculeToDelete = listeVehicules.FirstOrDefault(v => v.Numero == numeroToDelete);

                            if (vehiculeToDelete != null)
                            {
                                listeVehicules.Remove(vehiculeToDelete);
                                Console.WriteLine($"Vehicle with numero {numeroToDelete} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"No vehicle found with numero {numeroToDelete}.");
                            }
                            break;


                        case 4:
                            int numeroToModify = Prompts.PrompForNumero("Enter the numero for vehicule to modify: ");
                            var vehiculeToModify = listeVehicules.FirstOrDefault(v => v.Numero == numeroToModify);

                            if (vehiculeToModify != null)
                            {
                                Console.WriteLine($"Vehicule has been found: {vehiculeToModify}");

                                vehiculeToModify.Modele = Prompts.PromptForString("Enter the new Model name: ");

                                if (vehiculeToModify is Voiture)
                                {
                                    Voiture voiture = (Voiture)vehiculeToModify;
                                    voiture.Puissance = Prompts.PromptForPuissance("Enter the new puissance: ");
                                }
                                else if (vehiculeToModify is Camion)
                                {
                                    Camion camion = (Camion)vehiculeToModify;
                                    camion.Poids = Prompts.PromptForPuissance("Enter the new poids: ");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"No vehicle found with numero {numeroToModify}.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid option selected.");
                            break;

                        case 5:

                            break;

                        case 6:

                            break;

                        case 7:
                            SaveVehiclesToJson(listeVehicules);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

        }
        
        static (string, string, int, int, char) GetVehicleDetails()
        {
            string marque = Prompts.PromptForString("Enter the Marque: ");
            string modele = Prompts.PromptForString("Enter the Modele: ");
            int numero = Prompts.PrompForNumero("Enter the Numero (between 4 and 6 characters): ");
            char vehiculeType = Prompts.PromptForType("Enter 'v' for Voiture or 'c' for Camion: ");
            int pp = (vehiculeType == 'c') ? 
                Prompts.PromptForPuissance("Enter the puissance: ") 
                : 
                Prompts.PromptForPuissance("Enter the poids (numbers only): ");

            return (marque, modele, numero, pp, vehiculeType);
        }
        static void SaveVehiclesToJson(List<Vehicule> vehicles)
        {
            string json = JsonSerializer.Serialize(vehicles);
            File.WriteAllText("vehicules.json", json);
            Console.WriteLine("Vehicles saved to vehicules.json.");
        }
    }
}