using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour {

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
        GetComponent<TextMesh>().color = new Color(1, 0, 0, Mathf.Max(0, 1 - (Time.time - initialTime)));
        transform.Rotate(Vector3.forward * initialRotation * 0.1f * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + initialRotation * 0.01f * Time.deltaTime, -(Time.time - initialTime - 1)*(Time.time - initialTime - 1) + initialY  + 1, 0);
        transform.localScale = new Vector3(0.05f + Mathf.Log10(0.01f*(Time.time - initialTime) + 1), 0.05f + Mathf.Log10(0.01f * (Time.time - initialTime) + 1));
    }
}
