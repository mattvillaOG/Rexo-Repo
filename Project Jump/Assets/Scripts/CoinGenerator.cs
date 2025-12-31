using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler collectablePool;

    public float distanceBetweenCollectables;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject collectable1 = collectablePool.GetPooledObject();
        collectable1.transform.position = startPosition;
        collectable1.SetActive(true);

        GameObject collectable2 = collectablePool.GetPooledObject();
        collectable2.transform.position = new Vector3 (startPosition.x - distanceBetweenCollectables, startPosition.y, startPosition.z);
        collectable2.SetActive(true);

        GameObject collectable3 = collectablePool.GetPooledObject();
        collectable3.transform.position = new Vector3(startPosition.x + distanceBetweenCollectables, startPosition.y, startPosition.z);
        collectable3.SetActive(true);

    }


}
