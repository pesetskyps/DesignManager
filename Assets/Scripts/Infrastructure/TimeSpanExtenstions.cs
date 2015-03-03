using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class TimeSpanExtenstions
{

    public static string ToReadableString(this TimeSpan span)
    {
        string formatted = string.Format("{0}{1}{2}{3}",
            span.Duration().Days > 0 ? string.Format("{0:0}d,", span.Days) : string.Empty,
            string.Format("{0:00}h:", span.Hours) ,
            string.Format("{0:00}m:", span.Minutes),
            string.Format("{0:00}s", span.Seconds));

        if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

        if (string.IsNullOrEmpty(formatted)) formatted = "00h:00m:00s";

        return formatted;
    }
}

