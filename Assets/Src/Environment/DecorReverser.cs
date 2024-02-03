using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorReverser : MonoBehaviour
{
    private bool _isReverse = false;
    private Quaternion _targetRotation, _playerRotation;
    private bool _isRotating = false;
    
    public void ReverseDecor(GameObject player)
    {
        _targetRotation = Quaternion.Euler(0, 0, (_isReverse) ? 0 : -90);
        _playerRotation = Quaternion.Euler(0, 0, -180); // 0 if gravity normal
        _isReverse = !_isReverse;
        if (!_isRotating)
        {
            StartCoroutine(RotateOverTime(4, player));
        }
    }

    private IEnumerator RotateOverTime(float duration, GameObject player)
    {
        _isRotating = true;
        Quaternion startRotation = transform.rotation;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / duration;
            transform.rotation = Quaternion.Lerp(startRotation, _targetRotation, normalizedTime);
            player.transform.rotation = Quaternion.Lerp(startRotation, _playerRotation, normalizedTime);
            yield return null;
        }

        transform.rotation = _targetRotation;
        player.transform.rotation  = _playerRotation;

        _isRotating = false;
    }
}
