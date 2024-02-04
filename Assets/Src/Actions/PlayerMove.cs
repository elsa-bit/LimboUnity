using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 9.0f;
    public Animator animator;
    public float shotSpeed = 0.4f;
    public float projectileSpeed = 10f;
    public Transform rightSpawn;
    public Transform leftSpawn;
    public GameManagement gameManagement;
    private bool IsCollidingWithOrbe = false;
    private Vector3 _initialPosition;
    private bool canShoot = true;
    private bool isFacingRight = true;
    private bool _isGravityNormal = true;
    public bool IsGravityNormal
    {
        get => _isGravityNormal;
    }

    void Start()
    {
        _initialPosition = transform.position;
    }

    public void ToLeft()
    {
        isFacingRight = false;
        Vector3 position = transform.position;
        position.x -= speed * Time.deltaTime;
        if (!_isGravityNormal)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else
        {
            animator.SetFloat("Horizontal", -1f);
        }
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToRight()
    {
        isFacingRight = true;
        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        if (_isGravityNormal)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else
        {
            animator.SetFloat("Horizontal", -1f);
        }
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToUp()
    {
        Vector3 position = transform.position;
        if (_isGravityNormal)
        {
            position.y += speed * Time.deltaTime;
        }
        else
        {
            position.y -= speed * Time.deltaTime;
        }
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 1f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ReverseGravity()
    {
        var rotation = transform.rotation;
        if (_isGravityNormal)
        {
            Physics2D.gravity = new Vector2(0, 9.8f);
            rotation.z = 180;
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
            rotation.z = 0;
        }

        transform.rotation = rotation;
        _isGravityNormal = !_isGravityNormal;
    }

    public void Stop()
    {
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
        animator.SetFloat("Speed", 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Orbe")) {
            IsCollidingWithOrbe = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Orbe")) {
            IsCollidingWithOrbe = false;
        }
    }

    public void Shoot() {
        GameObject shot = gameManagement.currentOrbe;

        if (IsCollidingWithOrbe) {
            GameObject orbe = GameObject.FindGameObjectWithTag("Orbe");

            //UpdateOrbe(orbe);
        }

        if(canShoot && shot != null) {
            canShoot = false;
            StartCoroutine(ShootRate());
            int shotDirection = 1;
            Transform selectedSpawn = rightSpawn;
            if (!isFacingRight) {
                shotDirection = -1;
                selectedSpawn = leftSpawn;
            }
            GameObject o = Instantiate(shot, selectedSpawn.position, Quaternion.identity);
            
            //Debug.Log(transform.localScale.x);
            o.GetComponent<Rigidbody2D>().velocity = new Vector2(shotDirection, 0) * projectileSpeed;
            //Debug.Log(distance);
        }
    }

    private void UpdateOrbe(GameObject orbe) {
        GameObject previousOrbe = gameManagement.currentOrbe;
        gameManagement.currentOrbe = Instantiate(Resources.Load(orbe.name)) as GameObject;
        Vector2 pos = orbe.transform.position;
        if (previousOrbe != null) {
            // Replace taken orbe by previous one
            Instantiate(previousOrbe, pos, Quaternion.identity);
        }
        Destroy(orbe);
    }

    IEnumerator ShootRate() {
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }
}
