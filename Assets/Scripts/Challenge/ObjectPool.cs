using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private List<GameObject> pool;
    private Queue<GameObject> queue;
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

        if (pool.Count < maxSize)
        {
            GameObject obj = CreateObject();
            obj.SetActive(true);
            pool.Add(obj);
            return obj;
        }

        // 1�� �������� (�ӽ÷� ���� �� ��ȯ �� �ı�)

        GameObject newObject = CreateObject();
        newObject.SetActive(true);
        return newObject;

        // 2�� �������� (���� �������� ������ ������Ʈ�� ��ȯ �� ����)

        //queue = new Queue<GameObject>();
        //for (int i = 0; i < minSize; i++)
        //{
        //    queue.Enqueue(CreateObject());
        //}
        //List�� Queue�� ����

        //GameObject newObject = queue.Dequeue();
        //newObject.SetActive(false);
        //queue.Enqueue(newObject);
        //newObject.SetActive(true);
        //return newObject;

        // 3�� ��������
        // (������Ʈ�� �̸� �������� �ʰ� ������ ��� ���� 100������ �߰� ����,
        // 100���� �Ѿ ��� �ӽ÷� ���� �� ��ȯ �� �ı�)

        // minSize = 0; maxSize = 100; �� ����

        //GameObject newObject = CreateObject();
        //newObject.SetActive(true);
        //return newObject;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [�䱸���� 3] Release Object
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