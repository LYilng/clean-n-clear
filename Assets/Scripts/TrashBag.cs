using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TrashBag : MonoBehaviour
{
    public static TrashBag instance;

    [SerializeField] private int objectsDestroyed = 0;
    [SerializeField] private int maxObjectsDestroy = 2;
    [SerializeField] public float cooldown = 1.5f;
    public float lastDestructionTime;

    public SpaceIndicator spaceIndicator;
    public TrashbagCooldown cdManager;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        spaceIndicator.SetStartingText(objectsDestroyed);
        lastDestructionTime = -cooldown;
    }
    /*
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
    }*/

    public void UpdateUI()
    {
        addTrash(1);

        if (objectsDestroyed >= maxObjectsDestroy)
        {
            Debug.Log("Trash Bag: Self-destructing");
            Destroy(gameObject);
        }

        lastDestructionTime = Time.time;

        cdManager.gameObject.SetActive(true);
        cdManager.StartCooldown();
    }

    void addTrash(int trash)
    {
        objectsDestroyed += trash;
        spaceIndicator.SetSpace(objectsDestroyed);
        Debug.Log("TRASHHH");
    }
}
