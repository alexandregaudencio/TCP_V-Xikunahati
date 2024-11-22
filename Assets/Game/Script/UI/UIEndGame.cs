using DG.Tweening;
using Game;
using Game.Character;
using Team;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEndGame : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] private Image backgroundTittle;
    [SerializeField] private TMP_Text winnerTeamText;
    [SerializeField] private Image winnerTeamImage;
    GameStateController GameStateController;
    [SerializeField] private GameObject vitoriaText;

    [SerializeField] private Score redScore;
    [SerializeField] private Score blueScore;

    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    private RectTransform rectTransform;
    [SerializeField] private TMP_Text f1Text;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        GameStateController = FindObjectOfType<GameStateController>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        GameStateController.StateChange += OnStateChange;
        rectTransform.position += Vector3.up * 1200;
        f1Text.DOFade(0, 0);
    }

    private void OnDestroy()
    {
        GameStateController.StateChange -= OnStateChange;

    }


    private void OnStateChange(GameState state)
    {
        if (state == GameState.ENDGAME) UpdateUiEvents();

    }

    public void UpdateUiEvents()
    {

        TEAM team = blueScore.TeamScore > redScore.TeamScore ? TEAM.Blue : blueScore.TeamScore < redScore.TeamScore ? TEAM.Red : TEAM.NONE;
        UpdateText(team);

        winnerTeamImage.material.DOFloat(1, Shader.PropertyToID("_Cutoff"), 0);
        backgroundTittle.material.DOFloat(1, Shader.PropertyToID("_Cutoff"), 0);

        //rectTransform.DOScale(2, 0);
        rectTransform.DOLocalMoveY(0, 1).SetDelay(1).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(() =>
        {
            backgroundTittle.material.DOFloat(0.8f, Shader.PropertyToID("_Cutoff"), 10).SetUpdate(true);


            winnerTeamText.DOFade(1, 2).SetUpdate(true);

            winnerTeamImage.material.DOFloat(0.75f, Shader.PropertyToID("_Cutoff"), 4).SetUpdate(true);


        });

        f1Text.DOFade(1, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(true).SetDelay(6);


    }


    private void UpdateText(TEAM team)
    {
        if (team == TEAM.Blue)
        {
            winnerTeamText.SetText("azul");
            winnerTeamImage.color = blue;

        }

        else if (team == TEAM.Red)
        {
            winnerTeamText.SetText("vermelho");
            winnerTeamImage.color = red;
        }
        else
        {
            winnerTeamText.SetText("empate");
            vitoriaText.SetActive(false);

        }



    }


}