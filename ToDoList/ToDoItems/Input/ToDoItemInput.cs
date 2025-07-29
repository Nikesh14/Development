using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

#region Notes
/*
    In the provided code, `DataContract` and `DataMember` are attributes from the **.NET Data Contract Serialization** model (part of WCF - Windows Communication Foundation). 
    They are used to control how objects are serialized and deserialized, typically for communication between services (e.g., over SOAP, JSON, or XML).

    ### **1. `[DataContract]`**
        - **Purpose**: Marks a class as serializable and allows customization of its serialization behavior.
        - **Parameters Used**:
          - `Namespace = ""` → Specifies the XML namespace (empty here).
          - `IsReference = false` → Indicates whether object references should be preserved (default is `false`).
          - `Name = "ToDoItems"` → Overrides the default XML element name (default is the class name).
  
    **Meaning**:  
        This means the `ToDoItems` class is serializable, and when converted to XML/JSON, it will appear as `<ToDoItems>` (instead of the default class name).

    ### **2. `[DataMember]`**
        - **Purpose**: Specifies which properties/fields should be included in serialization.
        - **Parameters Used**:
          - `Name = "..."` → Custom name for the serialized property (e.g., `"ID"` instead of `ID`).
          - `Order = n` → Defines the serialization order (important for XML serialization).

    **Meaning**:  
        Each `[DataMember]` marks a property that will be included in the serialized output (e.g., `ID`, `Item`, `IsDone`, etc.). The `Order` ensures properties appear in a specific sequence.

    ### **Example Serialized Output (XML)**
        ```xml
            <ToDoItems>
                <ID>1</ID>
                <Item>Buy groceries</Item>
                <IsDone>false</IsDone>
                <Comment>Urgent</Comment>
                <CompletionDate>2023-01-01T00:00:00</CompletionDate>
            </ToDoItems>
        ```

    ### **Key Takeaways**
        - **`[DataContract]`** → Defines how the **entire class** is serialized.
        - **`[DataMember]`** → Defines which **properties** are serialized and their behavior.
        - If a property is **not** marked with `[DataMember]`, it **won’t be serialized**.

    ### **Note on `Order` in `[DataMember]`**
        - The `Order` parameter ensures properties appear in a specific sequence (e.g., `ID` first, then `Item`, etc.).
        - If `Order` is not specified, the order is alphabetical by default.

    This is commonly used in **WCF services**, **Web API (JSON serialization)**, and other .NET-based data exchange scenarios.
 */
#endregion

namespace ToDoList.ToDoItems.Input
{
    [DataContract(Namespace = "", IsReference = false, Name = "ToDoItemInput")]
    public class ToDoItemInput
    {
        //ID to store to-do items
        public long ID { get; set; }
        //A short description of the task.
        [DataMember(Name = "Title", Order = 0)]
        public string Title { get; set; }
        //More details about the task. 
        [DataMember(Name = "Description", Order = 1)]
        public string Description { get; set; }
        [DataMember(Name = "Status", Order = 2)]
        //Indicates whether the task is new, in progress, or completed
        public string Status { get; set; }
        [DataMember(Name = "DueDate", Order = 3)]
        //When the task should be finished. 
        public DateTime DueDate { get; set; }
        [DataMember(Name = "Priority", Order = 4)]
        //How important the task is.  
        public int Priority { get; set; }
        //When the task is completed. 
        [DataMember(Name = "CompletionDate", Order = 5)]
        public DateTime CompletionDate { get; set; }
    }
}
