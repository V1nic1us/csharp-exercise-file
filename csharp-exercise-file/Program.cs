using System;
using System.IO;
using csharp_exercise_file.Entities;

namespace csharp_exercise_file
{
    class Program
    {
        static void Main(string[] agrs)
        {
            try
            {
                List<Product> products = [];
                string caminhoDaPasta = @"C:\Users\viniv\source\repos\csharp-exercise-file\csharp-exercise-file\output";
                string caminhoDoArquivo = @"C:\Users\viniv\source\repos\csharp-exercise-file\csharp-exercise-file\output\summary.csv";
                using var sourceFile = new StreamReader(@"C:\Users\viniv\source\repos\csharp-exercise-file\csharp-exercise-file\Products.csv");
                while (!sourceFile.EndOfStream)
                {
                    string line = sourceFile.ReadLine();
                    string[] fields = line.Split(",");
                    string name = fields[0];
                    double price = double.Parse(fields[1]);
                    products.Add(new Product(name, price));
                }
                if (Directory.Exists(caminhoDaPasta))
                {
                    using var outputFile = new StreamWriter(caminhoDoArquivo);
                    foreach (Product product in products)
                    {
                        outputFile.WriteLine(product.Name + "," + product.Price);
                    }
                }
                else
                {
                    Directory.CreateDirectory(caminhoDaPasta);
                    using var outputFile = new StreamWriter(caminhoDoArquivo);
                    foreach (Product product in products)
                    {
                        outputFile.WriteLine(product.Name + "," + product.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}