using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * 1, Space.World);
	}

    //when colliding with ammo pick up
	void OnTriggerEnter(Collider other) {
        int ammo = 5;
		other.gameObject.SendMessage("ApplyAmmoPickup", ammo);
		Destroy(gameObject);
	}

}
