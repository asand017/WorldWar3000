using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject bulletPrefab;
    public Transform bulletSpawn;

	void Update(){
		//var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		//var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		//if(Input.GetKey("left")){
		//	transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z + 1); 
		//}

		//if(Input.GetKey("right")){
		//	transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z - 1); 
		//}

		//GameObject Camera = GameObject.FindGameObjectWithTag("Camera");

		//var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

		//transform.rotation = rot;
		//transform.eulerAngles = new Vector3 (0,0,transform.eulerAngles.z);
		//GetComponent<Rigidbody2D>().angularVelocity = 0;

		//Grab the current mouse position on the screen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));

        //Rotates toward the mouse
        gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);



         if(Input.GetKey(KeyCode .W)){
         	transform.position = new Vector3(transform.position.x,transform.position.y + 0.1f, transform.position.z);
         	//gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 4 );
         	//print("W");
         }

        if(Input.GetKey(KeyCode .S)){
         	transform.position = new Vector3(transform.position.x,transform.position.y - 0.1f, transform.position.z);
        }

        if(Input.GetKey(KeyCode .A)){
         	transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y , transform.position.z);
        }

        if(Input.GetKey(KeyCode .D)){
         	transform.position = new Vector3(transform.position.x + 0.1f,transform.position.y , transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fire();

        }

	}

	 void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 15;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);        
    }
}
