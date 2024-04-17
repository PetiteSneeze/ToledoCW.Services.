using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ToledoCW.Services.Model;

[DataContract(Name = "response", Namespace = "")]
public class ApiResponse
{
    public ApiResponse()
    {
    }

    public ApiResponse(ApiResponseError error) : this(new List<ApiResponseError>() {error})
    {
    }

    public ApiResponse(ApiResponseMessage message) : this(new List<ApiResponseMessage>() {message})
    {
    }

    public ApiResponse(IEnumerable<ApiResponseError> errors) : this()
    {
        Errors = errors;
    }

    public ApiResponse(IEnumerable<ApiResponseMessage> messages) : this()
    {
        Messages = messages;
    }
    

    [DataMember(Name = "errors")]
    [XmlArray("errors", Namespace = "")]
    [XmlArrayItem("error", Namespace = "")]
    public IEnumerable<ApiResponseError> Errors { get; set; }

    [DataMember(Name = "messages")]
    [XmlArray("messages", Namespace = "")]
    [XmlArrayItem("message", Namespace = "")]
    public IEnumerable<ApiResponseMessage> Messages { get; set; }
}


[DataContract(Name = "response", Namespace = "")]
public class ApiResponse<T> where T  : class
{
    public ApiResponse()
    {
    }

    public ApiResponse(T data) : this()
    {
        Data = data;
    }

    [DataMember(Name = "data")]
    [XmlElement("data", Namespace = "")]
    public T Data { get; set; }
    
}