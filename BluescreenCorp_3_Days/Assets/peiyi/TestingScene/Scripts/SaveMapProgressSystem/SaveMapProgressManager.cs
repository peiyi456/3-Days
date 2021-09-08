using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMapProgressManager : MonoBehaviour
{
    public static int selectedMap;

    public static int unlockMapNo;
    string UnLockMap = "UNLOCK_MAP";

    // Start is called before the first frame update
    void Start()
    {
        unlockMapNo = PlayerPrefs.GetInt(UnLockMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
