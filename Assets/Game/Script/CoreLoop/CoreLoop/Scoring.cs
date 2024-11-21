using DG.Tweening;
using Game.Character;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.CoreLoop
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private int intervalInSeconds = 3;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        private CoreLoopController coreLoopController;

        [SerializeField] private Image redImagePoint;
        [SerializeField] private Image blueImagePoint;

        ScoreRules scoreRules;
        private static int ColorMaskID => Shader.PropertyToID("_ColorMask");
        private void Awake()
        {
            scoreRules = FindObjectOfType<ScoreRules>();
            coreLoopController = GetComponentInParent<CoreLoopController>();
            redImagePoint.material.DOFloat(0, ColorMaskID, 0);
            blueImagePoint.material.DOFloat(0, ColorMaskID, 0);
            HidePointImages();
        }



        public void SkillScoringStateDealyed()
        {
            StartCoroutine(WaitForSkipState());

        }



        private IEnumerator WaitForSkipState()
        {

            yield return new WaitForSecondsRealtime(intervalInSeconds);
            coreLoopController.NextStep();
        }

        public void ShowPointImage()
        {
            TEAM team = scoreRules.LastTeamMarkedPoint;
            Image currentImage = team == TEAM.Red ? redImagePoint : blueImagePoint;
            currentImage.enabled = true;
            currentImage.transform.localScale = Vector3.one * 0.5f;
            currentImage.transform.DOScale(1, 1).SetEase(Ease.OutCubic).SetUpdate(true);
            currentImage.material.DOFloat(0, ColorMaskID, 0).SetUpdate(true);
            currentImage.material.DOFloat(15, ColorMaskID, 0.7f).SetUpdate(true);

        }

        public void HidePointImages()
        {
            redImagePoint.enabled = false;
            blueImagePoint.enabled = false;
        }


    }

}
