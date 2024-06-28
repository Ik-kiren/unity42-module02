using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideBar : MonoBehaviour
{
    Slider slideBar;
    public TMP_Text text;
    void Start()
    {
        slideBar = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        slideBar.value = GameManager.Instance.currentHP;
    }
}
