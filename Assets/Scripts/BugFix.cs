using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class BugFix
{
    public double StartTime { get; set; }
    public double Duration { get; set; }
    public double EndTime { get; set; }
    public string RoomName { get; set; }
    public FixType FixType { get; set; }
    public Bug Bug { get; set; }

    public BugFix(string roomName, double startTime, double duration, double endTime, FixType fixType, Bug bug)
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

