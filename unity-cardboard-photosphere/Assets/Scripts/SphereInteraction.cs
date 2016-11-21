using UnityEngine;
using System.Collections;

public class SphereInteraction : MonoBehaviour {

  // Use this for initialization}
  public Camera camera;

  private bool inSphere = false;

      // Use this for initialization
  void Start() {
  }

  void Update() {
    if (inSphere && Input.GetMouseButtonDown (0)) {
      camera.transform.position = new Vector3 (0, 10, 0); 
      inSphere = false;
    }
  }

  public void LookAtSphere() {
    if (!inSphere)
      Debug.Log ("looking at sphere!");
      setHalo (true);
  }
  public void LookAwaySphere() {
    if (!inSphere)
      Debug.Log ("looking away from sphere!");
      setHalo (false);
    }

  private void setHalo(bool active) {
    Component halo = GetComponent ("Halo");
    halo.GetType().GetProperty("enabled").SetValue(halo, active, null);
  }

  public void MoveCameraToSphere() {
    camera.transform.position = transform.position;
    inSphere = true;
  }
}

