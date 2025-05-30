using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public void ClickPosSound()
    {
        AudioManager.Instance.PlaySFX("clickPos", 1f);
    }

    public void ClickNegSound()
    {
        AudioManager.Instance.PlaySFX("clickNeg", 1f);
    }

    public void ClickBuySound()
    {
        AudioManager.Instance.PlaySFX("clickBuy", 1f);
    }
}
