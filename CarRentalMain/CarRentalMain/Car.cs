using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalProgram
{
    [Serializable]
    public class Car
    {
        [System.Xml.Serialization.XmlElementAttribute("make")]
        public string make { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("model")]
        public string model { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("year")]
        public int year { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("price")]
        public string price { get; set; }
    }
}
