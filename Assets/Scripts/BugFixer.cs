using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(RoomCustomization))]
public class BugFixer : MonoBehaviour
{

    public delegate void BugFixedEventHandler(GameObject bugGObj, BugFix bugFix);
    public static event BugFixedEventHandler onBugFixed;

    public delegate void BugFixStartedEventHandler(BugFix bugfix);
    public static event BugFixStartedEventHandler onBugFixStarted;

    public List<BugFix> StartedBugFixes = new List<BugFix>();
    public List<BugFix> FinishedBugFixes = new List<BugFix>();
    //public List<Bug> BugsFound = new List<Bug>();
    public List<Bug> bbb = new List<Bug>();
    private BugToolTip bugToolTip;
    // Use this for initialization
    void OnEnable()
    {
        bugToolTip = GetComponent<BugToolTip>();
        BugButtonTransformer.onBugCanceled += RemoveBugFromStartedBugFixes;
        onBugFixed += FinishBugFix;
        BugToolTip.onBugFound += AddBugToFoundBugs;
    }

    void OnDisable()
    {
        BugButtonTransformer.onBugCanceled -= RemoveBugFromStartedBugFixes;
        onBugFixed -= FinishBugFix;
        BugToolTip.onBugFound -= AddBugToFoundBugs;
    }

    void Update()
    {
        if (StartedBugFixes.Count != 0)
        {
            foreach (var bugFix in StartedBugFixes)
            {
                if (IsBugFixed(bugFix))
                {
                    var FoundBugs = GameObject.FindGameObjectsWithTag("Bug");
                    if (FoundBugs != null)
                    {
                        foreach (var bug in FoundBugs)
                        {
                            bugToolTip = bug.GetComponent<BugToolTip>();
                            if (bugToolTip != null)
                            {
                                if (bugFix.Bug.Type == bugToolTip.bugType)
                                {
                                    if (onBugFixed != null)
                                        onBugFixed(bug, bugFix);
                                }
                            }
                        }
                    }
                }
            }

        }
    }


    public void StartBugFix(string roomName, FixType fixType, float timeToFix, Bug bug)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.Add(TimeSpan.FromMinutes(timeToFix));
        BugFix bugFix = new BugFix(roomName, startTime.ToOADate(), timeToFix, endTime.ToOADate(), fixType, bug);

        StartedBugFixes.Add(bugFix);
        if (onBugFixStarted != null)
            onBugFixStarted(bugFix);
    }

    public void FinishBugFix(GameObject bug, BugFix bugFix)
    {
        bug.SetActive(false);
        FinishedBugFixes.Add(bugFix);
    }

    private bool IsBugFixed(BugFix bugFix)
    {
        var now = System.DateTime.Now;
        var remainedTime = DateTime.FromOADate(bugFix.EndTime) - now;
        return remainedTime.TotalSeconds < 0;
    }

    public void RemoveBugFromStartedBugFixes(Bug bug)
    {
        var startedBugFix = StartedBugFixes.Find(b => b.Bug.Name == bug.Name);
        if (startedBugFix != null)
        {
            StartedBugFixes.Remove(startedBugFix);
        }
    }

    public void AddBugToFoundBugs(Bug bug)
    {
        Debug.Log(FinishedBugFixes);
        bbb.Add(bug);
    }
}
