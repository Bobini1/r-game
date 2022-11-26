using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class SongResultFactory : MonoBehaviour
{
    public GameObject resultScreen;
    public GameObject Create(string title, float score)
    {
        var newResultScreen = Instantiate(resultScreen, new Vector3(0, 0, 0), Quaternion.identity);
        // get SongTitle
        var songTitle = newResultScreen.transform.Find("SongTitle").GetComponent<TextMeshProUGUI>();
        var songScore = newResultScreen.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        songTitle.text = title;
        songScore.text = score.ToString(CultureInfo.InvariantCulture) + "%";
        return newResultScreen; 
    }
}
