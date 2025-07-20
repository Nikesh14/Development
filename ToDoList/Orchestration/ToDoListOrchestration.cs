using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using ToDoList.Abstractions;
using ToDoList.ToDoItems.Output;

#region Notes
/*
    ### **What is `IsReference` in `[DataContract]`?**  
        The `IsReference` parameter in the `[DataContract]` attribute controls whether object references should be preserved during serialization.  

    #### **Possible Values:**
        - `IsReference = false` (Default)  
            - Objects are serialized **by value** (a full copy is made).  
            - If the same object appears multiple times in a graph, it is serialized multiple times.  
            - This can lead to data duplication but avoids circular reference issues.  

        - `IsReference = true`  
            - Objects are serialized **by reference** (preserves object identity).  
            - If the same object is referenced multiple times, it is serialized once with a unique ID, and references point to it.  
            - Helps prevent circular reference errors in complex object graphs.  

    ---

    ### **Example: `IsReference = false` (Default Behavior)**
        ```csharp
            [DataContract(IsReference = false)]
            public class Employee
            {
                [DataMember]
                public string Name { get; set; }

                [DataMember]
                public Employee Manager { get; set; } // Circular reference
            }
        ```
        **Serialization Result (XML):**  
        ```xml
            <Employee>
                <Name>John</Name>
                <Manager>
                    <Name>Alice</Name>
                    <Manager>
                        <Name>John</Name> <!-- Duplicate data -->
                        <Manager>...</Manager>
                    </Manager>
                </Manager>
            </Employee>
        ```
    - **Problem:** Infinite loop (stack overflow) if `Manager` points back to the same object.  

    ---

    ### **Example: `IsReference = true` (Preserves References)**
        ```csharp
            [DataContract(IsReference = true)]
            public class Employee
            {
                [DataMember]
                public string Name { get; set; }

                [DataMember]
                public Employee Manager { get; set; } // Circular reference
            }
        ```
        **Serialization Result (XML with IDs):**  
        ```xml
            <Employee z:Id="1" xmlns:z="http://schemas.microsoft.com/2003/10/Serialization/">
                <Name>John</Name>
                <Manager z:Id="2">
                    <Name>Alice</Name>
                    <Manager z:Ref="1" /> <!-- Refers back to John (ID=1) -->
                </Manager>
            </Employee>
        ```
    - **Solution:** Uses `z:Id` and `z:Ref` to track references, avoiding duplication and infinite loops.  

    ---

    ### **When to Use `IsReference = true`?**
        ✅ **Use when:**  
            - Your object graph has **circular references** (e.g., `Employee.Manager` pointing back to `Employee`).  
            - You want to **avoid duplicate data** in serialization.  

        ❌ **Avoid when:**  
            - You need **simple, self-contained objects** (no circular references).  
            - You're working with **JSON serialization** (some JSON parsers don’t support reference tracking).  

    ---

    ### **Key Takeaways**
        - `IsReference = false` → **Default**, serializes objects **by value** (may duplicate data).  
        - `IsReference = true` → Serializes objects **by reference**, preventing circular reference issues.  
        - Useful in **WCF, SOAP, or XML serialization** where object graphs can be complex.  
 */
#endregion

namespace ToDoList.Orchestration
{
    [DataContract(Namespace = "", IsReference = true, Name = "ToDoListOrchestration")]
    public class ToDoListOrchestration : IToDoListOrchestration
    {
        public ToDoItem GetToDoListFromId(int id)
        {

            return new ToDoItem();
        }

        public void AddItemToList(ToDoItems.Input.ToDoItemInput input)
        {

        }
    }
}
