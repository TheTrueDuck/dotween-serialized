using System;
using DG.Tweening;
using DOTweenConfigs;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(TweenConfig))]
[CustomPropertyDrawer(typeof(Position3DTweenConfig))]
public class TweenConfigPropertyDrawer : PropertyDrawer
{
    // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    // {
    //     base.OnGUI(position, property, label);
    //     EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("duration"), GUIContent.none);
    // }
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        Debug.Log($"{property.type} {property.propertyType}");
        // Create property container element.
        VisualElement container = new VisualElement();
        // container.Clear();
        
        SerializedProperty easeProperty = property.FindPropertyRelative("ease");

        // Create property fields.
        PropertyField durationField = new PropertyField(property.FindPropertyRelative("duration"/* nameof(TweenConfig.duration) */));
        PropertyField easeField = new PropertyField(property.FindPropertyRelative("ease"));
        PropertyField loopsField = new PropertyField(property.FindPropertyRelative("loops"));
        PropertyField loopTypeField = new PropertyField(property.FindPropertyRelative("loopType"));
        // SerializedProperty loopType = property.FindPropertyRelative("loopType");
        
        // EnumField a = new EnumField().bin;


        // Add fields to the container.
        container.Add(durationField);
        // container.Add(ease);
        container.Add(easeField);
        container.Add(loopsField);
        // container.Add(loopType);
        
        
        
        
        
        
        PropertyField easeOvershootOrAmplitudeField = new PropertyField(property.FindPropertyRelative("easeOvershootOrAmplitude"));
        // easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
        // easeOvershootOrAmplitudeField.style.display = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        container.Add(easeOvershootOrAmplitudeField);
        
        PropertyField easePeriodField = new PropertyField(property.FindPropertyRelative("easePeriod"));
        // easePeriodField.visible = EasingUsesPeriod((Ease)easeProperty.enumValueIndex);
        // easePeriodField.style.display = EasingUsesPeriod((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        container.Add(easePeriodField);
        
        
        easeField.RegisterValueChangeCallback(Method);
        
        easeField.RegisterValueChangeCallback(e =>
        {
            Debug.Log($"Toggling visibility {(Ease)easeProperty.enumValueIndex} {(Ease)e.changedProperty.enumValueIndex}");
            // easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
            // easePeriodField.visible = EasingUsesPeriod((Ease)easeProperty.enumValueIndex);
            easeOvershootOrAmplitudeField.style.display = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
            easePeriodField.style.display = EasingUsesPeriod((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        });
        
        easeField.RegisterValueChangeCallback(e =>
        {
            Debug.Log($"Toggling visibility {(Ease)easeProperty.enumValueIndex} {(Ease)e.changedProperty.enumValueIndex}");
            container.MarkDirtyRepaint();
        });
        
        // easeField.RegisterValueChangeCallback(_ => container.MarkDirtyRepaint());
        // easeField.RegisterValueChangeCallback(_ => container.Clear());
        // easeField.RegisterValueChangeCallback(_ => CreatePropertyGUI(property));

        // if (EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex))
        // {
        //     PropertyField easeOvershootOrAmplitudeField = new PropertyField(property.FindPropertyRelative("easeOvershootOrAmplitude"));
        //     // easeField.Add(easeOvershootOrAmplitudeField);
        //     container.Add(easeOvershootOrAmplitudeField);
        //     easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
        // }
        
        // if (EasingUsesPeriod((Ease)easeProperty.enumValueIndex))
        // {
        //     PropertyField easePeriodField = new PropertyField(property.FindPropertyRelative("easePeriod"));
        //     // easeField.Add(easePeriodField);
        //     container.Add(easePeriodField);
        //     easePeriodField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
        // }

        Foldout a = new Foldout() { text = "Events" };

        a.Add(loopTypeField);

        container.Add(a);


        if (property.type == nameof(Position3DTweenConfig))
        {
            PropertyField snappingField = new PropertyField(property.FindPropertyRelative("m_snapping"));
            container.Add(snappingField);
        }

        return container;
    }

    private void Method(SerializedPropertyChangeEvent evt)
    {
        Debug.Log($"M {evt} {evt.changedProperty.type}");
        // evt.changedProperty.serializedObject.Update();
        // EditorApplication.update.Invoke();
        // EditorUtility.SetDirty( evt.changedProperty.serializedObject.targetObject );// Repaint
        // evt.changedProperty.serializedObject.ApplyModifiedProperties();
        // evt.changedProperty.serializedObject.Update();
        // HandleUtility.Repaint();
        
            // PropertyField easeOvershootOrAmplitudeField = new PropertyField(property.FindPropertyRelative("easeOvershootOrAmplitude"));
            // easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)evt.changedProperty.enumValueIndex);
            
            // PropertyField easePeriodField = new PropertyField(property.FindPropertyRelative("easePeriod"));
            // easePeriodField.visible = EasingUsesOvershoorOrAmplitude((Ease)evt.changedProperty.enumValueIndex);
    }

    private static bool EasingUsesOvershoorOrAmplitude(Ease ease)
    {
        return Ease.InElastic <= ease && ease <= Ease.INTERNAL_Custom && ease != Ease.INTERNAL_Zero;
    }
    
    private static bool EasingUsesPeriod(Ease ease)
    {
        return Ease.InElastic <= ease && ease <= Ease.INTERNAL_Custom && ease != Ease.INTERNAL_Zero
            && ease != Ease.InBack && ease != Ease.OutBack && ease != Ease.InOutBack;
    }
}
