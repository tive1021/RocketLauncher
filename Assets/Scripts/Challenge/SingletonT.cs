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
                // ���� ó�� - Ȥ�� ���� �̱����� �ִ���
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    string tName = typeof(T).ToString();
                    var singletonObj = new GameObject(tName);
                    instance = singletonObj.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    public void Awake()
    {
        // make it as dontdestroyobject
        DontDestroyOnLoad(instance);
    }
}