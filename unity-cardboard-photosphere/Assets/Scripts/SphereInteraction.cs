using UnityEngine;
using System.Collections;

public class SphereInteraction : MonoBehaviour {

  // Use this for initialization}

  private bool inSphere = false;

      // Use this for initialization
  void Start() {
  }

  void Update() {
  }

  public void LookAtSphere() {
    if (!inSphere)
      setHalo (true);
  }
  public void LookAwaySphere() {
    if (!inSphere)
      setHalo (false);
    }

  private void setHalo(bool active) {
    Component halo = GetComponent ("Halo");
    halo.GetType().GetProperty("enabled").SetValue(halo, active, null);
  }
}

