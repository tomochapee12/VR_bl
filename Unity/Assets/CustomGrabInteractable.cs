using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class CustomGrabInteractable : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    // 掴んだときに回転マッチを無効化：常にオブジェクトの元の回転を維持
    protected override bool ShouldMatchAttachRotation(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor)
    {
        return false;
    }

    // （動的アタッチを使う場合）動的AttachのPoseを固定したいときにアンコメント
    // protected override void InitializeDynamicAttachPose(IXRSelectInteractor interactor, Transform dynamicAttachTransform)
    // {
    //     if (attachTransform != null)
    //     {
    //         dynamicAttachTransform.position = attachTransform.position;
    //         dynamicAttachTransform.rotation = attachTransform.rotation;
    //     }
    // }
}
