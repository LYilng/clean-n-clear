using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBag : MonoBehaviour
{
    [SerializeField] private int objectsDestroyed = 0;
    [SerializeField] private int maxObjectsDestroy = 2;
    public SpaceIndicator spaceIndicator;

    void Start()
    {
        spaceIndicator.SetStartingSpace(maxObjectsDestroy);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            Debug.Log("Trash Bag DESTORYED an object :>");
            Destroy(other.gameObject);

            addTrash(1);

            if(objectsDestroyed >= maxObjectsDestroy)
            {
                Debug.Log("Trash Bag: Self-destructing");
                Destroy(gameObject);
            }
        }
    }

    void addTrash(int trash)
    {
        objectsDestroyed += trash;
        spaceIndicator.SetSpace(objectsDestroyed);
        Debug.Log("TRASHHH");
    }
}
