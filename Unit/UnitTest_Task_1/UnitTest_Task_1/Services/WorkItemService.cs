using UnitTest_Task_1.Models;
using UnitTest_Task_1.Services.Interface;

namespace UnitTest_Task_1.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IExternalService externalService;
        private static List<WorkItemType> _workItemsCache;
        private static List<WorkItemStatus> _workItemStatusesCache;

        public WorkItemService(IExternalService externalService)
        {
            this.externalService = externalService;
        }

        public bool CheckType(WorkItem workItem)
        {
            var workItemStatuses = GetWorkItemStatuses();
            return workItemStatuses.Any(x=>x.Equals(workItem.Type));     
        }


        public bool CheckStatus(WorkItem workItem) 
        {
            var workItemTypes = GetWorkItemTypes();
            return workItemTypes.Any(x => x.Name.Equals(workItem.Status));
        }


        private List<WorkItemType> GetWorkItemTypes()
        {
            if (_workItemsCache == null)
                return externalService.GetWorkItemTypes();

            return _workItemsCache;
        }

        private List<WorkItemStatus> GetWorkItemStatuses()
        {
            if (_workItemStatusesCache == null)
                return externalService.GetWorkItemStatuses();
            return _workItemStatusesCache;
        }
    }
}
