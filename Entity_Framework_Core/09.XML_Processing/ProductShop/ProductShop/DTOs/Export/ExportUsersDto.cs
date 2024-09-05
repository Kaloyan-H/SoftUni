using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportUsersDto
    {
        [XmlElement("count")]
        public int UserCount { get; set; }
        [XmlArray("users")]
        public ExportUsersUserDto[] Users { get; set; } = null!;
    }
}
