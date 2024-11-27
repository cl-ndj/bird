using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public enum Game_Status
    {
        Ready,
        InGame,
        GameOver


    }
    private Game_Status status;
    public GameObject PanleReady;
    public GameObject PanleInGame;
    public GameObject PanleGameOver;
    public PipelineManager pipelineManager;
    public player player;
    public Text scoreText;
    public Text scoreText2;
    public int score;

    private int Score
    {
        get { return score; }
        set 
        {
            score = value;
            scoreText.text = score.ToString(); 
            scoreText2.text = score.ToString(); 
        }
    }

    private Game_Status Status
    {
        get { return status; }
        set { status = value; UI(); }

    }
    void Start()
    {
        PanleReady.SetActive(true);
        player.OnDeth += Player_OnDeth;
        player.scoreAction = getScore;
    }

    private void getScore(int score)
    {
        Score += score;
    }
    private void Player_OnDeth()
    {
        Status = Game_Status.GameOver;
        pipelineManager.pileStop();
      


    }

    void Update()
    {
        
    }
    //游戏开始
    public void StartGame ()
    {
        this.Status = Game_Status.InGame;
       
          
        StartCoroutine(StartGenerationPipes());
       
        
        player.Fly();
        

    }

    public void GameReset()
    {
        Status = Game_Status.Ready;
        pipelineManager.init();
        player.Init();
        Score = 0;
    }
    IEnumerator StartGenerationPipes()
    { 
        
        yield return new WaitForSeconds(2.5f);
        pipelineManager.pileStart();


    }
    public void UI()
    {
        PanleReady.SetActive(this.Status == Game_Status.Ready);
        PanleInGame.SetActive(this.Status == Game_Status.InGame);
        PanleGameOver.SetActive(this.Status == Game_Status.GameOver);

    }
}
