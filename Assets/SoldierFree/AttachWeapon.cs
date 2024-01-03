using UnityEngine;
using System.Collections;

public class AttachWeapon : MonoBehaviour {
	public Transform attachPoint;
	public Transform Weapon;
	// Use this for initialization
	void Start () {
		Weapon.parent = attachPoint;
		Weapon.localPosition = new Vector3(-0.128f, 0.039f, -0.001f);
		Weapon.rotation = attachPoint.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
