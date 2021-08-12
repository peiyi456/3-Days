using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _BattleHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] _HPBar hpBar;

    _Units _units;

    public void SetData(_Units units)
    {
        _units = units;

        nameText.text = units.Base.Name;
        hpBar.SetHP((float) units.HP / units.MaxHP);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_units.HP / _units.MaxHP);
    }
}
