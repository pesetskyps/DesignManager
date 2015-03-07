using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BugToolTip))]
public class BugFixer : MonoBehaviour
{

    public delegate void BugFixedEventHandler();
    public static event BugFixedEventHandler onBugFixed;

    private BugFix bugFix;
    public string Name;


    private BugToolTip bugToolTip;
    // Use this for initialization
    void OnEnable()
    {
        RoomCustomization.onBugFixStarted += this.StartBugFix;
        bugToolTip = GetComponent<BugToolTip>();
    }

    void OnDisable()
    {
        RoomCustomization.onBugFixStarted -= this.StartBugFix;
    }

    void Update()
    {
        if (bugFix != null)
        {
            if (bugFix.Bug.Type == bugToolTip.bugType)
            {
                if (IsBugFixed(bugFix))
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartBugFix(BugFix bugFix)
    {
        if (bugFix.Bug.Type == bugToolTip.bugType)
        {
            this.bugFix = bugFix;
            Name = bugFix.Bug.Name;
        }
    }

    private bool IsBugFixed(BugFix bugFix)
    {
        var now = System.DateTime.Now;
        var remainedTime = bugFix.EndTime - now;
        return remainedTime.TotalSeconds < 0;
    }
}
