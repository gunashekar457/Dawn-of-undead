using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    [HideInInspector]
    public static PoolScript instance;

    [SerializeField]
    GameObject enemyPrefab, enemyHolder;
    public List<GameObject> enemyPool;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        enemyPool = new List<GameObject>();
        for(int i = 0;i<50;i++)
        {
            GameObject temp;
            temp = Instantiate(enemyPrefab);
            temp.transform.SetParent(enemyHolder.transform);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
    }

    public GameObject GetEnemy()
    {
        for(int i = 0;i<enemyPool.Count;i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        return null;
    }

}
