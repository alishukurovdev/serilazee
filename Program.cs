using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace SerializeReparte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Add("Garib");
             Delete("Emil");
            Console.WriteLine(Search("Alik"));
        }
        public static void Add(string name)
        {
            string path = @"C:\Users\hp\source\repos\SerializeReparte\Files\tsconfig1.json";
            List<string> names = Deserialize(path);
            names.Add(name);

            Serialize<List<string>>(path,names);
           
        }
        public static List<string>Deserialize(string path) {
            string result;
           

            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            List<string>names=JsonConvert.DeserializeObject<List<string>>(result);
            return names;
                }
        public static void Serialize<T>(string path, T obj)
        {
            string result=JsonConvert.SerializeObject(obj);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(result);
            }
        }
        public static bool Search( string name)
        {
            string path = @"C:\Users\hp\source\repos\SerializeReparte\Files\tsconfig1.json";

            List<string> names = Deserialize(path);
            return names.Contains(name);
        }
        public static void Delete(string name)
        {
            string path = @"C:\Users\hp\source\repos\SerializeReparte\Files\tsconfig1.json";
            List<string> names = Deserialize(path);
            if (names.Contains(name))
            {
                names.Remove(name);
                Serialize<List<string>>(path, names);
                Console.WriteLine($"{name} sildim.");
            }
            else
            {
                Console.WriteLine($"{name} yoxdu bazada.");
            }
        }



    }
}
