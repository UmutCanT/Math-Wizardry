using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;   
    [SerializeField] Button button;
    //0-Frame, 1-Mask, 2-Fill, 3-Case
    [SerializeField] Image[] images;

    Character character;
    int i = 0;


    public void SetMaxMana (float totalMana)
    {
        slider.maxValue = totalMana;
        button.interactable = false;
    }

    public void SetMana (float mana)
    {
        slider.value = mana;
        images[2].color = gradient.Evaluate(slider.normalizedValue);

        if (slider.value == slider.maxValue)
        {
            button.interactable = true;
        }
    }

    public void ChangeButtonInteraction(bool isInteractable)
    {
        button.interactable = isInteractable;
    }

    public void Initialize(Character selectedCharacter)
    {
        character = selectedCharacter;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = character.CharacterUI[i];
        }
     
        gradient = character.MagicColor;
    }

    public void Ultimate()
    {       
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().CanHeal())
        {
            AudioManager.Instance.PlaySound(SoundType.Heal);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>().ResetMana();
            button.interactable = false;
        }        
    }
}
