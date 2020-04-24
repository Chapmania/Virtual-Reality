using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public GameObject Ink;
    public GameObject Marker;
    // public float InkSize = 0.1f;
    // public Controller controller;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update() {

      if (OVRInput.Get(OVRInput.Button.One)) {
        Vector3 bk = Marker.transform.TransformDirection(Vector3.back);
        RaycastHit hit;
        if (Physics.Raycast(Marker.transform.position, bk, .1f)){
          Marker.SetActive(false);
        }
      }

      if (OVRInput.Get(OVRInput.Button.Two)){
        Marker.SetActive(true);
      }
    }


}
    // void FixedUpdate()
    // {
    //     Vector3 fwd = transform.TransformDirection(Vector3.forward);
    //     if (OVRInput.Get(OVRInput.Button.One)){
    //       if (Physics.Raycast(Marker.transform.position, fwd, 2)){
    //         print("There is something in front of the object!");
    //         Debug.Log("HIT");
    //         var mark = Instantiate(Ink, Marker.transform.position, Marker.transform.rotation);
    //       }
    //     }
    //
    // }

    // Update is called once per frame
    // void Update()
    // {
    //   if (OVRInput.Get(OVRInput.Button.One)){
    //     Debug.log("PRESSED");
    //     // RaycastHit hit;
    //     // if (Physics.Raycast(Marker.transform.position, transform.TransformDirection(Vector3.forward), out hit, 10)) {
    //     //   Debug.Log("Hit");
    //     //   var mark = Instantiate(Ink, hit.transform.position, Marker.transform.rotation);
    //     // }
    //   }
    // }
    //   if (OVRInput.Get(OVRInput.Button.One)){
    //     Vector3 pen_position = Marker.transform.position + Vector3.down * 0.1f;
    //     var mark = Instantiate(Ink, pen_position, Marker.transform.rotation);
    //   }
    //   OnCollisionEnter();
    //   // else{
    //   //   if (OVRInput.Get(OVRInput.Button.One && Marker.transform.position);
    //   // }
    //   // if (OVRInput.Get(OVRInput.Button.One)) {
    //   //   var Ray = Camera.main.ScreenPointToRay(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
    //   //   RaycastHit hit;
    //   //   if(Physics.Raycast(Ray, out hit)) {
    //   //     var go = Instantiate(Marker, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
    //   //     go.transform.localScale = Vector3.one * InkSize;
    //   //   }
    //   // }
    // }
    // void OnCollisionEnter(Collision collision)
    // {
    //     //Check for a match with the specific tag on any GameObject that collides with your GameObject
    //     if (collision.gameObject.tag == "Board" )
    //     {
    //       Vector3 pen_position = Marker.transform.position + Vector3.down * 0.1f;
    //       var mark = Instantiate(Ink, pen_position, Marker.transform.rotation);
    //         //If the GameObject has the same tag as specified, output this message in the console
    //         // Vector3 pen_position = Marker.transform.position + Vector3.down * 0.1f;
    //         // var mark = Instantiate(Ink, collision.gameObject.transform.position, Marker.transform.rotation);
    //     }
    // }
// }
