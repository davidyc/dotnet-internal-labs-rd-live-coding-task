using UnitTest_Task_1.Models;

namespace UnitTest_Task_1.Services.Interface
{
    public interface IExternalService
    {
        List<WorkItemType> GetWorkItemTypes();
        List<WorkItemStatus> GetWorkItemStatuses();
    }

}
