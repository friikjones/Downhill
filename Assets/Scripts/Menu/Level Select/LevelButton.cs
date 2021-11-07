using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int[] levelParameters = new int[7];

    public string lvlName;
    public bool unlocked;
    public int starLevel;
    public Sprite completedStar, incompleteStar;

    [SerializeField] private Text lvlName_label;
    [SerializeField] private GameObject locked_icon, star_icons;
    [SerializeField] private Image star1, star2, star3;

    void LateUpdate()
    {
        lvlName_label.text = lvlName;

        if (unlocked)
        {
            star_icons.SetActive(true);
            locked_icon.SetActive(false);
            switch (starLevel)
            {
                case 0:
                    star1.sprite = star2.sprite = star3.sprite = incompleteStar;
                    break;
                case 1:
                    star1.sprite = completedStar;
                    star2.sprite = star3.sprite = incompleteStar;
                    break;
                case 2:
                    star1.sprite = star2.sprite = completedStar;
                    star3.sprite = incompleteStar;
                    break;
                case 3:
                    star1.sprite = star2.sprite = star3.sprite = completedStar;
                    break;
                default:
                    Debug.LogWarning("starlevel out of bounds @ " + this.gameObject.name + "-" + lvlName);
                    star1.sprite = star2.sprite = star3.sprite = incompleteStar;
                    break;
            }
        }
        else
        {
            star_icons.SetActive(false);
            locked_icon.SetActive(true);
        }

    }
}
