using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		print("hey");
		if(col.gameObject.tag == "Bullet"){
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
}
