using System.Net.Mime;
using System.Xml.Linq;
using System.Xml;

namespace umbraco_clean_demo.Domain.Entities;
public class umbracoPropertyData
{
public int id{ get; set; }
public int versionId{ get; set; }
public int propertyTypeId{ get; set; }
public int languageId{ get; set; }
public string segment{ get; set; }
public int intValue{ get; set; }
public float decimalValue{ get; set; }
public DateTime dateValue{ get; set; }
public string varcharValue { get; set; }
public string textValue { get; set; }
}
