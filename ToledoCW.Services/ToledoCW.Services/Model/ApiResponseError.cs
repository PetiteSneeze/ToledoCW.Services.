using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ToledoCW.Services.Model;

[DataContract(Name = "responseError", Namespace = "")]
[XmlRoot(ElementName = "responseError", Namespace = "")]
public class ApiResponseError
{
    public ApiResponseError()
    {
        Id = new Guid();
    }

    public ApiResponseError(string value, string key = null) : base()
    {
        Key = key ?? "Error";
        Value = value;
        Date = DateTime.Now;
    }

    [DataMember(Name = "Id")]
    public Guid? Id { get; set; }

    [DataMember(Name = "Key")]
    public string Key { get; set; }

    [DataMember(Name = "Value")]
    public string Value { get; set; }

    [DataMember(Name = "Date")]
    public DateTime Date { get; set; }
}