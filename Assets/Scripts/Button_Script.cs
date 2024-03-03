using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour {
	public GameObject panel;
	//Transform panel_pos;
	public Transform Dummy_parent;
	public Transform canvas;
	void Start(){
		//panel_pos = panel.GetComponent<RectTransform> ();
		panel.transform.SetParent (Dummy_parent);
	}

	public void Settings1(){
		//panel.SetActive(!panel.activeInHierarchy);
		/*if (panel.transform.position == panel_pos)
			panel.transform.position = new Vector2 (1000, 1000);
		else
			panel.transform.position = panel_pos;*/
		if (panel.transform.parent == Dummy_parent) {
			panel.transform.SetParent (canvas);
			panel.transform.SetSiblingIndex (3);
		}
		else if(panel.transform.parent == canvas)
			panel.transform.SetParent (Dummy_parent);
	}

	public void Reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
