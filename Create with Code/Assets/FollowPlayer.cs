using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_FollowPlayer;
    [SerializeField]
    private Vector3 possitionOffset = new Vector3(0,5,2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_FollowPlayer.transform.position + possitionOffset;
        //transform.LookAt(m_FollowPlayer.transform.position);
    }
}
