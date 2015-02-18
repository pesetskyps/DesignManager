using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    private GameObject[] _menus;
    private Menu _currentMenu;
    public Menu CurrentMenu
    {
        get { return _currentMenu; }
        set { _currentMenu = value; }
    }
	// Use this for initialization
	void Start () {
        _menus = GameObject.FindGameObjectsWithTag("Menu");
        HideAllMenus();
	}

	public void ShowMenu(Menu menu)
	{
        HideAllMenus();
        _currentMenu = menu;
        menu.IsOpen = true;
	}

    void HideAllMenus()
    {
        if (_menus != null)
        {
            foreach (GameObject item in _menus)
            {
                Menu menutmp = item.GetComponent<Menu>();
                menutmp.IsOpen = false;
            }
            _currentMenu = null;
        }
    }
}
