using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BugFix
{
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime EndTime { get; set; }
    public string RoomName { get; set; }
    public FixType FixType { get; set; }
    public Bug Bug { get; set; }

    public BugFix(string roomName, DateTime startTime, TimeSpan duration, DateTime endTime, FixType fixType, Bug bug)
    {
        // TODO: Complete member initialization
        this.RoomName = roomName;
        this.StartTime = startTime;
        this.Duration = duration;
        this.EndTime = endTime;
        this.FixType = fixType;
        this.Bug = bug;
    }
}

public enum FixType
{
    Cheap,
    Elite
}

