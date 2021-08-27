using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _BattleHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] _HPBar hpBar;

    _Units _units;

    [SerializeField] Slider playerHP;

    public void SetData(_Units units)
    {
        _units = units;

        nameText.text = units.Base.Name;
        if (_units.UnitTypes != UnitTypes.Player)
        {
            hpBar.SetHP((float)units.HP / units.MaxHP);
        }
        else
        {
            _units.HP = (int)playerHP.value;
            hpBar.SetHP((float)playerHP.value / playerHP.maxValue);
        }
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_units.HP / _units.MaxHP);
    }
}
