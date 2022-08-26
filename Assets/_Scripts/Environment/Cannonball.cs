using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public static string InactiveCannonballTag = "Inactive Cannonball";
    public static string ActiveCannonballTag = "Active Cannonball";

    private bool _isScored = false;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D()
    {
        if (_isScored) return;

        _isScored = true;
        gameObject.tag = InactiveCannonballTag;
        ScoreSystem.Instance.AddOneScored();        
    }
}