using System;
using DG.Tweening;
using DOTweenConfigs;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(TweenConfig))]
[CustomPropertyDrawer(typeof(ToTweenConfig<>))]
[CustomPropertyDrawer(typeof(Position3DTweenConfig))]
public class TweenConfigPropertyDrawer : PropertyDrawer
{
    private const int Indented = 15;

    // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    // {
    //     base.OnGUI(position, property, label);
    //     EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("duration"), GUIContent.none);
    // }
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        Debug.Log($"{property.type} {property.propertyType}");
        // Create property container element.
        // VisualElement container = new VisualElement();
        Foldout container = new Foldout() { text = property.displayName, value = true };
        // container.Clear();

        SerializedProperty easeProperty = property.FindPropertyRelative(nameof(TweenConfig.Ease));
        SerializedProperty loopsProperty = property.FindPropertyRelative(nameof(TweenConfig.Loops));

        // Create property fields.
        PropertyField durationField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.Duration)));
        PropertyField delayField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.Delay)));
        PropertyField easeField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.Ease)));
        PropertyField loopsField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.Loops)));
        // SerializedProperty loopType = property.FindPropertyRelative("loopType");
        
        PropertyField onStartField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnStart)));
        PropertyField onUpdateField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnUpdate)));
        PropertyField onCompleteField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnComplete)));
        PropertyField onCreatedField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnCreated)));
        PropertyField onKillField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnKill)));
        PropertyField onPlayField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnPlay)));
        PropertyField onPauseField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnPause)));
        PropertyField onRewindField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnRewind)));
        PropertyField onStepCompleteField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnStepComplete)));
        PropertyField onWaypointChangedField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.OnWaypointChanged)));
        
        PropertyField loopTypeField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.LoopType)));
        loopTypeField.RegisterCallback<GeometryChangedEvent>(_ => loopTypeField.Q<Label>().style.paddingLeft = Indented);
        
        
        PropertyField easeOvershootOrAmplitudeField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.EaseOvershootOrAmplitude)), "Overshoot Or Amplitude");
        // easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
        // easeOvershootOrAmplitudeField.style.display = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        // easeOvershootOrAmplitudeField.Q<Label>().style.paddingLeft = Indented;
        easeOvershootOrAmplitudeField.RegisterCallback<GeometryChangedEvent>(_ => easeOvershootOrAmplitudeField.Q<Label>().style.paddingLeft = Indented);
        
        PropertyField easePeriodField = new PropertyField(property.FindPropertyRelative(nameof(TweenConfig.EasePeriod)), "Period");
        // easePeriodField.visible = EasingUsesPeriod((Ease)easeProperty.enumValueIndex);
        // easePeriodField.style.display = EasingUsesPeriod((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        // easePeriodField.Q<Label>().style.paddingLeft = Indented;
        easePeriodField.RegisterCallback<GeometryChangedEvent>(_ => easePeriodField.Q<Label>().style.paddingLeft = Indented);
        
        // EnumField a = new EnumField().bin;
        
        
        container.Add(durationField);
        
        if (property.type != nameof(TweenConfig))
        {
            PropertyField toField = new PropertyField(property.FindPropertyRelative("to"));
            PropertyField fromField = new PropertyField(property.FindPropertyRelative("from"));
            container.Add(toField);
            container.Add(fromField);
        }


        // container.Add(new ToolbarSpacer() {name = "a", panel});
        // container.Add(new Box());
        // if (property.type != nameof(TweenConfig)) container.Add(new Label(" ")); //spacer
        // container.Add(new TextElement() { text = "hello"});
        if (property.type == nameof(Position3DTweenConfig))
        {
            PropertyField snappingField = new PropertyField(property.FindPropertyRelative(nameof(Position3DTweenConfig.Snapping)));
            container.Add(snappingField);
            // common.Add(snappingField);
        }

        Foldout common = new Foldout() { text = "Common", value = true };
        container.Add(common);
        

        
        // Add fields to the container.
        // container.Add(ease);
        // container.Add(easeField);
        
        // container.Add(easeOvershootOrAmplitudeField);
        // container.Add(easePeriodField);
        
        // container.Add(loopsField);
        // container.Add(loopTypeField);
        
        common.Add(easeField);        
        common.Add(easeOvershootOrAmplitudeField);
        common.Add(easePeriodField);
        
        common.Add(delayField);
        
        common.Add(loopsField);
        common.Add(loopTypeField);
        
        
        
        
        // TwoPaneSplitView myElement = new TwoPaneSplitView();

        // myElement.Add(loopsField);
        // myElement.Add(loopTypeField);
        
        // container.Add(myElement);
        
        
        // var toolbarMenu = new ToolbarMenu() { text = "Menu Text" };
        // toolbarMenu.menu.AppendAction("Menu item 1", (a) => { Debug.Log("Menu item 1 clicked"); });
        // toolbarMenu.menu.AppendAction("Menu item 2", (a) => { Debug.Log("Menu item 2 clicked"); });
        // toolbarMenu.menu.AppendAction("Menu item 3", (a) => { Debug.Log("Menu item 3 clicked"); });
        
        // container.Add(toolbarMenu);
        
        
        easeField.RegisterValueChangeCallback(Method);
        
        easeField.RegisterValueChangeCallback(e =>
        {
            Debug.Log($"Toggling visibility ease {(Ease)easeProperty.enumValueIndex} {(Ease)e.changedProperty.enumValueIndex}");
            // easeOvershootOrAmplitudeField.visible = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex);
            // easePeriodField.visible = EasingUsesPeriod((Ease)easeProperty.enumValueIndex);
            easeOvershootOrAmplitudeField.style.display = EasingUsesOvershoorOrAmplitude((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
            easePeriodField.style.display = EasingUsesPeriod((Ease)easeProperty.enumValueIndex) ? DisplayStyle.Flex : DisplayStyle.None;
        });
        
        loopsField.RegisterValueChangeCallback(e =>
        {
            Debug.Log($"Toggling visibility loops {loopsProperty.intValue} {e.changedProperty.intValue}");

            loopTypeField.style.display = loopsProperty.intValue == 1 ? DisplayStyle.None : DisplayStyle.Flex;
        });
        
        // easeField.RegisterValueChangeCallback(e =>
        // {
        //     Debug.Log($"Toggling visibility {(Ease)easeProperty.enumValueIndex} {(Ease)e.changedProperty.enumValueIndex}");
        //     container.MarkDirtyRepaint();
        // });
        
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

        Foldout events = new Foldout() { text = "Events", value = false };
        container.Add(events);
        
        events.Add(onStartField);
        events.Add(onUpdateField);
        events.Add(onCompleteField);
        
        Foldout allEvents = new Foldout() { text = "All Events", value = false };
        events.Add(allEvents);
        
        allEvents.Add(onCreatedField);
        allEvents.Add(onKillField);
        allEvents.Add(onPlayField);
        allEvents.Add(onPauseField);
        allEvents.Add(onRewindField);
        allEvents.Add(onStepCompleteField);
        allEvents.Add(onWaypointChangedField);

        // container.Add(loopTypeField);

        Foldout advanced = new Foldout() { text = "Advanced", value = false };
        container.Add(advanced);
        
        

        return container;
    }

    private void AddPadding(GeometryChangedEvent evt)
    {
        throw new NotImplementedException();
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
