using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    public class Common
    {
        const string HtmlTagPattern = "<.*?>";

        public static string StripHtml(string inputString)
        {
            return Regex.Replace(inputString, HtmlTagPattern, string.Empty);
        }

        public static string GenerateCode()
        {
            var BraCodeText = "";

            Random rand = new Random();
            int first_num = rand.Next(52);
            int sencond_num = rand.Next(99);
            int thrid_num = rand.Next(29);

            BraCodeText = "DPR" + sencond_num + "" + thrid_num + "" + first_num;
            return BraCodeText;
        }
    }
}
