using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item{
	public string name;
	public string type;
	public string rarity;
	public Sprite icon;
	public bool isChampion;
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
			sampleobj.typeLabel.text = item.type;
			sampleobj.rarityLabel.text = item.rarity;
			sampleobj.icon.sprite = item.icon;
			sampleobj.isChampionIcon.SetActive(item.isChampion);

			newButton.transform.SetParent(contentPanel,false);
			contentPanel.SetAsLastSibling();
		}
	}
}
