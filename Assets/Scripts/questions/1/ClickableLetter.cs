using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
namespace q1
{
    public class ClickableLetter : MonoBehaviour, IPointerClickHandler
    {
        char _randomLetter;
        bool _upperCase;
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Clicked on letter {_randomLetter}");
            if (_randomLetter == QuestionController.Instance.Letter)
            {
                AudioManager.instance.PlaySFX("Right");
                GetComponent<TMP_Text>().color = Color.green;
                enabled = false;
                QuestionController.Instance.HandleCorrectLetterClick(_upperCase);

            }
            else
            {
                AudioManager.instance.PlaySFX("Wrong");
            }
        }

        public void SetLetter(char letter)
        {
            enabled = true;
            GetComponent<TMP_Text>().color = Color.white;
            _randomLetter = letter;

            if (Random.Range(0, 100) > 50)
            {
                _upperCase = false;
                GetComponent<TMP_Text>().text = _randomLetter.ToString();
            }
            else
            {
                _upperCase = true;
                GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
            }
        }
    }
}