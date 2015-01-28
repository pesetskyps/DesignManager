using UnityEngine;
using System.Collections;

public class MenuOpen : MonoBehaviour {
	public Menu Menu;
	void OnMouseDown(){
		MenuManager menuManager = new MenuManager ();
		menuManager.ShowMenu (Menu);
	}
}
