using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // get instance of singleton
            if(instance == null)
            {
                instance = new Singleton<T>();
                //Singleton<T>
                //Singleton
                //T
            }

            return instance;
        }
    }

    public void Awake()
    {
        // make it as dontdestroyobject
        DontDestroyOnLoad(this);
    }
}