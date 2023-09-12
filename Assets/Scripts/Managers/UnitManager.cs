using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _checkers;

    private void Awake()
    {
        Instance = this;

        _checkers = Resources.LoadAll<ScriptableUnit>("Checkers").ToList();
    }

    public void SpawnWhite()
    {
        for (int i = 0; i<12; i++)
        {
            
            //var spawnedChecker = Instantiate((WhiteChecker)_checkers.Where(c => c.faction == Faction.White).First().CheckerPrefab);
            var spawnedChecker = Instantiate(GetColoredChecker<BaseChecker>(Faction.White));
            var spawnTile = GridManager.Instance.GetCheckersSpawnTile(Faction.White);

            spawnTile.SetChecker(spawnedChecker);
        }

        GameManager.Instance.ChangeGameState(GameState.SpawnBlack);
    }

    public void SpawnBlack()
    {
        for (int i = 0; i < 12; i++)
        {

            //var spawnedChecker = Instantiate((WhiteChecker)_checkers.Where(c => c.faction == Faction.White).First().CheckerPrefab);
            var spawnedChecker = Instantiate(GetColoredChecker<BaseChecker>(Faction.Black));
            var spawnTile = GridManager.Instance.GetCheckersSpawnTile(Faction.Black);

            spawnTile.SetChecker(spawnedChecker);
        }
    }

    private T GetColoredChecker<T>(Faction faction) where T : BaseChecker
    {
        return (T)_checkers.Where(c => c.faction == faction).First().CheckerPrefab;
    }
}
