using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string Commande;
            Directory C = new Directory("/", null);
            string[] TabCommande;
            File fileCurrent = C;
            bool quitter = false;

            while(quitter == false)
            {
                Commande = Console.ReadLine();
                TabCommande = Commande.Split(' ');

                if (TabCommande[0] == "mkdir" && TabCommande.Count()==2)
                {
                    Console.WriteLine(fileCurrent.mkdir(TabCommande[1]));
                }

                if (TabCommande[0] == "create" && TabCommande.Count() == 2)
                {

                    Console.WriteLine(fileCurrent.createNewFile(TabCommande[1]));
                }


                if (TabCommande[0] == "ls" && TabCommande.Count() == 1)
                {
                    if (fileCurrent.ls() != null && fileCurrent.canRead() == true)
                    {
                        foreach (File item in fileCurrent.ls())
                        {
                            Console.WriteLine("Nom du Fichier   " + "   Type du Fichier " + "   Permission");
                            Console.WriteLine(item.Nom + "          ( " + item.GetType() + " ) " + item.Permission);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Vous n'avez pas le droit de lecture");
                    }
                }

                if (TabCommande[0] == "file" && TabCommande.Count() == 1)
                {
                    Console.WriteLine(fileCurrent.isFile());
                }

                if (TabCommande[0] == "directory" && TabCommande.Count() == 1)
                {
                    Console.WriteLine(fileCurrent.isDirectory());
                }

                if (TabCommande[0] == "delete" && TabCommande.Count() == 2)
                {
                    if (fileCurrent.canWrite() == true)
                    {
                        Console.WriteLine(fileCurrent.delete(TabCommande[1]));
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas les droits pour supprimer Fichier");
                    }
                }

                if (TabCommande[0] == "rename" && TabCommande.Count() == 3)
                {
                    if (fileCurrent.canWrite() == true)
                    {
                        Console.WriteLine(fileCurrent.renameTo(TabCommande[1], TabCommande[2]));
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez les droit pour renomer ce Fichier");
                    }
                }

                if (TabCommande[0] == "name" && TabCommande.Count() == 1)
                {
                    Console.WriteLine(fileCurrent.getName());
                }

                if (TabCommande[0] == "cd" && TabCommande.Count() == 2)
                {
                    fileCurrent=fileCurrent.cd(TabCommande[1]);
                }

                if (TabCommande[0] == "parent" && TabCommande.Count() == 1 && fileCurrent != C)
                {
                    fileCurrent = fileCurrent.getParent();
                    Console.WriteLine("Vous êtes revenus dans le dossier : " + fileCurrent.Nom);
                }

                if (TabCommande[0] == "path" && TabCommande.Count() == 1)
                {
                    Console.WriteLine("Le chemin du fichier courant est : " + fileCurrent.getPath());
                }

                if (TabCommande[0] == "chmod" && TabCommande.Count() == 2)
                {
                    
                    fileCurrent.chmod(TabCommande[1]);
                    
                }

                if (TabCommande[0] == "search")
                {
                    foreach (File item in fileCurrent.search(TabCommande[1]))
                    {
                        Console.WriteLine("Nom du fichier recherché : " +item.Nom + "\nRoute du fichier rechercé : " + item.getPath());
                    }
                }

                if (TabCommande[0] == "root" && TabCommande.Count() == 1)
                {
                    if (fileCurrent == C)
                    {
                        Console.WriteLine("C n'a pas de parent");
                    }
                    else
                    {
                        Console.WriteLine(fileCurrent.getRoot());
                    }
                }

                if(TabCommande[0] == "quit" && TabCommande.Count() == 1)
                {
                    quitter = true;
                }
            }
        }
    }
}
