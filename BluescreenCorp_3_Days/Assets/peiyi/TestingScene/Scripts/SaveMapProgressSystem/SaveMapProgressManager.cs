using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMapProgressManager : MonoBehaviour
{
    public static int selectedMap;

    public static int unlockMapNo;

    public static int badgeUnlock_Map1;
    public static int badgeUnlock_Map2;

    string UnLockMap = "UNLOCK_MAP";
    string MapBadge_Lvl1 = "BADGE_UNLOCK_MAP1";
    string MapBadge_Lvl2 = "BADGE_UNLOCK_MAP2";

    // Start is called before the first frame update
    void Start()
    {
        unlockMapNo = PlayerPrefs.GetInt(UnLockMap, 0);
        badgeUnlock_Map1 = PlayerPrefs.GetInt(MapBadge_Lvl1, 0);
        badgeUnlock_Map2 = PlayerPrefs.GetInt(MapBadge_Lvl2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
