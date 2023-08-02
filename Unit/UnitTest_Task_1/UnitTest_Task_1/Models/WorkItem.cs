using UnitTest_Task_1.Models;

public class WorkItem
{
    public string Type { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string LastUpdatedBy { get; set; }
    public bool IsCompleted { get; set; }
    public int Priority { get; set; }
    public double Estimate { get; set; }
}
