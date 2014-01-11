using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoSatHSSV.Classes
{
   
    public class Commons
    {
        public static string TenNhom(int Ma)
        {
            string result = string.Empty;
            if (Ma == (int)GroupName.A)
                result = GroupName.A.ToString();
            else if (Ma == (int)GroupName.R)
                result = GroupName.R.ToString();
            else if (Ma == (int)GroupName.C)
                result = GroupName.C.ToString();
            else if (Ma== (int)GroupName.E)
                result = GroupName.E.ToString();
            else if (Ma== (int)GroupName.I)
                result = GroupName.I.ToString();
            else if (Ma== (int)GroupName.S)
                result = GroupName.S.ToString();
            return result;
        }
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
    public enum khoiThi
    {
        A= 1,
        A1= 2,
        B= 3,
        C= 4,
        D1= 5,
        D2= 6,
        D3= 7,
        D4= 8,
        D5= 9,
        D6= 10,
        H= 11,
        N= 12,
        M= 13,
        T= 14,
        V= 15,
        S= 16,
        R= 17,
        K= 18,
    }
}