using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Net.Http.Headers;

namespace cms
{
    public static class PersianConvertorDate
    {
        public static string toShamsi(this DateTime date)
        {
            PersianCalendar pc= new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00")
                + "/" + pc.GetDayOfMonth(date).ToString("00");

        }
    }
}