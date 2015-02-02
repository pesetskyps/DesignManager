using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item{
	public string name;
	public string level;
	public string price;
	public Sprite icon;
	public bool isAvaliable;
	public Button.ButtonClickedEvent buttonEvent;
}

public class ListPopulator : MonoBehaviour {

	public GameObject prefabButton;
	public List<Item> itemList;
	public Transform contentPanel;
	void Start(){
		PopulateList ();
	}

	void PopulateList ()
	{
		foreach (var item in itemList) {
			GameObject newButton = Instantiate(prefabButton) as GameObject;	
			SampleButton sampleobj = newButton.GetComponent<SampleButton>();
			sampleobj.nameLabel.text = item.name;
			sampleobj.levelLabel.text = item.level;
			sampleobj.priceLabel.text = item.price;
			sampleobj.icon.sprite = item.icon;
			sampleobj.button.interactable = item.isAvaliable;
			sampleobj.button.onClick = item.buttonEvent;
			newButton.transform.SetParent(contentPanel,false);

			contentPanel.SetAsLastSibling();
		}
	}

	public void Eeee(){
		Debug.Log("fddff");
	}
}
