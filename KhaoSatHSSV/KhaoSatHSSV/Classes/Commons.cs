using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoSatHSSV.Classes
{
    public class Commons
    {
        public static int TryParseInt(string val)
        {
            int result;
            int.TryParse(val, out result);
            return result;
        }

        public static long TryParseLong(string val)
        {
            long result;
            long.TryParse(val, out result);
            return result;
        }

        public static float TryParseFloat(string val)
        {
            float result;
            float.TryParse(val, out result);
            return result;
        }

        public static DateTime TryParseDateTime(string val)
        {
            DateTime result;
            DateTime.TryParse(val, out result);
            return result;
        }

        public static double TryParseDouble(string val)
        {
            double result;
            double.TryParse(val, out result);
            return result;
        }

        public static bool TryParseBolean(string val)
        {
            bool result;
            bool.TryParse(val, out result);
            return result;
        }
    }
    public enum GroupName
    {
        R=1,
        I=2,
        A=3,
        S=4,
        E=5,
        C=6
    }
    public enum SubjectName
    {
        Toan=1,
        Ly=2,
        Hoa=3,
        Van=4,
        Su=5,
        Dia=6,
        Anh=7,
        Sinh=8
    }
}