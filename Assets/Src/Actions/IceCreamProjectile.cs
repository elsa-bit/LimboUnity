using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamProjectile : MonoBehaviour
{
    public float lifeTime = 5f;
    private bool canRotate = true;
    private float rotationFrame = 360 / 10;

    void Start()
    {
        StartCoroutine(LifeTime());
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (
            collision.gameObject.CompareTag("Player")
        ) {
            var playerScript = collision.gameObject.GetComponent<PlayerMove>();
            playerScript.gameManagement.TakeDamage(0.5f);
        }
        DestroyIceCream();
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate) {
            RotateIceCream();
        }
    }

    private void RotateIceCream() {
        canRotate = false;
        var zindex = transform.rotation.eulerAngles.z;
        var newZIndex = (zindex + rotationFrame)% 360;
        transform.rotation = Quaternion.Euler(0,0,newZIndex);
        StartCoroutine(RotationInterval());
    }

    private void DestroyIceCream() {
        // Do hit animation
        Destroy(gameObject);
    }

    IEnumerator RotationInterval() {
        yield return new WaitForSeconds(0.05f);
        canRotate = true;
    }

    IEnumerator LifeTime() {
        yield return new WaitForSeconds(lifeTime);
        DestroyIceCream();
    }
}
