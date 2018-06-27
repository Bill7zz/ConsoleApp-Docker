using System;
using System.IO;
using System.Net;


namespace swTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiUrl = "http://loripsum.net/api/1/short/prude";
            var sampleText = GetTextFromApiLorem(apiUrl);

            Console.WriteLine("Loren text from web API - loripsum.net ");
            Console.WriteLine(sampleText);
        }

        private static string GetTextFromApiLorem(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            var reader = new StreamReader(dataStream);
            var textFromApi = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return textFromApi;
        }

    }
}
