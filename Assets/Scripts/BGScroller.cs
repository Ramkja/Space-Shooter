using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float titleSizedZ;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Loop between values  with the maximun on titleSizedZ, that way the background will be always in screen
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, titleSizedZ);

        // Moving on Z axis using forward and the value from the repeat
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
