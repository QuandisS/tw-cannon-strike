using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private bool _isScored = false;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D()
    {
        if (_isScored) return;

        _isScored = true;
        ScoreSystem.Instance.AddOneScored();        
    }
}