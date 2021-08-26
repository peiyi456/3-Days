using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightColor;

    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actionText;
    [SerializeField] List<Image> actionTextBorder;
    [SerializeField] List<TextMeshProUGUI> moveText;

    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI efficiencyText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";

        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        yield return new WaitForSeconds(1f);
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled; 
    }
    
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled); 
    }
    
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled); 
        moveDetails.SetActive(enabled); 
    }

    public void UpadateActionSelection(int selectedAction)
    {
        for(int i = 0; i < actionText.Count; i++)
        {
            if(i == selectedAction)
            {
                actionText[i].color = highlightColor;
                actionTextBorder[i].color = new Color(255,255,255,255);
            }

            else
            {
                actionText[i].color = Color.black;
                actionTextBorder[i].color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void UpdateMoveSelection(int selectedMove, _Move move)
    {
        for(int i = 0; i < moveText.Count; i++)
        {
            if(i == selectedMove)
            {
                moveText[i].color = highlightColor;
            }

            else
            {
                moveText[i].color = Color.black;
            }

            damageText.text = $"Damage: { move.Base.Power}";
            efficiencyText.text = $"Accuracy: { move.Base.Accuracy.ToString()}";
        }
    }

    public void SetMoveNames(List<_Move> moves)
    {
        for (int i = 0; i < moveText.Count; i++)
        {
            if(i < moves.Count)
            {
                moveText[i].text = moves[i].Base.MoveName;
            }

            else
            {
                moveText[i].text = "-";
            }
        }
    }
}
