﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BugPanel : MonoBehaviour {
    public Text Description;
    public Text Name;
    
    public Text CheapCostToFixText;
    public Image CheapCostToFixImage;
    public Button CheapCostToFixButton;
    public Text CheapFixTimeMin;
    public BugButtonTransformer CheapButtonTransformer;


    public Text EliteCostToFixText;
    public Image EliteCostToFixImage;
    public Button EliteCostToFixButton;
	public Text EliteFixTimeMin;
    public BugButtonTransformer EliteButtonTransformer;
}
