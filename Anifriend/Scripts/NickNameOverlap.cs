using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public sealed class NickNameOverlap : MonoBehaviourPunCallbacks {
    [SerializeField] Canvas init;
    [SerializeField] InputField inputField;
    [SerializeField] Text overlap;
    [SerializeField] Button button;

    public void OnOverlap() {
        if (inputField == null || overlap == null) return;

        if (button != null) {
            button.interactable = false;
        }

        if (inputField.text.Length < 2) {
            overlap.text = "�г����� 2���� �̻��̾�� �մϴ�.";
            return;
        }

        if (inputField.text.Length > 15) {
            overlap.text = "�г����� 15�� �����̾�� �մϴ�.";
            return;
        }

        var otherPlayers = PhotonNetwork.PlayerListOthers;
        foreach (var player in otherPlayers) {
            if (inputField.text == player.NickName) {
                overlap.text = "�̹� �����ϴ� �г����Դϴ�.";
                return;
            }
        }

        if (button != null) {
            button.interactable = true;
        }

        overlap.text = "��� ������ �г����Դϴ�.";
    }

    public void Btn_Complete() {
        if (button != null) {
            button.interactable = false;
        }

        var otherPlayers = PhotonNetwork.PlayerListOthers;
        foreach (var player in otherPlayers) {
            if (inputField.text == player.NickName) {
                overlap.text = "�̹� �����ϴ� �г����Դϴ�.";
                return;
            }
        }

        if (button != null) {
            button.interactable = true;
        }

        if (init == null) return;

        if (inputField != null) {
            PhotonNetwork.LocalPlayer.NickName = inputField.text;
        }

        if (Chatting.Instance != null) {
            var nickName = PhotonNetwork.LocalPlayer.NickName == null 
                || PhotonNetwork.LocalPlayer.NickName == ""
                ? PhotonNetwork.LocalPlayer.UserId : PhotonNetwork.LocalPlayer.NickName;
            var message = string.Format($"{nickName}���� �����ϼ̽��ϴ�.");
            Chatting.Instance.SystemMessage(message);
            Chatting.Instance.TurnOnChatting();
        }
        
        init.enabled = false;
    }
}
