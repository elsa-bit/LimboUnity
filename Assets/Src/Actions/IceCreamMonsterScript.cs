using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamMonsterScript : MonoBehaviour
{
    public Transform iceCreamSpawn;
    public GameObject iceCream;
    public float shotSpeed = 5f;
    public float projectileSpeed = 5f;
    public float xOffset = 1f;
    public float yOffset = 1f;
    private bool canShoot = true;
    private Detector detector;

    private void Awake() {
        detector = GetComponentInChildren<Detector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detector.DetectorIsDetectingTarget() && canShoot) {
            Shoot();
        }
       
    }

    private void Shoot() {
        canShoot = false;
        StartCoroutine(ShootRate());
        GameObject cream = Instantiate(iceCream, iceCreamSpawn.position, Quaternion.identity);
        Vector2 distance = detector.GetDistance();
        if (transform.localScale.x < 0) {
            distance *= -1;
        }
        distance.y *= 2f;
        if(distance.y < 0) {
            distance.y = 0f;
        } else {
            distance.y *= 2f;
        }
        
        //Debug.Log(transform.localScale.x);
        cream.GetComponent<Rigidbody2D>().velocity = distance; //* projectileSpeed;//new Vector2(-1*xOffset, 1*yOffset) * projectileSpeed;
        //Debug.Log(distance);
    }

    IEnumerator ShootRate() {
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }
}
