using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Pool / list of floating texts
public class FloatingTextManager : MonoBehaviour {
    
    public static FloatingTextManager instance;

    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Awake() {
        if (FloatingTextManager.instance != null) {
            Destroy(gameObject);
            return;
        }
        
        FloatingTextManager.instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        foreach(FloatingText text in floatingTexts) 
            text.UpdateFloatingText();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 pos, Vector3 motion, float duration) {
        FloatingText floatingText = GetFloatingText();

        // floatingText's Text component's properties (text, fontsize, color)
        floatingText.text.text = msg;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;
        
        // convert world position (pos) to point on screen (on canvas)
        floatingText.obj.transform.position = Camera.main.WorldToScreenPoint(pos);
        floatingText.worldPos = pos;
        floatingText.motion = motion;
        floatingText.duration = duration;

        // show the floating text
        floatingText.Show();

    }

    private FloatingText GetFloatingText() {
        FloatingText text=null;
        // get any floating text that is not active 
        for (int i=0;i<floatingTexts.Count;i++) {
            if (!floatingTexts[i].active) {
                text = floatingTexts[i];
                break;
            }
        }

        // shorter way to write the above code ^^^
        // text = floatingTexts.Find(t => !t.active);

        // if floating text not available / not already created, create it now
        if (text == null) {
            text = new FloatingText();
            text.obj = Instantiate(textPrefab);
            text.obj.transform.SetParent(textContainer.transform);
            text.text = text.obj.GetComponent<Text>();

            floatingTexts.Add(text);
        }

        return text;
    }

}
