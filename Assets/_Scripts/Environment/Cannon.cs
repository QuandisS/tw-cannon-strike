using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _cannonBallSpawnpoint;
    
    [Range(1,10)]
    [SerializeField]
    private float _shotForce;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) 
            && GameManager.Instance.State == GameState.LevelLoaded) Shot();
    }

    private void Shot()
    {
        if (!CannonballPooler.Instance.IsAnyBallAvailable) return;

        ScoreSystem.Instance.SubstractOneAvailable();
        var direction = ((Vector2)_cannonBallSpawnpoint.localPosition).normalized;
        var cannonball = CannonballPooler.Instance
            .SpawnFromPool(_cannonBallSpawnpoint.position);
        cannonball.GetComponent<Rigidbody2D>().AddForce(direction * _shotForce, ForceMode2D.Impulse);    
    }
}
