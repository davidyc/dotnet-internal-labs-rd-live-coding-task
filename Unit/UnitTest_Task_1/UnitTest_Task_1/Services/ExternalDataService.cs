using UnitTest_Task_1.Models;
using UnitTest_Task_1.Services.Interface;

public class ExternalDataService : IExternalService
{
    
    public List<WorkItemType> GetWorkItemTypes()   
    {
        
        return new List<WorkItemType>
        {
            new WorkItemType { Name = "Task", Description = "Regular task" },
            new WorkItemType { Name = "Bug", Description = "Software bug" },
            new WorkItemType { Name = "Feature", Description = "New feature" }
        };
    }
     
    public List<WorkItemStatus> GetWorkItemStatuses()
    {        
        return new List<WorkItemStatus>
        {
            new WorkItemStatus { Name = "Open", Description = "Task is open" },
            new WorkItemStatus { Name = "InProgress", Description = "Task is in progress" },
            new WorkItemStatus { Name = "Closed", Description = "Task is closed" }
        };
    }
}
