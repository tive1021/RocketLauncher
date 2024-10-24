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
        // [요구스펙 1] Create Object
        GameObject obj = Instantiate(objectPrefab, this.transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if (pool.Count < maxSize)
        {
            GameObject obj = CreateObject();
            obj.SetActive(true);
            pool.Add(obj);
            return obj;
        }

        // 1번 구현사항 (임시로 생성 후 반환 시 파괴)
        //GameObject gameObject = CreateObject();
        //gameObject.SetActive(true);
        //return gameObject;

        // 2번 구현사항 (가장 오래전에 생성된 오브젝트를 반환 후 재사용)

        // 3번 구현사항
        // (오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성,
        // 100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴)
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        if(pool.Contains(obj))
        {
            obj.SetActive(false);
        }
        else
        {
            Destroy(obj);
        }
    }
}