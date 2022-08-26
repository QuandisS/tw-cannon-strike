using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceSystem : Singleton<ResourceSystem>
{
    private GameObject _cannonballPrefab;
    private const string CannonballPath = "Cannonball";
    private const string LevelsPath = "Levels";
    private List<Level> _levels;

    public int LevelCount => _levels.Count;
    
    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        _cannonballPrefab = Resources.Load<GameObject>(CannonballPath);
        _levels = Resources.LoadAll<Level>(LevelsPath).ToList();
    }

    public GameObject GetCannonballPrefab() => _cannonballPrefab;
    
    public Level GetLevel(int levelNum)
    {
        return _levels.Where(l => l.levelNum == levelNum).ToList()[0];
    }
}
