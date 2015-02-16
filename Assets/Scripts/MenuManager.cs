using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    private GameObject[] _menus;
	// Use this for initialization
	void Start () {
        _menus = GameObject.FindGameObjectsWithTag("Menu");
        HideAllMenus();
	}

	public void ShowMenu(Menu menu)
	{
        HideAllMenus();
        menu.IsOpen = true;
	}

    void HideAllMenus()
    {
        foreach (GameObject item in _menus)
        {
            Menu menutmp = item.GetComponent<Menu>();
            menutmp.IsOpen = false;
        }
    }
}
