using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText2 : MonoBehaviour {

    float initialRotation;
    float initialTime;
    float initialY;

	void Start () {
        initialTime = Time.time;
        initialY = transform.position.y;
        initialRotation = Random.Range(-20, 20);
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().color = new Color(1, 0, 0, Mathf.Max(0, 1 - (Time.time - initialTime)* (Time.time - initialTime)*1f));
        GetComponentInChildren<Outline>().effectColor = new Color(0, 0, 0, Mathf.Max(0, 1 - (Time.time - initialTime) * (Time.time - initialTime) * 1f));
        //GetComponentInChildren<Text>().effectColor = new Color(1, 0, 0, Mathf.Max(0, 1 - (Time.time - initialTime)));
        transform.Rotate(Vector3.back * initialRotation * 0.5f * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + initialRotation * 0.03f * Time.deltaTime, -(Time.time - initialTime - 1)*(Time.time - initialTime - 1) + initialY  + 1, 0);
        transform.localScale = new Vector3(0.005f + Mathf.Log10(0.01f*(Time.time - initialTime) + 1), 0.005f + Mathf.Log10(0.01f * (Time.time - initialTime) + 1));
        if(GetComponentInChildren<Text>().color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
