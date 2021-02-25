using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PListaDinSimEnc
{
    class FileManipulator
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }


        public void InitializeFile(List<Pessoa> contactList)
        {
            if (!File.Exists($@"{FilePath}\{FileName}.{FileExtension}"))
            {
                using (StreamWriter streamWriter = File.CreateText($@"{FilePath}\{FileName}.{FileExtension}"))
                {
                    streamWriter.WriteLine("Nome,DDD,Numero,Tipo");
                }
            }
            else
            {
                String[] contactFile = File.ReadAllLines($@"{FilePath}\{FileName}.{FileExtension}");
                Boolean isHeader = true;
                if (contactFile.Length > 1)
                foreach (var contact in contactFile)
                {
                    if (!isHeader)
                    {

                        String[] atributes = contact.Split(',');
                        Pessoa pessoa = new Pessoa
                        {
                            Nome = atributes[0],
                            telefone = new Telefone
                            {
                                DDD = int.Parse(atributes[1]),
                                Numero = int.Parse(atributes[2]),
                                Tipo = atributes[3]
                            }
                        };
                        contactList.Add(pessoa);
                    }
                    isHeader = false;
                }
            }
        }

        public void WriteInFile(List<Pessoa> listaContato)
        {
            using (StreamWriter streamWriter = File.CreateText($@"{FilePath}\{FileName}.{FileExtension}"))
            {
                streamWriter.WriteLine("Nome,DDD,Numero,Tipo");
                listaContato.ForEach(contato => streamWriter.WriteLine(contato.ToCsvConverter()));
            }
        }
        public void WriteInFile(Pessoa contato)
        {
            using (StreamWriter streamWriter = File.AppendText($@"{FilePath}\{FileName}.{FileExtension}"))
            {
                streamWriter.WriteLine(contato.ToCsvConverter());
            }
        }
    }
}
