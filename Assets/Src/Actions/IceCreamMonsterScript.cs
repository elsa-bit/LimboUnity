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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot) {
            Shoot();
        }
       
    }

    private void Shoot() {
        canShoot = false;
        StartCoroutine(ShootRate());
        GameObject cream = Instantiate(iceCream, iceCreamSpawn.position, Quaternion.identity);
        cream.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*xOffset, 1*yOffset) * projectileSpeed;
    }

    IEnumerator ShootRate() {
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }
}
