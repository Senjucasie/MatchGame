using UnityEngine;

[RequireComponent(typeof(ScoreView))]
public class ScoreHandler : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    private ScoreView _scoreView;

    private void Start()
    {
        _scoreView= GetComponent<ScoreView>();
    }



    public bool CheckPair(int id1,int id2)
    {
        if (id1 == id2)
        {
            CurrentScore++;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateUI()
    {
        _scoreView.UpdateScore(CurrentScore);
    }
}
