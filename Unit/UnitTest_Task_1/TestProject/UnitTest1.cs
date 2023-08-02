using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using UnitTest_Task_1.Models;
using UnitTest_Task_1.Services;
using UnitTest_Task_1.Services.Interface;

namespace UnitTest_Task_1.Tests
{
    public class WorkItemServiceTests
    {
        private readonly Mock<IExternalService> mockExternalService;
        private readonly WorkItemService workItemService;

        public WorkItemServiceTests()
        {
            mockExternalService = new Mock<IExternalService>();
            workItemService = new WorkItemService(mockExternalService.Object);
        }

        [Fact]
        public void CheckType_ShouldReturnTrue_WhenWorkItemStatusExists()
        {
            // Arrange
            var workItemStatuses = new List<WorkItemStatus>
            {
                new WorkItemStatus { Name = "Open" },
                new WorkItemStatus { Name = "In Progress" },
                new WorkItemStatus { Name = "Closed" }
            };

            mockExternalService.Setup(service => service.GetWorkItemStatuses()).Returns(workItemStatuses).Verifiable();

            var workItem = new WorkItem { Status = "Open" };

            // Act
            bool result = workItemService.CheckType(workItem);

            // Assert
            Assert.True(result);
            mockExternalService.Verify();
        }

        [Fact]
        public void CheckType_ShouldReturnFalse_WhenWorkItemStatusDoesNotExist()
        {
            // Arrange
            var workItemStatuses = new List<WorkItemStatus>
            {
                new WorkItemStatus { Name = "Open" },
                new WorkItemStatus { Name = "In Progress" },
                new WorkItemStatus { Name = "Closed" }
            };

            mockExternalService.Setup(service => service.GetWorkItemStatuses()).Returns(workItemStatuses);

            var workItem = new WorkItem { Type = "Task" };

            // Act
            bool result = workItemService.CheckType(workItem);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckStatus_ShouldReturnTrue_WhenWorkItemTypesExists()
        {
            // Arrange
            // Arrange
            var workItemStatuses = new List<WorkItemStatus>
            {
                new WorkItemStatus { Name = "Open" },
                new WorkItemStatus { Name = "In Progress" },
                new WorkItemStatus { Name = "Closed" }
            };

            mockExternalService.Setup(service => service.GetWorkItemStatuses()).Returns(workItemStatuses);

            var workItem = new WorkItem { Status = "Task" };

            // Act
            bool result = workItemService.CheckStatus(workItem);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckStatus_ShouldReturnFalse_WhenWorkItemTypesDoesNotExist()
        {
            // Arrange
            var workItemTypes = new List<WorkItemType>
            {
                new WorkItemType { Name = "Bug" },
                new WorkItemType { Name = "Task" },
                new WorkItemType { Name = "Feature" }
            };

            mockExternalService.Setup(service => service.GetWorkItemTypes()).Returns(workItemTypes);

            var workItem = new WorkItem { Status = "Completed" };

            // Act
            bool result = workItemService.CheckStatus(workItem);

            // Assert
            Assert.False(result);
        }
    }
}
