using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {

  [Header("Collidable Settings")]
  public ContactFilter2D filter2D;
  protected BoxCollider2D boxCollider;
  protected Collider2D[] hits = new Collider2D[10];
  
  protected virtual void Start() {
    boxCollider = GetComponent<BoxCollider2D>();
      
  }
    
  protected virtual void Update() {
    // go through collisions
    boxCollider.OverlapCollider(filter2D, hits);
    for (int i=0;i<hits.Length;i++) {
      if (hits[i]==null) continue;

      OnCollide(hits[i]);

      // clean up array
      hits[i] = null;
    }

  }

  public bool CollidesWithTag(string tag) {
    boxCollider.OverlapCollider(filter2D, hits);
    for (int i=0;i<hits.Length;i++) {
      if (hits[i]==null) continue;
      
      if (hits[i].tag==tag) return true;

      // clean up array
      hits[i] = null;
    }
    
    return false;
  }

  public bool CollidesWithName(string name) {
    boxCollider.OverlapCollider(filter2D, hits);
    for (int i=0;i<hits.Length;i++) {
      if (hits[i]==null) continue;
      
      if (hits[i].name==name) return true;

      // clean up array
      hits[i] = null;
    }
    
    return false;
  }

  protected virtual void OnCollide(Collider2D col) {
    // Debug.Log(col.name);
  }

}
