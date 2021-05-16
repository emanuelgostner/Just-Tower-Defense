using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour {
    // Tower gameObject. Public variables can be assigned via GUI
    public GameObject towerPrefab;

    // Built in unity function. Triggered when click and release
    void OnMouseUpAsButton() {
        // Build Tower above Buildplace
    	GameObject g = (GameObject)Instantiate(towerPrefab);
    	g.transform.position = transform.position + Vector3.up;
    }
}