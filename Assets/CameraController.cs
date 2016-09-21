using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField] GameObject slate;

	// Use this for initialization
	void Start () {
        Vector3 newPos = slate.transform.position; ;
        newPos.z -= 10;
        newPos.y -= 0.5f;
        transform.position = newPos;
	}
	
}
