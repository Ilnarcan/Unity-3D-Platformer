using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    Animator anim;
    private Rigidbody rigitBody;
    private bool jump = false;
    private AudioSource audioSource;

    private void Awake() {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigitBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.PlayerActive() && GameManager.instance.GameStarted()) {
            if (Input.GetMouseButtonDown(0)) {
                anim.Play("jump");
                audioSource.PlayOneShot(sfxJump);
                rigitBody.useGravity = true;
                jump = true;
            }
        }
        /*else if(GameManager.instance.GameOver() && GameManager.instance.GameStarted()) {
            if(Input.GetMouseButtonDown(0)) {
                GameManager.instance.Restart();
            }

        }*/

	}

    void FixedUpdate() {
        if (jump) {
            jump = false;
            rigitBody.velocity = new Vector2(0, 0);
            rigitBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);

            //rigitBody.useGravity = false;
        }
    }

    IEnumerator Waiting() {
        Debug.Log("123");
        yield return new WaitForSeconds(500);
        Debug.Log("ok");
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "obstacle") {
            rigitBody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            rigitBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();

            //StartCoroutine(Waiting());
            //GameManager.instance.Restart();

        }
    }
}
