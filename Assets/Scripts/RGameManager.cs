using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGameManager : MonoBehaviour
{
    public void Invoke()
    {
        GetComponent<ChangeScene>().LoadScene("MainMenu");
    }


}
