using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Chatting : MonoBehaviourPun {
    public static Chatting Instance { get; private set; }

    public bool IsFocused {
        get {
            if (inputField != null) {
                return inputField.isFocused;
            }
            return false;
        }
    }

    [SerializeField] GameObject prefab_Message;
    [SerializeField] RectTransform content;
    [SerializeField] InputField inputField;
    [SerializeField, Range(5, 50)] int max = 10;

    [HideInInspector] public bool isDone = false;

    event Action<string, string> Receive;
    public void Register(Action<string, string> Receive) { this.Receive += Receive; }
    public void Unregister(Action<string, string> Receive) { this.Receive -= Receive; }

    public readonly struct MessageFormat {
        public readonly Date date;
        public readonly Text text;

        public MessageFormat(Date date, string userId, Text text, string nickName, string message) {
            (this.date, this.text) = (date, text);
            if (this.text != null) {
                var dateMessage = $"[{date.GetTimeStamp()}]";
                var tempMessage = message;
                if (userId != "System") {
                    var temp = (nickName == null || nickName == "") ? userId : nickName;
                    var insertMessage = $"[{temp}]";
                    tempMessage = insertMessage + ' ' + tempMessage;
                }
                this.text.text = dateMessage + ' ' + tempMessage;
                this.text.color = PhotonNetwork.LocalPlayer.UserId == userId
                    ? Color.green : Color.white;
            }
        }
    }

    public readonly struct Date {
        public readonly int[] info;

        public Date(int year, int month, int day, int hour, int minute, int second) {
            info = new int[] { year, month, day, hour, minute, second };
        }

        public readonly int Compare(Date date) {
            for (var i = 0; i < info.Length; i++) {
                if (info[i] < date.info[i]) {
                    return -1;
                } else if (date.info[i] < info[i]) {
                    return 1;
                }
            }
            return 0;
        }

        public readonly string GetTimeStamp() {
            try {
                var (half, hour) = ("����", info[3]);
                if (hour > 12) {
                    (half, hour) = ("����", hour - 12);
                }
                return $"{half} {hour:00}:{info[4]:00}:{info[5]:00}";
            } catch { }

            return "";
        }
    }

    List<MessageFormat> messages = new List<MessageFormat>();

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this);

    }

 

    public void OnSubmit() {
        if (!PhotonNetwork.InRoom) return;

        if (inputField != null && inputField.text != "") {
            var message = inputField.text;
            inputField.text = "";

            var userId = PhotonNetwork.LocalPlayer.UserId;
            var nickName = PhotonNetwork.LocalPlayer.NickName;

            var (year, month, day, hour, minute, second) =
                (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            if (PhotonNetwork.InRoom) {
                photonView.RPC("InputMessage", RpcTarget.All,
                year, month, day, hour, minute, second, userId, nickName, message);
            }

            if (content != null) {
                content.anchoredPosition = Vector3.zero;
            }
        }
    }

    [PunRPC]
    void InputMessage(int year, int month, int day, int hour, int minute, int second, string userId, string nickName, string message) {
        if (prefab_Message == null || content == null || messages == null) return;

        var date = new Date(year, month, day, hour, minute, second);

        for (var i = messages.Count - 1; i >= 0; i--) {
            if (messages[i].date.Compare(date) <= 0) {
                CreateMessage(i + 1);
                goto Break;
            }
        }
        CreateMessage(0);

    Break:
        if (Receive != null) Receive(userId, message);

        while (messages.Count > max) {
            var text = messages[0].text;
            messages.RemoveAt(0);
            Destroy(text.gameObject);
        }

        var (width, height) = (content.sizeDelta.x, 0f);

        var line = prefab_Message.GetComponent<RectTransform>();
        if (line != null) {
            height += line.sizeDelta.y * messages.Count;
        }

        var vertical = content.GetComponent<VerticalLayoutGroup>();
        if (vertical != null) {
            height += vertical.padding.top + vertical.padding.bottom;
        }

        content.sizeDelta = new Vector2(width, height);

        inputField.ActivateInputField();

        void CreateMessage(int index) {
            if (prefab_Message == null || content == null) return;
            var obj = Instantiate(prefab_Message, content);

            if (obj == null) return;
            var text = obj.GetComponent<Text>();

            if (text == null) { Destroy(obj); return; }
            if (messages.Count <= 0) index = 0;
            else index = index > messages.Count ? messages.Count : index;
            messages.Insert(index, new MessageFormat(date, userId, text, nickName, message));
            messages[index].text.transform.SetSiblingIndex(index);
        }
    }

    public void SystemMessage(string message) {
        var userId = "System";
        var nickName = PhotonNetwork.LocalPlayer.NickName;

        var (year, month, day, hour, minute, second) =
            (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
            DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        if (PhotonNetwork.InRoom) {
            photonView.RPC("InputMessage", RpcTarget.All,
                year, month, day, hour, minute, second, userId, nickName, message);
        }
    }

    public void TurnOnChatting() {
        if (inputField == null) return;
        inputField.interactable = true;
        isDone = true;
    }
}
