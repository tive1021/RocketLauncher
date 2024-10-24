using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour
{
    ObjectPool objectPool;
    List<GameObject> gameObj = new List<GameObject>();

    private void Awake()
    {
        objectPool = (ObjectPool) FindObjectOfType(typeof(ObjectPool));
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        while (true)
        {
            StartCoroutine(CreateAndReturnObject());
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {        
    }

    IEnumerator CreateAndReturnObject()
    {
        GameObject obj = objectPool.GetObject();
        obj.transform.position = new Vector2(Random.Range(-20, 20), Random.Range(20, 40));
        gameObj.Add(obj);
        yield return new WaitForSeconds(3f);
        objectPool.ReleaseObject(obj);
        gameObj.Remove(obj);
    }
}
