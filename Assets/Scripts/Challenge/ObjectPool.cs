using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
    }

    private GameObject CreateObject()
    {
        // [�䱸���� 1] Create Object
        GameObject obj = Instantiate(objectPrefab, this.transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        // [�䱸���� 2] Get Object
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(true);  // �ٷ� Ȱ��ȭ ���·� ���
        pool.Add(newObj);
        return newObj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [�䱸���� 3] Release Object
        obj.SetActive(false);
    }
}