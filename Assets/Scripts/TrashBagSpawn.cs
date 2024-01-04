using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBagSpawn : MonoBehaviour
{
    public GameObject trashBagPrefab;
    private int trashBagsSpawned = 0;
    private int maxTrashBag = 1;



    public void SpawnTrashBag()
    {
        if (trashBagsSpawned < maxTrashBag)
        {
            Instantiate(trashBagPrefab, new Vector3(10,0,0), Quaternion.identity);
            trashBagsSpawned++;
        }
    }
}
