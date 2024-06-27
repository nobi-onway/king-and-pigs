using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{   
    public List<Transform> _listPositionEnemy;   
    public Transform _positionPlayer;

   
    public void OnActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    private void SetPositionPlayer(GameObject playerPrefabs)
    {
        playerPrefabs.transform.position = _positionPlayer.position;
    }

    private void SetPositionEnemy(List<GameObject> listEnemyPrefabs)
    {
        for(int i = 0; i< listEnemyPrefabs.Count; i++)
        {
            if (i > _listPositionEnemy.Count) return;
            listEnemyPrefabs[i].transform.position = _listPositionEnemy[i].position;
        }
    }
    
    public void SettingMap(GameObject playerPrefabs, List<GameObject> listEnemyPrefabs)
    {
        StartCoroutine(SetMapPosition(playerPrefabs, listEnemyPrefabs));
    }

    IEnumerator SetMapPosition(GameObject playerPrefabs, List<GameObject> listEnemyPrefabs)
    {
        SetPositionPlayer(playerPrefabs);
        SetPositionEnemy(listEnemyPrefabs);
        yield return new WaitForSeconds(1);
        OnActive(true);
    }
}
