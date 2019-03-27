using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    [SerializeField] private float objectSpeed = 10;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!GameManager.instance.GameOver()) {
            transform.Rotate(Vector3.up * (objectSpeed * Time.deltaTime));
        }
    }
}
