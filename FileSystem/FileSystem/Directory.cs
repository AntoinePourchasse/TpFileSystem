using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Directory : File
    {
        List<File> files = new List<File> ();
        List<File> lesfichiers = new List<File>();


        public Directory(string Nom, Directory parent): base (Nom, parent)
        {
            Permission = 4; 
        }

        public override bool createNewFile(string name)
        {
            bool exist = false;

            for (int i = 0; i < files.Count() && exist == false; i++)
            {
                exist = name == files[i].Nom;
            }

            if (this.canWrite() && exist == false)
            {
                files.Add(new File(name, this));
                Console.WriteLine("Vous venez de créer le fichier : " + name);
                return true;
            }
            Console.WriteLine("Vous ne pouvez pas créer de fichier car vous n'avez pas les droits.");
            return false;
        }

        public override bool mkdir(string name)
        {
            bool exist = false;

            for (int i = 0; i < files.Count() && exist == false; i++)
            {
                exist = name == files[i].Nom;
            }

            if (this.canWrite() && exist == false)
            {
                files.Add(new Directory(name, this));
                Console.WriteLine("Vous venez de créer le dossier : " + name);
                return true;
            }
            Console.WriteLine("Vous ne pouvez pas créer de dossier car vous n'avez pas les droits");
            return false;
        }

        public override List<File> ls()
        {
            return this.files;
        }

        public override bool isFile()
        {
            return false;
        }

        public override bool isDirectory()
        {
            return true;
        }

        public override bool delete(string name)
        {
            int i = 0;
            bool exist = false;

            while (i < files.Count() && exist == false)
            {
                exist = name == files[i].Nom;
                i++;
            }
            
            if (this.canWrite() && exist == true)
            {
                files.Remove(files[i-1]);
                return true;
            }
            return false;
        }

        public override bool renameTo(string name,string newName)
        {
            int i = 0;
            bool exist = false;

            //cherche si le dossier ou le fichier existe
            while (i < files.Count() && exist == false)
            {
                exist = name == files[i].Nom;
                i++;
            }

            if (this.canWrite() && exist == true)
            {
                exist = false;
                //cherche si le nom que l'on veut donner n'existe pas dans le même dossier courant
                for (int j = 0; j < files.Count() && exist == false; j++ )
                {
                    exist = newName == files[j].Nom;
                    
                }
                if (this.canWrite() && exist == false)
                {
                    files[i - 1].Nom = newName;
                    return true;
                }
            }
            return false;
        }

        public override File cd(string name)
        {
            File newFileCurrent = null;
            bool deplace = false;
            for (int i = 0; deplace == false && i < files.Count(); i++)
            {
                if (files[i].Nom == name && files[i].canRead() && deplace == false)
                {
                    newFileCurrent = files[i];
                    Console.WriteLine("Vous êtes maintenant dans le Ficher : " + name);
                    deplace = true;
                }
            }
            return newFileCurrent;
        }

        public override List<File> search(string name)
        {
            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i].Nom == name)
                {
                    lesfichiers.Add(files[i]);
                }

                if (files[i].isDirectory() == true)
                {
                    lesfichiers.AddRange(files[i].search(name));
                    
                }
            }

            return lesfichiers;
        }

    }
}
