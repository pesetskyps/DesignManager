using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>(); //GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void ShowMenu(Menu menu)
    {
        MenuManager.Instance.ShowMenu(menu);
    }

    public void HideMenu(Menu menu)
    {
        MenuManager.Instance.HideMenu(menu);
    }
}
