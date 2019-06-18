using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace PvZInitial
{
  public class Singleton<T> : MonoBehaviour where T : Singleton<T>
  {
    /*
    This is required in every script that inherits from Singleton for it to work properly:

    :: First, Inherit from Singleton class like so,
    public class YOURTYPE : Singleton<YOURTYPE> {}

    :: Second, include this variable so you can access the instance of your singleton.
    public static YOURTYPE Instance {
      get {
        return ((YOURTYPE)mInstance);
      } set {
        mInstance = value;
      }
    }

    :: Third, Voila! Now you can access the instance of your singleton with YOURTYPE.Instance
    */

    public virtual void Awake()
    {
      if (mInstance != null)
      {
        CheckDuplicates();
      }
    }
    static void CheckDuplicates()
    {
      T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];
      /// If there are MORE than ONE singleton... hey! That's wrong!
      if (managers.Length > 1 && mInstance != null)
      {
        //Debug.Log("You have more than one " + typeof(T).Name + " in the scene. You only need 1, it's a singleton!");

        //_mInstance.gameObject.name = typeof(T).Name;

        foreach (T manager in managers)
        {
          /// We destroy the others
          if (manager != _mInstance)
          {
            //Debug.Log("Destroying singleton persistent manager: " + manager.gameObject.name);
            Destroy(manager.gameObject);
          }
          else
          {
            /// And use the instance as the one
            _mInstance = manager;
            DontDestroyOnLoad(_mInstance.gameObject);
          }
        }
      }
    }


    protected static Singleton<T> mInstance
    {
      get
      {
        /// If we don't have a singleton yet...
        if (!_mInstance)
        {
          T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];

          if (managers.Length > 0)
          {
            /// We get the first one as the main singleton (we have no other
            /// way to choose it!)
            _mInstance = managers[0];

            // Debug.Log("Setting singleton persistent manager: " + _mInstance.gameObject.name + " for type " + typeof(T).ToString());
            DontDestroyOnLoad(_mInstance.gameObject);

            GameObject singletonParent = GameObject.Find("PERSISTENT_SINGLETON");
            if (singletonParent == null)
            {

              //Debug.Log("Creating parent gameobject for holding all singletons in the DontDestroyOnLoad");
              singletonParent = new GameObject("PERSISTENT_SINGLETON");
            }
            DontDestroyOnLoad(singletonParent);

            _mInstance.gameObject.transform.parent
              = singletonParent.transform;
          }

          /*
          if (managers.Length == 1)
          {
            /// When there is only one
            _mInstance = managers[0];
            Debug.Log("Setting manager: " + _mInstance.gameObject.name + " for type " + typeof(T).ToString());
            DontDestroyOnLoad(_mInstance.gameObject);

            GameObject singletonParent = GameObject.Find("PERSISTENT_SINGLETON");
            if (singletonParent == null)
            {

              Debug.Log("Creating parent gameobject for holding all singletons in the DontDestroyOnLoad");
              singletonParent = new GameObject("PERSISTENT_SINGLETON");
              DontDestroyOnLoad(singletonParent);

              _mInstance.gameObject.transform.parent
                = singletonParent.transform;
            }


            /// It is our singleton!
            return _mInstance;
          }
          else
          {
            //CheckDuplicates();

            Debug.Log("You have more than one " + typeof(T).Name + " in the scene. You only need 1, it's a singleton!");

            _mInstance = managers[0];
          }
        }

        //GameObject gO = new GameObject(typeof(T).Name, typeof(T));
        //_mInstance = gO.GetComponent<T>();
        //DontDestroyOnLoad(gO);
        */

        }
        return _mInstance;
      }
      set
      {
        _mInstance = value as T;
      }
    }
    private static T _mInstance;
  }
}