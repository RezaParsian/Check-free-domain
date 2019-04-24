using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Domain
{
    interface ICheckdomain
    {
        /// <summary>
        /// get a name and chacked each domain
        /// </summary>
        /// <param name="webpage"></param>
        /// <returns></returns>
        string[] domain_all(string webpage);
        string StripHTML(string input);

    }
}
