using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace ToDoList.ToDoItems.Output
{
    [DataContract(Namespace = "", IsReference = false, Name = "ToDoItemOutput")]
    public class ToDoItemFeedback
    {
        [DataMember(Name = "Feedback", Order = 3)]
        public string Feedback { get; set; }
    }
}
