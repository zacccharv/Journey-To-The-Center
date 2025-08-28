using TMPro;
using UnityEngine;

public class EarthDataText : MonoBehaviour
{
    public TextMeshProUGUI earthHealthText;
    public void UpdateText()
    {
        earthHealthText.text = "<color=#FFE2B8><b>## EARTH INFO:</b></color>\n" +
                               "<color=#FFE2B8>Earth Health:</color> " + EarthData.instance.earthHealth + "%\n" +
                               "<color=#FFE2B8>Explosiveness:</color> " + EarthData.instance.explosiveness + "%";
    }
}

