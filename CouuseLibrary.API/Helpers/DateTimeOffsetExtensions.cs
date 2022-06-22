using System;

namespace CouuseLibrary.API.Helpers
{
    // Classe statica pois contera um metodo de extensao 
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffSet)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTimeOffSet.Year;

            if(currentDate < dateTimeOffSet.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
