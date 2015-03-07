using UnityEngine;
using System.Collections;

public class MenuManager : Singleton<MenuManager>
{
    private GameObject[] _menus;
    private Menu _currentMenu;

    public Menu CurrentMenu
    {
        get { return _currentMenu; }
        set { _currentMenu = value; }
    }

    void Start()
    {
        instance = GameObject.FindObjectOfType<MenuManager>();
        HideAllMenus();
    }


    //private static MenuManager instance = null;
    //public static MenuManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = GameObject.FindObjectOfType<MenuManager>();
    //        }
    //        return instance;
    //    }
    //}

    public void ShowMenu(Menu menu)
    {
        HideAllMenus();
        CurrentMenu = menu;
        menu.IsOpen = true;
    }

    public void HideMenu(Menu menu)
    {
        if (_currentMenu == menu)
        {
            CurrentMenu = null;
            menu.IsOpen = false;
        }
    }

    void HideAllMenus()
    {
        _menus = GameObject.FindGameObjectsWithTag("Menu");
        if (_menus != null)
        {
            foreach (GameObject item in _menus)
            {
                Menu menutmp = item.GetComponent<Menu>();
                menutmp.IsOpen = false;
            }
            CurrentMenu = null;
        }
    }
}
