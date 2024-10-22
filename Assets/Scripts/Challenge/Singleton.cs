using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // get instance of singleton
            if (instance == null)
            {
                Init();
            }

            return instance;
        }
    }

    public virtual void Awake()
    {
        Init();
        // make it as dontdestroyobject
    }

    public static void Init()
    {
        // ���� ó�� - Ȥ�� ���� �̱����� �ִ���
        instance = (T)FindObjectOfType(typeof(T));
        if (instance == null)
        {
            string tName = typeof(T).ToString();
            var singletonObj = new GameObject(tName);
            instance = singletonObj.AddComponent<T>();

            DontDestroyOnLoad(instance);
        }
    }
}