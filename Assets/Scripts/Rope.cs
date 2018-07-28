using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public int linkCount = 7;

    public Rigidbody2D linkPrefab;

    Rigidbody2D hook;

    void Start()
    {
        hook = transform.Find("Hook").GetComponent<Rigidbody2D>();
        hook.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();

        GenerateRope();
    }

    public void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < linkCount; i++)
        {
            Rigidbody2D link = Instantiate(linkPrefab);
            link.GetComponent<HingeJoint2D>().connectedBody = previousRB;
            previousRB = link;
        }

        HingeJoint2D playerHook = Player.Instance.gameObject.AddComponent<HingeJoint2D>();
        playerHook.autoConfigureConnectedAnchor = false;
        playerHook.connectedAnchor = Vector2.zero;
        playerHook.connectedBody = previousRB;
    }
}