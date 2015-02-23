using UnityEngine;
using System.Collections;

public class MenuClose : MonoBehaviour {

	public void CloseMenu(Menu menu) {
		menu.IsOpen = false;
        var canvases = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (var canvas in canvases)
        {
            MenuManager.Instance.CurrentMenu = null;
        }
	}
}
