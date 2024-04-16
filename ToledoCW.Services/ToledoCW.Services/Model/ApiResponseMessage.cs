using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ToledoCW.Services.Model;

[DataContract(Name = "responseMessage", Namespace = "")]
[XmlRoot(ElementName = "responseMessage", Namespace = "")]
public class ApiResponseMessage
{
    public ApiResponseMessage()
    {
    }

    public ApiResponseMessage(string type, string message)
    {
        Value = message;
        Type = type;
    }

    [DataMember(Name = "Message")]
    [XmlElement("Message", Namespace = "")]
    public string Value { get; set; }

    [DataMember(Name = "Type")]
    [XmlElement("Type", Namespace = "")]
    public string Type { get; set; }
}