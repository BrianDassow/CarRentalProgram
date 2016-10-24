using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalProgram
{
    [Serializable]
    public class User
    {
        [System.Xml.Serialization.XmlElementAttribute("username")]
        public string username { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("password")]
        public string password { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("power")]
        public int power { get; set; }
    }
}
