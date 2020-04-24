using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVRHand;

public class grab_object : MonoBehaviour
{
    // public GameObject cylinder
    public GameObject item;
    public GameObject tip;
    private OVRHand l_hand;
    private OVRSkeleton l_finger;
    public OVRHand r_hand;
    public OVRSkeleton r_finger;

    private bool r_isIndexFingerPinching;
    private bool l_isIndexFingerPinching;
    private bool l_isMiddleFingerPinching;
    private Vector3 initial_position;
    public GameObject ink;
    public GameObject ink2;

    private Renderer inkRenderer;
    // Start is called before the first frame update
    void Start()
    {
        l_hand = GetComponent<OVRHand>();
        l_finger = GetComponent<OVRSkeleton>();
        r_finger = r_hand.GetComponent<OVRSkeleton>();
        r_isIndexFingerPinching = r_hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        l_isIndexFingerPinching = l_hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        initial_position = item.transform.position;
        inkRenderer = ink.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
      isGrabbing();
      colorChange();
    }

    void isGrabbing() {
      // Ray ray;
      Vector3 current = item.transform.position;
      // Experiment with left and right hand pinch
      l_isIndexFingerPinching = l_hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
      r_isIndexFingerPinching = r_hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

      if (r_isIndexFingerPinching) {
        item.transform.position = Vector3.Lerp(item.transform.position, r_finger.Bones[20].Transform.position, 50f*Time.deltaTime);
        item.transform.rotation = Quaternion.Slerp(item.transform.rotation, r_hand.transform.rotation, 10f*Time.deltaTime);
      }
      if (!r_isIndexFingerPinching) {
        item.transform.position = Vector3.Lerp(item.transform.position, initial_position, 50f*Time.deltaTime);
        item.transform.rotation = Quaternion.Slerp(item.transform.rotation, r_hand.transform.rotation, 10f*Time.deltaTime);
      }

      if (r_isIndexFingerPinching && l_isIndexFingerPinching){
        RaycastHit hit;
        if (Physics.Raycast(tip.transform.position, -tip.transform.up, out hit, .2f)){
          if(hit.collider.tag == "Board"){
            Instantiate(ink, hit.point-Vector3.forward*0.01f, hit.transform.rotation);
          }
        }
      }
    }

    void colorChange() {
      l_isMiddleFingerPinching = l_hand.GetFingerIsPinching(OVRHand.HandFinger.Middle);
      if (l_isMiddleFingerPinching) {
        inkRenderer.material.SetColor("_Color", Color.red);
      }
    }

    // if (r_isIndexFingerPinching) {
      // item.transform.rotation = r_hand.transform.rotation;
      // item.transform.position = r_hand.transform.position;
      // item.transform.position = Vector3.Lerp(current, new Vector3(current.x,r_hand.transform.position.y,r_hand.transform.position.z), Time.deltaTime);
    // }

      // if (!l_isIndexFingerPinching){
      //   item.transform.position = Vector3.MoveTowards(item.transform.position, initial_position, 1f *Time.deltaTime );
      //   item.rotation = new Vector3(0,0,0);
      //   // item.transform.rotation = Quaternion.RotateTowards(new Vector3(0,0,0), Quaternion.Euler(l_hand.transform.rotation), 1f*Time.deltaTime);
      //   // item.transform.rotation = Vector3.RotateTowards(new Vector3(0,0,0), l_hand.transform.rotation, 1f*Time.deltaTime, 0.0f);
      // }
      // if(l_isIndexFingerPinching ){
      //   item.transform.position = Vector3.MoveTowards(item.transform.position, r_hand.transform.position + Vector3.forward*.1f, 1f *Time.deltaTime );      }
      //   // item.transform.rotation = Vector3.RotateTowards(l_hand.transform.rotation, new Vector3(0,0,0), 1f*Time.deltaTime, 0.0f);
      //   // item.transform.rotation = Vec.RotateTowards(Quaternion.Euler(l_hand.transform.rotation), new Vector3(0,0,0), 1f*Time.deltaTime);
    // }
    //
    //   Vector3 placement = r_finger.Bones[20].Transform.position + Vector3.left*.2f;
    //   // Vector3 placement = r_hand.transform.position;

}
