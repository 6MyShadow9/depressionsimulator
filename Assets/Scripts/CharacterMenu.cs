using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    // logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // character selection
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection++;

            // if there are no more sprites
            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;
            
            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            // if there are no more sprites
            if(currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count -1;
            
            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {
        // GameManager
    }

    // update character information
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED";

        // meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString() + GameManager.instance.player.maxHitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText.text = "NOT IMPLEMENTED";

        // XPbar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3 (0.5f, 0, 0);
    }

}
