using System;
using Cinemachine;
using UnityEngine;
using DialogueEditor;

public class NPC : MonoBehaviour
{
// NPCConversation Variable (assigned in Inspector)
    public NPCConversation Conversation;
    public GameObject _target;
    [TagField] public string TargetTag;
    public bool enabled = true;
    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(TargetTag);
        }

    private void OnMouseOver()
    {
        var distance = Vector3.Distance(_target.transform.position, transform.position);
        
        if (Input.GetMouseButtonDown(0) && enabled && distance < 7)
        {
            ConversationManager.Instance.StartConversation(Conversation);
        }
    }


    public void StopConversation()
    {
        ConversationManager.Instance.EndConversation();
    }

    public void TargetNoHP()
    {
        var bs = _target.GetComponent<BattleSystem>();
        
        bs.dealDamage(bs.hp/2);
    }

    public void KillTarget()
    {
        var bs = _target.GetComponent<BattleSystem>();
        
        bs.dealDamage(bs.maxHp + 1);
    }
    
    public void HealTarget()
    {
        var bs = _target.GetComponent<BattleSystem>();

        bs.hp = bs.maxHp;
    }

    public void DisableConversation()
    {
        enabled = false;
    }
}