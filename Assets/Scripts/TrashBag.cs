using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBag : MonoBehaviour
{
    [SerializeField] private int objectsDestroyed = 0;
    [SerializeField] private int maxObjectsDestroy = 2;
    [SerializeField] private float cooldown = 1.5f;
    private float lastDestructionTime;

    public SpaceIndicator spaceIndicator;
    public TrashbagCooldown cdManager;

    void Start()
    {
        spaceIndicator.SetStartingText(objectsDestroyed);
        lastDestructionTime = -cooldown;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object") && Time.time - lastDestructionTime >= cooldown)
        {
            Debug.Log("Trash Bag DESTORYED an object :>");
            Destroy(other.gameObject);

            addTrash(1);

            if(objectsDestroyed >= maxObjectsDestroy)
            {
                Debug.Log("Trash Bag: Self-destructing");
                Destroy(gameObject);
            }

            lastDestructionTime = Time.time;

            cdManager.gameObject.SetActive(true);
            cdManager.StartCooldown();
        }
    }

    void addTrash(int trash)
    {
        objectsDestroyed += trash;
        spaceIndicator.SetSpace(objectsDestroyed);
        Debug.Log("TRASHHH");
    }
}
