using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace ToDoList.ToDoItems.Output
{
    [DataContract(Namespace = "", IsReference = false, Name = "ToDoItemOutput")]
    public class ToDoItem
    {
        [DataMember(Name = "ID", Order = 0)]
        public long ID { get; set; }

        [DataMember(Name = "Item", Order = 1)]
        public string Item { get; set; }

        [DataMember(Name = "IsDone", Order = 2)]
        public bool IsDone { get; set; }

        [DataMember(Name = "Comment", Order = 3)]
        public string Comment { get; set; }

        [DataMember(Name = "CompletionDate", Order = 2)]
        public DateTime CompletionDate { get; set; }
    }
}
