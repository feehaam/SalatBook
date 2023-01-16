using ApplicationLayer.DTO;
using System.Collections.Generic;
using System.Globalization;

namespace ApplicationLayer.Compression
{
    public class Hashing
    {
        private static List<int> hashList;

        public static int getHash(DailyDto day)
        { 
            int hash = 0;
            hash = hash * 10 + dateToNumber(day.Date);
            hash = hash * 10 + pairPoint(day.Fozor_foroj, day.Fozor_sunnat, day.Johor_foroj, day.Johor_sunnat);
            hash = hash * 10 + pairPoint(day.Asor_foroj, day.Asor_sunnat, day.Magrib_foroj, day.Magrib_sunnat);
            hash = hash * 10 + pairPoint(day.Isha_foroj, day.Isha_sunnat, day.Betr, day.Tahajjut);
            hash = hash * 10 + day.Color;
            return hash;
        }
        public static DailyDto getObject(int hash)
        {
            // 1947863
            int color = hash % 10;
            hash /= 10;
            bool Fojor_foroj, Fojor_sunnat, Johor_foroj, Johor_sunnat, Asor_foroj, Asor_sunnat, Magrib_foroj, Magrib_sunnat, Isha_foroj, Isha_sunnat, Betr, Tahajjut;
            
            // Pair of Isha + Betr&Tahajjut
            int x = hash % 10;
            hash /= 10;
            if (x == 1)
            {
                Isha_foroj = false; 
                Isha_sunnat = false;
                Betr = false;
                Tahajjut = false;
            }
            else if(x == 2)
            {
                Isha_foroj = false;
                Isha_sunnat = false;
                Betr = true;
                Tahajjut = false;
            }
            else if(x == 3)
            {
                Isha_foroj = false;
                Isha_sunnat = false;
                Betr = true;
                Tahajjut = true;
            }
            else if(x == 4)
            {
                Isha_foroj = true;
                Isha_sunnat = false;
                Betr = false;
                Tahajjut = false;
            }
            else if(x == 5)
            {
                Isha_foroj = true;
                Isha_sunnat = false;
                Betr = true;
                Tahajjut = false;
            }
            else if(x == 6)
            {
                Isha_foroj = true;
                Isha_sunnat = false;
                Betr = true;
                Tahajjut = true;
            }
            else if(x == 7)
            {
                Isha_foroj = true;
                Isha_sunnat = true;
                Betr = false;
                Tahajjut = false;
            }
            else if(x == 8)
            {
                Isha_foroj = true;
                Isha_sunnat = true;
                Betr = true;
                Tahajjut = false;
            }
            else
            {
                Isha_foroj = true;
                Isha_sunnat = true;
                Betr = true;
                Tahajjut = true;
            }
            
            // Pair of Asor + Magrib
            x = hash % 10;
            hash /= 10;
            if (x == 1)
            {
                Asor_foroj = false;
                Asor_sunnat = false;
                Magrib_foroj = false;
                Magrib_sunnat = false;
            }
            else if(x == 2)
            {
                Asor_foroj = false;
                Asor_sunnat = false;
                Magrib_foroj = true;
                Magrib_sunnat = false;
            }
            else if(x == 3)
            {
                Asor_foroj = false;
                Asor_sunnat = false;
                Magrib_foroj = true;
                Magrib_sunnat = true;
            }
            else if(x == 4)
            {
                Asor_foroj = true;
                Asor_sunnat = false;
                Magrib_foroj = false;
                Magrib_sunnat = false;
            }
            else if(x == 5)
            {
                Asor_foroj = true;
                Asor_sunnat = false;
                Magrib_foroj = true;
                Magrib_sunnat = false;
            }
            else if(x == 6)
            {
                Asor_foroj = true;
                Asor_sunnat = false;
                Magrib_foroj = true;
                Magrib_sunnat = true;
            }
            else if(x == 7)
            {
                Asor_foroj = true;
                Asor_sunnat = true;
                Magrib_foroj = false;
                Magrib_sunnat = false;
            }
            else if(x == 8)
            {
                Asor_foroj = true;
                Asor_sunnat = true;
                Magrib_foroj = true;
                Magrib_sunnat = false;
            }
            else
            {
                Asor_foroj = true;
                Asor_sunnat = true;
                Magrib_foroj = true;
                Magrib_sunnat = true;
            }
            
            // Pair of Fojor + Johor
            x = hash % 10;
            hash /= 10;
            if (x == 1)
            {
                Fojor_foroj = false; 
                Fojor_sunnat = false;
                Johor_foroj = false;
                Johor_sunnat = false;
            }
            else if(x == 2)
            {
                Fojor_foroj = false;
                Fojor_sunnat = false;
                Johor_foroj = true;
                Johor_sunnat = false;
            }
            else if(x == 3)
            {
                Fojor_foroj = false;
                Fojor_sunnat = false;
                Johor_foroj = true;
                Johor_sunnat = true;
            }
            else if(x == 4)
            {
                Fojor_foroj = true;
                Fojor_sunnat = false;
                Johor_foroj = false;
                Johor_sunnat = false;
            }
            else if(x == 5)
            {
                Fojor_foroj = true;
                Fojor_sunnat = false;
                Johor_foroj = true;
                Johor_sunnat = false;
            }
            else if(x == 6)
            {
                Fojor_foroj = true;
                Fojor_sunnat = false;
                Johor_foroj = true;
                Johor_sunnat = true;
            }
            else if(x == 7)
            {
                Fojor_foroj = true;
                Fojor_sunnat = true;
                Johor_foroj = false;
                Johor_sunnat = false;
            }
            else if(x == 8)
            {
                Fojor_foroj = true;
                Fojor_sunnat = true;
                Johor_foroj = true;
                Johor_sunnat = false;
            }
            else
            {
                Fojor_foroj = true;
                Fojor_sunnat = true;
                Johor_foroj = true;
                Johor_sunnat = true;
            }

            string date = numberToDate(hash);
            DailyDto obj = new DailyDto();
            obj.set(date, color, Fojor_foroj, Fojor_sunnat, Johor_foroj, Johor_sunnat, Asor_foroj, Asor_sunnat, Magrib_foroj, Magrib_sunnat, Isha_foroj, Isha_sunnat, Betr, Tahajjut);
            return obj;
        }
        public static List<int> getHash(List<DailyDto> days)
        {
            hashList = new List<int>();
            foreach (DailyDto day in days)
            {
                hashList.Add(getHash(day));
            }
            return hashList;
        }
        public static List<DailyDto> getObject(List<int> hashes)
        {
            List<DailyDto> objectList = new List<DailyDto>();
            foreach(int hash in hashes)
            {
                objectList.Add(getObject(hash));
            }
            return objectList;
        }
        
        private static int pairPoint(bool a, bool b, bool c, bool d)
        {
            if (a && b && c && d) return 9;
            if (a && b && c && !d) return 8;
            if (a && b && !c && !d) return 7;
            if (a && !b && c && d) return 6;
            if (a && !b && c && !d) return 5;
            if (a && !b && !c && !d) return 4;
            if (!a && !b && c && d) return 3;
            if (!a && !b && c && !d) return 2;
            //if (!a && !b && !c && !d) return 1;
            return 1;
        }
        static DateTime startDate = new DateTime(2023, 1, 1);
        public static int dateToNumber(string date)
        {
            string[] dates = date.Split('-');
            date = dates[1] + "-" + dates[0] + "-" + dates[2];
            DateTime currentDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]));
            return (currentDate - startDate).Days;
        }
        public static string numberToDate(int number)
        {
            string[] dates = startDate.AddDays(number).ToString().Split('/');
            return dates[1] + "-" + dates[0] + "-" + dates[2].Substring(2,2);
            //return dates[1] + "-" + dates[0] + "-" + dates[2];
        }
    }
}
