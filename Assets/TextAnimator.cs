using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour
{
//     [SerializeField] 
//     private string _message;

//     [SerializeField]
//     float _stringAnimationDuration;

//     [SerializeField]
//     private TextMeshProUGUI _animatedText;

//     [SerializeField]
//     private AnimationCurve _sizeCurve; 

//     [SerializeField]
//     private float _sizeScale;

//     [SerializeField]
//     [Range(0.0001f, 1)]
//     private float _charAnimationDuration;

//     private float _timeElapsed;

// //-----------------------------------------
//     public float revealTime;
//     public float alphaVal;
//     public float revealConst; //how much to increase opacity per second

    //---------------------
    [SerializeField] private TextMeshProUGUI itemInfoText;
    [TextArea][SerializeField] private string[] itemInfo;
    [SerializeField] private float revealSpeed = 0.01f;

    private int currentDisplayingText = 0;

    private void Start() {
        ActivateText();
    }
    
    public void ActivateText() {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++) {
            itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(revealSpeed);
            //Debug.Log("curr index: " + i + " curr char: " + itemInfo[currentDisplayingText][i] + " (len = " + itemInfo[currentDisplayingText].Length + " )");
            if(i >= 1 && i < itemInfo[currentDisplayingText].Length - 2) {
                char curr = itemInfo[currentDisplayingText][i-1];
                if(curr == '.') {
                    yield return new WaitForSeconds(0.8f);
                } else if (curr == ',') {
                    yield return new WaitForSeconds(0.4f);
                }
            }
        }
    }

//     private void Start() {
//         //take animated text
//         //set the alphaval (should be 0)
//         //while reveal time > 0 and alphaval < 255
//             //reveal each character at a time
//             //should combine the two scripts ig

//         _animatedText = GetComponent<TextMeshProUGUI>();
//         alphaVal = _animatedText.color.a;
//         revealConst = 1/revealTime;
//         //StartCoroutine(RunAnimation(2));
//     }

//     void Update() {
//         if(revealTime > 0) {
//             alphaVal -= revealConst * Time.deltaTime;
//             _animatedText.color = new Color(_animatedText.color.r, _animatedText.color.g, _animatedText.color.b, alphaVal);
//             revealTime -= _timeElapsed.deltaTime;//reduce time
//         }
//     }

//     IEnumerator RunAnimation(float waitForSeconds) {
//         yield return new WaitForSeconds(waitForSeconds);

//         float t = 0;
//         while(t <= 1f){
//             EvaluateText(t);
//             t = _timeElapsed / _stringAnimationDuration;
//             _timeElapsed += Time.deltaTime;
//             yield return null;
//         }
//     }

//     void EvaluateText(float t) {
//         _animatedText.text = "";

//         for(int i = 0; i < _message.Length; i++) {
//             _animatedText.text += EvaluateChar(_message[i], _message.Length, i, t);
//         }
//     }

//     private string EvaluateChar(char c, int sLen, int sPos, float t) {
//         float startPoint = ((1 - _charAnimationDuration)/(sLen - 1)) * sPos;
//         float endPoint = startPoint + _charAnimationDuration;
//         float subT = t.Map(startPoint, endPoint, 0, 1);
//         // string sizeStart = $"<size={_sizeCurve.Evaluate(subT) * _sizeScale}%>";
//         // string sizeEnd = "</size>";
//         //_animatedText.color = new Color(_animatedText.color.r, _animatedText.color.g, _animatedText.color.b, alphaVal);

//         if(revealTime > 0) {
//             alphaVal -= revealConst * Time.deltaTime;
//             _animatedText.color = new Color(_animatedText.color.r, _animatedText.color.g, _animatedText.color.b, alphaVal);
//             revealTime -= _timeElapsed.deltaTime;//reduce time
//         }

//         return sizeStart + c + sizeEnd;
//     }

//     // private string EvaluateChar(char c, int sLen, int sPos, float t) {
//     //     float startPoint = ((1 - _charAnimationDuration)/(sLen - 1)) * sPos;
//     //     float endPoint = startPoint + _charAnimationDuration;
//     //     float subT = t.Map(startPoint, endPoint, 0, 1);
//     //     string sizeStart = $"<size={_sizeCurve.Evaluate(subT) * _sizeScale}%>";
//     //     string sizeEnd = "</size>";

//     //     return sizeStart + c + sizeEnd;
//     // }
// }

// public static class Extensions {
//     public static float Map(this float value, float fromLow, float fromHigh, float toLow, float toHigh) {
//         return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
//     }
}