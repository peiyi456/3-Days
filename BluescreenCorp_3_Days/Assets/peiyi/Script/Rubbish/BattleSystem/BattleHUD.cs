using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AnimalNameText;
    //[SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] HPBar AnimalHpBar;

    [SerializeField] TextMeshProUGUI PlayerNameText;
    //[SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] HPBar PlayerHpBar;

    Animal _animal;

    //[SerializeField] TextMeshProUGUI NameText;
    //[SerializeField] HPBar HpBar;

    public void AnimalSetData(Animal animal)
    {
        _animal = animal;

        AnimalNameText.text = animal.Base.Name;
        AnimalHpBar.SetHP((float)animal.HP / animal.Base.MaxHP);
    }

    public void PlayerSetData(Player player)
    {
        PlayerNameText.text = player.Base.Name;
        PlayerHpBar.SetHP((float)player.HP / player.Base.MaxHP);
    }

    public IEnumerator UpdateHP()
    {
        yield return AnimalHpBar.SetHPSmooth((float)_animal.HP / _animal.Base.MaxHP);
    }

    //public void SetData(Units units)
    //{
    //    NameText.text = units.Base.Name;
    //    HpBar.SetHP((float)units.HP / units.Base.MaxHP);
    //}

}
