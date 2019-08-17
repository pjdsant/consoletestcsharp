using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        public static string IntToAlpha(int x)
        {
            int lowChar;
            StringBuilder result = new StringBuilder();
            do
            {
                lowChar = (x - 1) % 26;
                x = (x - 1) / 26;
                result.Insert(0, (char)(lowChar + 65));
            } while (x > 0);
            return result.ToString();
        }



        static void Main(string[] args)
        {

            var strDomain = ".com.br";

            var jx = 0;

            var result = "";

            StreamWriter writer = new StreamWriter(@"C:\repositorios\verifydomainregistrobr\Dominos.txt");

            for (int i = 16975; i <= 99999; i++)  //defina aqui o tamanho da sequencia gerada
            {
                //Console.Write(i);
                //Console.Clear();
                jx = i;
                WebRequest request = WebRequest.Create("https://rdap.registro.br/domain/" + IntToAlpha(i) + strDomain);

                HttpWebResponse response = null;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    if (response == null)
                    {
                        writer.WriteLine(IntToAlpha(i) + "[" + i + "] = 404"); //+ response.StatusCode);
                        Console.WriteLine(i);
                        Console.WriteLine(IntToAlpha(i) + " = 404 ");//+ response.StatusCode);
                    }
                    else
                    {
                        response.Close();
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(IntToAlpha(i) + "[" + i + "] = 404"); //+ response.StatusCode);
                    Console.WriteLine(i);
                    Console.WriteLine(IntToAlpha(i) + " = 404 ");//+ response.StatusCode);
                   // result = "404";
                }
                
               

                // Console.WriteLine(IntToAlpha(i));

                //writer.WriteLine(IntToAlpha(i) + "[" + i + "] = " + response.StatusCode);

            }

            //Fechando o arquivo
            writer.Close();

            //Limpando a referencia dele da memória
            writer.Dispose();

            Console.WriteLine("End Line " + jx);
            Console.ReadKey();
        }
    }
}