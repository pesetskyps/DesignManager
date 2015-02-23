using UnityEngine;
using System.Collections;

public class MenuOpen : MonoBehaviour {
	public Menu Menu;
	void OnMouseDown(){
		GameManager GameManager = new GameManager ();
		GameManager.ShowMenu (Menu);
	}
}
