using UnityEngine;
using System.Collections;

public class MenuClose : MonoBehaviour {

	public void CloseMenu(Menu menu) {
		menu.IsOpen = false;
	}
}
