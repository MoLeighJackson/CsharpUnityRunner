using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

	
	void Start () {
        ResetDelay();
        StartCoroutine(ObstacleGenerator());
	}

    IEnumerator ObstacleGenerator()
    {
        yield return new WaitForSeconds(delay);

        if(active)
        {
            var newTransform = transform;

            Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);
            ResetDelay();

        }
        StartCoroutine(ObstacleGenerator());
    }

    void ResetDelay()
    {
        delay = UnityEngine.Random.Range(delayRange.x, delayRange.y);
    }

}
