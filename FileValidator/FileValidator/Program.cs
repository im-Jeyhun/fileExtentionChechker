using System;

namespace FileValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileValidador fileValidador = new FileValidador(".pdf", ".docx", ".html", ".jpg");

        Return1:
            Console.Write("PLS INSERT FILE WITH EXTENTION : ");
            string targetFileName = Console.ReadLine();
            Console.WriteLine(fileValidador.IsExtentionvalid(targetFileName));
            Console.WriteLine("____________________________________________");
            Console.WriteLine("");
            if (fileValidador.IsExtentionvalid(targetFileName) == true)
            {
            Return2:
                Console.WriteLine("Whould you like to get extention of file ? press yes / no");
                string targetGetExtention = Console.ReadLine();
                if (targetGetExtention == "yes")
                {
                    Console.WriteLine($"Your file's extention is that {fileValidador.CheckExtentionOfText(targetFileName)}");
                    goto Return1;

                }
                else if (targetGetExtention == "no")
                {
                    goto Return1;
                }
                else
                {
                    Console.WriteLine("U can only choose yes / no !!");
                    goto Return2;
                }
            }
            else
            {
                Console.WriteLine(fileValidador.InfoAboutFiles());
                fileValidador.GetExtentions();

                Console.WriteLine("If u want to change info lang choose suitable one (Az,Tr,Fr) and insert it");
                string taregtLanguage = Console.ReadLine();
                Console.WriteLine(fileValidador.InfoAboutFiles(taregtLanguage));
                fileValidador.GetExtentions();
                goto Return1;

            }
        }
    }

    class FileValidador
    {
        private string[] _fileNames;

        private string _infoName;

        public FileValidador(params string[] filenames)
        {
            _fileNames = filenames;
        }

        public bool IsExtentionvalid(string text)
        {
            string newText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.')
                {
                    for (int k = i; k < text.Length; k++)
                    {
                        newText += text[k];
                    }
                }
            }
            foreach (string fileName in _fileNames)
            {
                if (fileName == newText)
                {
                    return true;
                }
            }
            return false;

        }

        public string InfoAboutFiles()
        {
            return "There are only these extensions in the system ";
        }

        public string InfoAboutFiles(string information)
        {
            if (information == "Az")
            {
                return "Sistemde movcud olan file tipleri bunlardir : ";
            }
            else if (information == "Tr")
            {
                return "Sistemde sadece bu uzantilar bulunmakda : ";
            }
            else if (information == "Fr")
            {
                return "Il n'y a que ces extensions dans le système : ";
            }
            return "Sorry we cant give you information in this language ....";
        }

        public string CheckExtentionOfText(string text)
        {
            string newText2 = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.')
                {
                    for (int k = i; k < text.Length; k++)
                    {
                        newText2 += text[k];
                    }
                }
            }
            return newText2;
        }

        public void GetExtentions()
        {
            foreach (string fileName in _fileNames)
            {
                Console.WriteLine(fileName);
            }

        }

    }
}
