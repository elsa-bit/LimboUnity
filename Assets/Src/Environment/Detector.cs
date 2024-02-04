using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float detectionCheckDelay = 0.1f;
    public GameObject target;
    public bool left;
    public bool top;
    public bool right;
    public bool bottom;
    private bool isDetectingTarget = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DetectTarget() {
        /*var resultLeft = Physics2D.Raycast(transform.position, new Vector2(-1, 0), detectionRadius);
        var resultTop = Physics2D.Raycast(transform.position, new Vector2(0, 1), detectionRadius);
        var resultRight = Physics2D.Raycast(transform.position, new Vector2(1, 0), detectionRadius);
        var resultBottom = Physics2D.Raycast(transform.position, new Vector2(0, -1), detectionRadius);
        if (
            (left && resultLeft.collider != null && resultLeft.collider.gameObject.CompareTag(target.tag)) ||
            (top && resultTop.collider != null && resultTop.collider.gameObject.CompareTag(target.tag)) ||
            (right && resultRight.collider != null && resultRight.collider.gameObject.CompareTag(target.tag)) ||
            (bottom && resultBottom.collider != null && resultBottom.collider.gameObject.CompareTag(target.tag))
        ) {
            isDetectingTarget = true;
        } else {
            isDetectingTarget = false;
        }*/
        
        var result = Physics2D.Raycast(transform.position, target.transform.position - transform.position, detectionRadius);

        if (
            result.collider != null && result.collider.gameObject.CompareTag(target.tag)
        ) {
            isDetectingTarget = true;
        } else {
            isDetectingTarget = false;
        }
    }

    IEnumerator DetectionCoroutine() {
        yield return new WaitForSeconds(detectionCheckDelay);
        //Do something
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }


    public bool DetectorIsDetectingTarget() {
        return isDetectingTarget;
    }

    public Vector2 GetDistance() {
        return transform.position - target.transform.position;
    }
}
