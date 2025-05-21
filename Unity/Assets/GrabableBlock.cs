using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class GrabableBlock : MonoBehaviour
{
    UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    Rigidbody rb;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb               = GetComponent<Rigidbody>();

        // 基本挙動：重力ON、キネマティックOFF
        rb.useGravity   = true;
        rb.isKinematic  = false;

        // 掴んでいる間の移動タイプをInstantaneousに（手にピッタリ追従）
        grabInteractable.movementType      = UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable.MovementType.Instantaneous;
        grabInteractable.trackPosition     = true;
        grabInteractable.trackRotation     = true;

        // イベント登録
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited .AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // 掴んでいる間は物理演算を止め、Transform追従のみ
        rb.useGravity  = false;
        rb.isKinematic = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // 離したら物理演算を再開
        rb.isKinematic = false;
        rb.useGravity  = true;
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited .RemoveListener(OnRelease);
    }
}