using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapProgressManager : MonoBehaviour
{
    public static int selectedMap;

    public static int unlockMapNo;

    public static int badgeUnlock_Map1;
    public static int badgeUnlock_Map2;

    string UnLockMap = "UNLOCK_MAP";
    string MapBadge_Lvl1 = "BADGE_UNLOCK_MAP1";
    string MapBadge_Lvl2 = "BADGE_UNLOCK_MAP2";

    [SerializeField] Button lvl2Button;

    [SerializeField] Image lvl1Badge;
    [SerializeField] Image lvl2Badge;

    [SerializeField] Sprite Bronze, Silver, Gold;

    // Start is called before the first frame update
    void Start()
    {
        unlockMapNo = PlayerPrefs.GetInt(UnLockMap, 0);
        badgeUnlock_Map1 = PlayerPrefs.GetInt(MapBadge_Lvl1, 0);
        badgeUnlock_Map2 = PlayerPrefs.GetInt(MapBadge_Lvl2, 0);
        Debug.Log(unlockMapNo);
        Debug.Log(badgeUnlock_Map1);
    }

    // Update is called once per frame
    void Update()
    {
        if(unlockMapNo == 1)
        {
            lvl2Button.interactable = true;
        }

        if(badgeUnlock_Map1 == 0)
        {
            lvl1Badge.color = new Color(255f, 255f, 255f, 0) ;
        }

        else if(badgeUnlock_Map1 == 1)
        {
            lvl1Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl1Badge.sprite = Bronze;
        }

        else if (badgeUnlock_Map1 == 2)
        {
            lvl1Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl1Badge.sprite = Silver;
        }

        else if (badgeUnlock_Map1 == 3)
        {
            lvl1Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl1Badge.sprite = Gold;
        }

        if (badgeUnlock_Map2 == 0)
        {
            lvl2Badge.color = new Color(255f, 255f, 255f, 0);
        }

        else if (badgeUnlock_Map2 == 1)
        {
            lvl2Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl2Badge.sprite = Bronze;
        }

        else if (badgeUnlock_Map2 == 2)
        {
            lvl2Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl2Badge.sprite = Silver;
        }

        else if (badgeUnlock_Map2 == 3)
        {
            lvl2Badge.color = new Color(255f, 255f, 255f, 255f);
            lvl2Badge.sprite = Gold;
        }
    }
}
