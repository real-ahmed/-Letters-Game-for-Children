using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
namespace q1
{
    public class QuestionController : MonoBehaviour
    {


        public char Letter;

        int _correctAnswers = 5;
        int _correctClicks;

        public static QuestionController Instance;

        public InternalMenu InternalMenu;



        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                LevelManager.LevelQuestion = Instance;
                Letter = LevelManager.SelectedLetter;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void OnEnable()
        {
            GenerateBoard();
            UpdateDiplayLetters();

        }

        void GenerateBoard()
        {
            var clickables = FindObjectsOfType<ClickableLetter>();

            List<char> charsList = new List<char>();

            for (int i = 0; i < _correctAnswers; i++)
                charsList.Add(Letter);

            for (int i = _correctAnswers; i < clickables.Length; i++)
            {
                var chosenLetter = ChooseInvalidRandomLetter();
                charsList.Add(chosenLetter);
            }

            charsList = charsList
                .OrderBy(t => UnityEngine.Random.Range(0, 10000))
                .ToList();

            for (int i = 0; i < clickables.Length; i++)
            {
                clickables[i].SetLetter(charsList[i]);
            }

            FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
        }

        internal void HandleCorrectLetterClick(bool upperCase)
        {


            
            _correctClicks++;
            FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
            if (_correctClicks >= _correctAnswers)
            {

                SaveLoadManager.SaveProgress(SaveLoadManager.LoadProgress() + 1);
                
                InternalMenu.Win();



            }
        }


        private void UpdateDiplayLetters()
        {


            foreach (var displayletter in FindObjectsOfType<DisplayLetter>())
            {
                displayletter.SetLetter(Letter);
            }
            Debug.Log(FindObjectsOfType<DisplayLetter>());
        }

        private char ChooseInvalidRandomLetter()
        {
            int a = UnityEngine.Random.Range(0, 26);
            var randomLetter = (char)('a' + a);
            while (randomLetter == Letter)
            {
                a = UnityEngine.Random.Range(0, 26);
                randomLetter = (char)('a' + a);
            }

            return randomLetter;
        }

        public void Restart()
        {
            UpdateDiplayLetters();
            _correctClicks = 0;
            GenerateBoard();
        }

    }
}