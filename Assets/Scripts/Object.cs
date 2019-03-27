using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 1;
    [SerializeField] private float startPosition = 23.6f;
    [SerializeField] private float resetPosition = -23.6f;
    private bool leftSideDone = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        //transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        //if (leftSideDone) {
        //    if (transform.localPosition.x <= startPosition) {
        //        transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime));
        //    }
        //    else {
        //        leftSideDone = false;
        //    }
        //}
        //else {
        //    if (transform.localPosition.x >= resetPosition) {
        //        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));
        //    }
        //    else {
        //        leftSideDone = true;
        //    }
        //}

        if(!GameManager.instance.GameOver()) {

            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x <= resetPosition) {

                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }

        }

    }
}
