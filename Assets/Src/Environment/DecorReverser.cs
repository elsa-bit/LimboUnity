using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorReverser : MonoBehaviour
{
    private bool _isReverse = false;
    private Quaternion _targetRotation;
    private bool _isRotating = false;
    
    public void ReverseDecor()
    {
        _targetRotation = Quaternion.Euler(0, 0, (_isReverse) ? 0 : -90);
        _isReverse = !_isReverse;
        if (!_isRotating)
        {
            StartCoroutine(RotateOverTime(5));
        }
    }

    private IEnumerator RotateOverTime(float duration)
    {
        _isRotating = true;
        Quaternion startRotation = transform.rotation;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / duration;
            transform.rotation = Quaternion.Lerp(startRotation, _targetRotation, normalizedTime);
            yield return null;
        }

        transform.rotation = _targetRotation;
        _isRotating = false;
    }
}
