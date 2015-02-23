using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    private GameObject[] _menus;
    private string _currentMenu;
    private int test;

    public int MyProperty { get { return test; } set { test = value; } }
    public string CurrentMenu
    {
        get { return _currentMenu; }
        set { _currentMenu = value; }
    }

    void Start()
    {
        _menus = GameObject.FindGameObjectsWithTag("Menu");
        HideAllMenus();
    }


    private static MenuManager instance = null;
    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MenuManager>();
            }
            return instance;
        }
    }

    public void ShowMenu(Menu menu)
    {
        test = Random.Range(1, 100);
        HideAllMenus();
        var menuName = menu.transform.name;
        _currentMenu = menuName;
        menu.IsOpen = true;
    }

    public void HideMenu(Menu menu)
    {
        _currentMenu = null;
        menu.IsOpen = false;
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
