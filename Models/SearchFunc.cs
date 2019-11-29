using System;
using System.Collections.Generic;

using System.Linq;


namespace MedicalHerbs.Models
{
    class SearchFunc
    {
        public static List<string> GetSearchResults(string queryString, List<String> listOfSearch)
        {
            //var normalizedQuery = queryString?.ToLower() ?? "";
            return listOfSearch.Where(f => f.ToLowerInvariant().Contains(queryString)).ToList();
        }

        public static List<Disease> GetSearchStringInListDiseases(string queryString, List<Disease> listOfSearch)
        {
            List<Disease> listReturn = new List<Disease>();
            foreach (Disease d in listOfSearch)
            {
                if (d.Name.ToLowerInvariant().Contains(queryString))
                {
                    listReturn.Add(d);
                }
            }
            return listReturn;
        }
    }
}
