using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace Check_Domain
{
    class Checkdomain : ICheckdomain
    {
        private string url = "http://whois.avasite.ir/whois.php";
        private string data = "&tld_biz=on&tld_ca=on&tld_co.ir=on&tld_co.uk=on&tld_com=on&tld_de=" +
            "on&tld_eu=on&tld_in=on&tld_info=on&tld_io=on&tld_ir=on&tld_name=on&tld_net=on&tld_org=" +
            "on&tld_pro=on&tld_ro=on&tld_tv=on&tld_us=on&tld_ws=on";

        public string[] domain_all(string webpage)
        {
            string result="";
            try
            {
                using (WebClient wb = new WebClient())
                {
                    wb.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                    result = wb.UploadString(url, "domain=" + webpage + data);
                }

            }
            catch
            {

            }
            return extract(result).Split('\n');
        }

        private string extract(string result)
        {
            string rs = "";
            RegexOptions options = RegexOptions.Singleline | RegexOptions.Multiline;
            MatchCollection m = Regex.Matches(result, @"<td class='disponibil'>.*?<\/td>", options);
            foreach (var item in m)
            {
                rs += Regex.Match(item.ToString(), @"'\?domain=(.*?)'", options).Groups[1].Value + "\n";
            }

            return rs;
        }

        public string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty).Replace("&nbsp;", "");
        }
    }
}
