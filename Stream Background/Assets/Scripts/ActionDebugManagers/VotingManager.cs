using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class VotingManager : MonoBehaviour
{
    public Button ButtonVote1;
    public Button ButtonVote2;
    public Button ButtonVote3;
    public Button ButtonVote4;

    public TMP_Text VoteNumberText1;
    public TMP_Text VoteNumberText2;
    public TMP_Text VoteNumberText3;
    public TMP_Text VoteNumberText4;

    public TMP_Text VotePercentText1;
    public TMP_Text VotePercentText2;
    public TMP_Text VotePercentText3;
    public TMP_Text VotePercentText4;

    private int voteOptionsMaxCount = 4;
    private List<int> voteCount = new List<int>();
    private List<float> votePercent = new List<float>();

    private void Awake()
    {
        ButtonVote1.onClick.AddListener(OnButtonVote1);
        ButtonVote2.onClick.AddListener(OnButtonVote2);
        ButtonVote3.onClick.AddListener(OnButtonVote3);
        ButtonVote4.onClick.AddListener(OnButtonVote4);
        for (int i = 0; i < voteOptionsMaxCount; i++)
        {
            voteCount.Add(0);
            votePercent.Add(0f);
        }
        UpdateVotingPercents();
    }

    private void OnButtonVote1()
    {
        voteCount[0]++;
        UpdateVotingPercents();
    }

    private void OnButtonVote2()
    {
        voteCount[1]++;
        UpdateVotingPercents();
    }

    private void OnButtonVote3()
    {
        voteCount[2]++;
        UpdateVotingPercents();
    }

    private void OnButtonVote4()
    {
        voteCount[3]++;
        UpdateVotingPercents();
    }

    private int TotalCount()
    {
        int sum = 0;
        for (int i = 0; i < voteOptionsMaxCount; i++)
        {
            sum += voteCount[i];
        }
        return sum;
    }

    private void UpdateVotingPercents()
    {
        var total = TotalCount();
        for (int i = 0; i < voteOptionsMaxCount; i++)
        {
            if (total == 0) { votePercent[i] = 0; }
            else { votePercent[i] = Mathf.Round((float)voteCount[i] / total * 100); }
        }

        VotePercentText1.text = string.Format("{0}%", votePercent[0]);
        VotePercentText2.text = string.Format("{0}%", votePercent[1]);
        VotePercentText3.text = string.Format("{0}%", votePercent[2]);
        VotePercentText4.text = string.Format("{0}%", votePercent[3]);

        VoteNumberText1.text = string.Format("投票数: {0}", voteCount[0]);
        VoteNumberText2.text = string.Format("投票数: {0}", voteCount[1]);
        VoteNumberText3.text = string.Format("投票数: {0}", voteCount[2]);
        VoteNumberText4.text = string.Format("投票数: {0}", voteCount[3]);
    }

    public void ResetCounters()
    {
        for (int i = 0; i < voteOptionsMaxCount; i++)
        {
            voteCount[i] = 0;
        }
        UpdateVotingPercents();
    }
}
