using System;
using Photon.Pun;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public sealed class MessageWindow : MonoBehaviourPunCallbacks {
    [SerializeField] GameObject window;
    [SerializeField] Text message;

    public Animator[] animators;
    public ThirdPersonMovement actor;

    string userId;

    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
        actor = GetComponent<ThirdPersonMovement>();
    }

    void Start() => photonView.RPC("Init", RpcTarget.All);
    
    public override void OnEnable() {
        base.OnEnable();

        if (Chatting.Instance != null) {
            Chatting.Instance.Register(ReceiveMessage);
        }
    }

    public override void OnDisable() {
        base.OnDisable();

        if (Chatting.Instance != null) {
            Chatting.Instance.Unregister(ReceiveMessage);
        }
    }

    [PunRPC]
    void Init() {
        if (photonView.IsMine) {
            photonView.RPC("Setting", RpcTarget.All, PhotonNetwork.LocalPlayer.UserId);
        }
    }

    [PunRPC]
    void Setting(string userId) => this.userId = userId;

    void Update() {
        if (Camera.main != null && window != null) {
            var forward = window.transform.position - Camera.main.transform.position;
            window.transform.rotation = Quaternion.LookRotation(forward);
        }
    }

    public void ReceiveMessage(string userId, string message) {
        if (this.userId != userId || window == null || this.message == null) return;
        StopCoroutine("DelayOff");
        this.message.text = message;
        window.SetActive(true);
        
        //종권추가
        actor.ChatAction();

        StartCoroutine("DelayOff");
    }

    IEnumerator DelayOff() {
        if (window == null) yield break;
        yield return new WaitForSeconds(5f);
        window.SetActive(false);
    }
}
