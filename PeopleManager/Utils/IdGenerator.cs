using System;

namespace PeopleManager.Utils
{
    public class IdGenerator
    {
        private static int count = 1;

        public static string GenerateId()
        {
            int currentYear = DateTime.Now.Year;
            string incrementString = count.ToString("D2");
            string id = $"{currentYear}{incrementString}";
            count++;
            return id;
        }
    }
}
