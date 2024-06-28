using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider energySlider;
    public Slider hpSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energySlider.value = GameManager.Instance.currentGold;
        energySlider.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = GameManager.Instance.currentGold.ToString();
        hpSlider.value = GameManager.Instance.currentHP;
        hpSlider.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = GameManager.Instance.currentHP.ToString();
    }
}
