using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    // Start is called before the first frame update
    public void PlayGame(){
        if(!Global.playmode){
            Global.playmode = true;
            playButton.gameObject.SetActive(false);
        }
    }
}
