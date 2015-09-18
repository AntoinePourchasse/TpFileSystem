using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class File
    {
        public String Nom;
        public int Permission;
        public Directory Parent;

        public File(string Nom, Directory parent)
        {
            this.Nom = Nom;
            this.Parent = parent;
            this.Permission = 4;
        }

        public bool canWrite()
        {
            return (Permission & 2) > 0;

        }

        public bool canExecute()
        {
            return (Permission & 1) > 0;

        }

        public bool canRead()
        {
            return (Permission & 4) > 0;

        }

        public virtual bool createNewFile(string name)
        {
            Console.WriteLine("Vous ne pouvez pas créer de fichier dans un fichier");
            return false;
        }

        public virtual bool mkdir(string name)
        {
            Console.WriteLine("Vous ne pouvez pas créer de dossier dans un fichier");
            return false;
        }

        public virtual List<File> ls()
        {
            Console.WriteLine("Vous etes sur le fichier : " + this.Nom);
            return null;
        }

        public string getName()
        {
            return this.Nom;
        }

        public virtual bool isFile()
        {
            return true;
        }

        public virtual bool isDirectory()
        {
            return false;
        }

        public virtual bool delete(string name)
        {
            return false;
        }

        public virtual bool renameTo(string name ,string newName)
        {
            return false;
        }

        public virtual File cd(string name)
        {
            return null;
        }

        public File getParent()
        {
            return Parent;
        }

        public string getPath()
        {
            Directory parents = Parent;
            string path = Nom;
            while (parents != null)
            {

                path = parents.Nom + "/" + path;
                parents = parents.Parent;
            }
            
            return path;
        }

        public void chmod(string permission)
        {
            if (int.Parse(permission) > 0 && int.Parse(permission) <= 7)
            {
                this.Permission = int.Parse(permission);
            }
            else
            {
                Console.WriteLine("Veuillez entrer un chiffre entre 1 et 7");
            }
        }

        public virtual List<File> search(string name)
        {
            return null;
        }

        public string getRoot()
        {
            
            return Parent.Nom;
        }
    }
}
