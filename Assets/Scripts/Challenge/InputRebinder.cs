using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        // [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.
        spaceAction = actionAsset.FindAction("Space");
        spaceAction.Enable();
    }

    // [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��
    [ContextMenu("Rebind")]

    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [�������� 3] ���� ���ε��� ��Ȱ��ȭ�ϰ� �� Ű�� ����ε�
        spaceAction.ApplyBindingOverride("<Keyboard>/escape");

        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // �׼��� ��Ȱ��ȭ�մϴ�.
        spaceAction?.Disable();
    }
}