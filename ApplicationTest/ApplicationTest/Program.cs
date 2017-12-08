using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest

{
    class Program
    {
        static void Main(string[] args)
        {
            //Déclaration des variables 
            string _nombre;
            int nombre;
            char[] tabNombre;
            _nombre = Console.ReadLine();

            //Saisie et validation du nombre à traiter
            while (!int.TryParse(_nombre, out nombre))
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
                _nombre = Console.ReadLine();
            }

            //Conversion du nombre en un tableau de char
            tabNombre = new char[_nombre.Length];
            for (int j = 0; j < tabNombre.Length; j++)
            {
                tabNombre[j] = _nombre[tabNombre.Length - 1 - j];
            }           
            
            bool resolu = false;
            int i;
            for (i = 1; i < tabNombre.Length && !resolu; i++)
            {
                int indexe = IndicePlusPetitElement(tabNombre, i);
                if (tabNombre[i] < tabNombre[indexe])
                {
                    char temp = tabNombre[i];
                    tabNombre[i] = tabNombre[indexe];
                    tabNombre[indexe] = temp;
                    resolu = true;
                }
            }
            if (resolu)
            {
                for (int k = 0; k < i - 2; k++)
                {
                    for (int j = k; j < i - 1; j++)
                    {
                        if (tabNombre[j] > tabNombre[k])
                        {
                            char temp = tabNombre[j];
                            tabNombre[j] = tabNombre[k];
                            tabNombre[k] = temp;
                        }
                    }
                }
            }

            StringBuilder str = new StringBuilder();
            for (int j = 0; j < tabNombre.Length; j++)
            {
                str.Append(tabNombre[tabNombre.Length - j - 1]);
            }

            Console.WriteLine("Le nombre supérieur suivant avec les mêmes chiffres est : "+str);
            Console.ReadKey();
        }

        //Méthode qui prend en paramètres un tableau et le nombre des premiers éléments à traité
        //La méthode retourne l'indice du plus petit élément supérieur au seuil (éléemt dont l'indice suit le dernier élément )
        private static int IndicePlusPetitElement(char[] tab, int nombreElts)
        {
            //
            char plusPetitElt = '9';
            int indice = 0;
            for (int i = 0; i < nombreElts; i++)
            {
                if (tab[i] > tab[nombreElts])
                {
                    if (tab[i] < plusPetitElt)
                    {
                        plusPetitElt = tab[i];
                        indice = i;
                    }
                }
            }
            return indice;
        }
    }
}
