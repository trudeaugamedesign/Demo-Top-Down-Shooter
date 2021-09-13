using UnityEngine;
using UnityEngine.UI;

public class FloatingText {
    
    public bool active;
    public GameObject obj;
    public Text text;
    public Vector3 motion;
    public Vector3 worldPos;
    public float duration;
    public float lastShown;

    // Show / Hide better than instantiate / destroy
    public void Show() {
        active = true;
        lastShown = Time.time;
        obj.SetActive(active); // true
    }
    
    public void Hide() {
        active = false;
        obj.SetActive(active); // false
    }

    public void UpdateFloatingText() {
        if (!active) return;

        if (Time.time - lastShown > duration) Hide();

        worldPos += motion * Time.deltaTime;
        obj.transform.position = Camera.main.WorldToScreenPoint(worldPos);
        
    }
    
}
