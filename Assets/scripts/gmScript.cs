using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class gmScript : MonoBehaviour {

	public int platformNum = 10;
	public Transform level, player;
	public GameObject platform;
	public Text scoreTxt;

	List<GameObject> Platforms = new List<GameObject>();
	float previousHeight = 0f, 
		  scoreNum = 0f;

	// Use this for initialization
	void Start () {
		GenerateLevel(platformNum);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Rendering only platforms that are nearby
		if (player != null) {
			foreach (GameObject Platform in Platforms) {
				if (Mathf.Abs (Platform.transform.position.y - player.position.y) > 15f)
					Platform.GetComponent<SpriteRenderer> ().enabled = false;
				else
					Platform.GetComponent<SpriteRenderer> ().enabled = true;
			}

			//Updating score
			if (player.position.y > scoreNum) {
				scoreNum = player.position.y;
				scoreTxt.text = scoreNum.ToString ("F1");
			}
		}
	}

	void GenerateLevel (int platformNum)
	{
		for (int i = 0; i < platformNum; i++) {
			Vector2 position = GeneratePosition(previousHeight);
			previousHeight = position.y;
			Platforms.Add (Instantiate(platform, position, Quaternion.identity, level) as GameObject);
		}
	}

	Vector2 GeneratePosition (float previousHeight)
	{
		return new Vector2 (Random.Range(-3.5f, 3.5f), previousHeight + Random.Range (1f, 2f));
	}
}

