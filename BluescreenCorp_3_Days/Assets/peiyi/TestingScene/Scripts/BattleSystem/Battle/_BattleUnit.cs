using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class _BattleUnit : MonoBehaviour
{
    [SerializeField] _UnitsBase _base;
    //[SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public _Units units { get; set; }

    Image image;
    Vector3 originalPos;
    Color originalColor;

    [SerializeField] float transformSpeed = 0.25f;
    [SerializeField] float fadeSpeed = 0.5f;
    [SerializeField] float colorSpeed = 0.1f;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
    }

    public void Setup()
    {
        if (!isPlayerUnit)
        {
            _base = GameManager.instance.thisAnimal;

            units = new _Units(_base);

            Debug.Log(_base.name);
            //if(isPlayerUnit)
            //{
            //    GetComponent<Image>
            //}

            image.sprite = units.Base.UnitSprite;

            image.color = originalColor;
            PlayEnterAnimation();
        }

        else
        {
            units = new _Units(_base);

            //if(isPlayerUnit)
            //{
            //    GetComponent<Image>
            //}

            image.sprite = units.Base.UnitSprite;

            image.color = originalColor;
            PlayEnterAnimation();
        }
    }

    public void PlayEnterAnimation()
    {
        if (isPlayerUnit)
        {
            image.transform.localPosition = new Vector3(-1200f, originalPos.y);
        }

        else
        {
            image.transform.localPosition = new Vector3(1200f, originalPos.y);
        }

        image.transform.DOLocalMoveX(originalPos.x, 1f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();

        if(isPlayerUnit)
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 150f, transformSpeed));
        }

        else
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 150f, transformSpeed));
        }

        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, transformSpeed));
    }

    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, colorSpeed));
        sequence.Append(image.DOColor(originalColor, colorSpeed));
    }

    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150f, transformSpeed));
        sequence.Join(image.DOFade(0f, fadeSpeed));
    }
}
