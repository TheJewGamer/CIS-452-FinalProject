using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    //variables
    public Text companion1Text;
    public Text companion2Text;
    public Text companion3Text;
    public Text companion4Text;
    public Text carText;

    void Start()
    {
        //set names
        companion1Text.text = Stats.Companion1Name;
        companion2Text.text = Stats.Companion2Name;
        companion3Text.text = Stats.Companion3Name;
        companion4Text.text = Stats.Companion4Name;
        carText.text = Stats.CarName;

        //set health
    }

    public void updateHealth()
    {

    }
}
