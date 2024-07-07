using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetStatus", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        Class1 GetStatus(int id,string name);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetStatus1", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        Class1 GetStatus1(Class1 cl);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract (Namespace = "http://tempuri.org/")]
    public class Class1
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
