using System.Collections.Generic;
using UnityEngine;

public class CannonballPooler : Singleton<CannonballPooler>
{
    private Queue<GameObject> _cannonBallQueue = new Queue<GameObject>();
    private GameObject _cannonBallPrefab;

    public bool IsAnyBallAvailable => _cannonBallQueue.Count > 0;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start() 
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
        _cannonBallPrefab = ResourceSystem.Instance.GetCannonballPrefab();
    }

    private void HandleGameStateChanged(GameState state)
    {
        if (state != GameState.LevelLoaded) return;

        var ballCount = ResourceSystem.Instance
            .GetLevel(GameManager.Instance.CurrentLevelNum).ballsAvailable;
        
        InitPool(ballCount);
    }

    public void InitPool(int cannonBallCount)
    {
        _cannonBallQueue.Clear();
        
        for (int i = 0; i < cannonBallCount; i++)
        {
            var obj = Instantiate<GameObject>(_cannonBallPrefab);
            obj.SetActive(false);
            _cannonBallQueue.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool(Vector3 position)
    {   
        if (_cannonBallQueue.Count == 0) return null;

        var objToSpawn = _cannonBallQueue.Dequeue();
        objToSpawn.transform.position = (Vector3)position;
        objToSpawn.SetActive(true);        
        return objToSpawn;
    }
}
