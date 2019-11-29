using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MedicalHerbs.Models
{
    class FilesData
    {



        //функция ReaderFileInList - возвращет список считанных строк из ресурса ResName
        public static List<string> ReaderFileInList(string ResName, bool sort = true)
        {
            List<string> listReturns = new List<string>() { }; //возвращаемый список
            string text;                                       // текст считанный из файла
            string[] arr;                                      //строковый массив для разбивки на строки

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FilesData)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(ResName);

            using (var streader = new StreamReader(stream))
            {
                text = streader.ReadToEnd();           //считвыем весь текст в переменную text          
                arr = text.Split(new char[] { '\n' }); //разбиваем по строкам
                foreach (string str in arr)
                {
                    listReturns.Add(str);              //добавляем в список каждую строку
                }

            }
            stream.Close();

            if (sort) { listReturns.Sort(); }          //сортировка списка

            return listReturns;

        }



        public static string ReaderFiletoText(string ResName)
        {
            string text;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FilesData)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(ResName);

            using (var streader = new StreamReader(stream))
            {
                text = streader.ReadToEnd();           //считвыем весь текст в переменную text                         
            }
            stream.Close();
            return text;
        }




    }










}
