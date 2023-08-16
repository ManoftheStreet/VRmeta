using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using Unity.XR.CoreUtils;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public Transform pHead;
    public Transform pLeft;
    public Transform pRight;

    Transform oHead;
    Transform oLeft;
    Transform oRight;

    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        XROrigin o = FindObjectOfType<XROrigin>();

        oHead = o.transform.Find("Camera Offset/Main Camera");
        oLeft = o.transform.Find("Camera Offset/Left Controller");
        oRight = o.transform.Find("Camera Offset/Right Controller");

        if (pv.IsMine)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
    }

    void SetTransform(Transform t, Transform s)
    {
        t.position = s.position;
        t.rotation = s.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            SetTransform(pHead, oHead);
            SetTransform(pLeft, oLeft);
            SetTransform(pRight, oRight);
        }
    }
}
