using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMonsterScript : MonoBehaviour
{
    private Detector detector;
    private bool isFalling = false;
    private RigidbodyConstraints2D originalConstraints;
    public GameObject sensor;

    private void Awake() {
        originalConstraints = GetComponentInChildren<Rigidbody2D>().constraints;
        detector = sensor.GetComponent<Detector>();//GetComponentInChildren<Detector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if(detector.DetectorIsDetectingTarget() && !isFalling) {
            FallSuicide();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isFalling) {
            if (collision.gameObject.CompareTag("Player"))
            {
                LoseLife(collision.gameObject);
            }
            KillMe();
        }
    }

    private void LoseLife(GameObject player)
    {
        var playerScript = player.GetComponent<PlayerMove>();
        playerScript.gameManagement.TakeDamage(0.5f);
    }

    private void FallSuicide() {
        isFalling = true;
        Debug.Log("I'm faaaaalling");
        GetComponentInChildren<Rigidbody2D>().constraints = originalConstraints;
    }

    private void KillMe() {
        // Do hit animation
        Destroy(gameObject);
    }
}
