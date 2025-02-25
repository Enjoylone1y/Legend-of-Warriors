using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Image hpBar;
    public Image powerBar;

    public void onHpChange(float percent)
    {
        hpBar.fillAmount = percent;
    }
}
