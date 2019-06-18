using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace PvZInitial
{
  public class SingletonScene<T> : MonoBehaviour where T : SingletonScene<T>
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

    private void Awake()
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
        Debug.Log("You have more than one " + typeof(T).Name + "singleton scene in the scene. You only need 1, it's a singleton!");

        //_mInstance.gameObject.name = typeof(T).Name;

        foreach (T manager in managers)
        {
          /// We destroy the others
          if (manager != _mInstance)
          {
            Debug.Log("Destroying manager: " + manager.gameObject.name);
            Destroy(manager.gameObject);
          }
          else
          {
            /// And use the instance as the one
            _mInstance = manager;
          }
        }
      }
    }


    protected static SingletonScene<T> mInstance
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

            Debug.Log("Setting singleton scene manager: " + _mInstance.gameObject.name + " for type " + typeof(T).ToString());
          }
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