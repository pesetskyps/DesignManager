﻿
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BugButtonTransformer : MonoBehaviour
{
    public Bug Bug;
    public Text remainedTimeLabel;
    //for cheap fix button script attached it will be elite fix button
    public Button otherTypeFixButton;

    private Animator _animator;
    private Button _button;
    private Animator otherTypeFixButtonAnimator;

    private GameObject room;
    private RoomCustomization roomCustomizationScript;
    private List<BugFix> startedBugFixes = new List<BugFix>();

    public delegate void BugFixCanceledEventHandler(Bug bug);
    public static event BugFixCanceledEventHandler onBugCanceled;


    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();

        room = GameObject.FindGameObjectWithTag("Room");
        if (room != null)
        {
            roomCustomizationScript = room.GetComponent<RoomCustomization>();
        }
    }

    public void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("FixIsStarted"))
        {
            if (roomCustomizationScript != null)
            {
                startedBugFixes = roomCustomizationScript.StartedBugFixes;
            }
            if (startedBugFixes != null)
            {
                foreach (var bugFix in startedBugFixes)
                {
                    var now = DateTime.Now;
                    var remainedTime = bugFix.EndTime - now;
                    if (remainedTime.TotalSeconds > 0)
                    {
                        remainedTimeLabel.text = remainedTime.ToReadableString();
                    }
                    else
                    {
                        remainedTimeLabel.text = new TimeSpan(0, 0, 0).ToReadableString();
                    }
                }
            }
        }
    }

    public bool IsStarted
    {
        get { return _animator.GetBool("IsStarted"); }
        set { _animator.SetBool("IsStarted", value); }
    }

    public void ButtonPressed()
    {
        if (_button != null)
        {
            _button.interactable = false;
        }
        if (otherTypeFixButton != null)
        {
            otherTypeFixButton.interactable = false;
            otherTypeFixButtonAnimator = otherTypeFixButton.GetComponent<Animator>();
            otherTypeFixButtonAnimator.SetBool("Disabled", true);
        }

        IsStarted = true;
    }

    public void ButtonCanceled()
    {
        if (_button != null)
        {
            _button.interactable = true;
        }
        if (otherTypeFixButton != null) {
            otherTypeFixButton.interactable = true;
        }
        IsStarted = false;

        if (onBugCanceled != null)
            onBugCanceled(Bug);
    }
}
