using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MarioDebono.Attributes.Editor
{

    [CustomPropertyDrawer(typeof(MinMaxAttribute))]
    public class MinMaxDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // cast the attribute to make life easier
            MinMaxAttribute minMax = attribute as MinMaxAttribute;
            var boxRect = new Rect(position.x - 2, position.y - 2, position.width + 4, position.height + 4);
            GUI.Box(boxRect, GUIContent.none);

            var sliderRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            var rect = new Rect(position.x + EditorGUIUtility.labelWidth, position.y + EditorGUIUtility.singleLineHeight, 50, EditorGUIUtility.singleLineHeight);

            if (property.propertyType == SerializedPropertyType.Vector2Int)
            {
                float minValue = property.vector2IntValue.x; // the currently set minimum and maximum value
                float maxValue = property.vector2IntValue.y;
                float minLimit = minMax.MinLimit; // the limit for both min and max, min cant go lower than minLimit and max cant top maxLimit
                float maxLimit = minMax.MaxLimit;


                EditorGUI.MinMaxSlider(sliderRect, label, ref minValue, ref maxValue, minLimit, maxLimit);
                minValue = EditorGUI.IntField(rect, (int)minValue);
                rect.x += 60;
                maxValue = EditorGUI.IntField(rect, (int)maxValue);
                if (maxValue < minValue)
                    maxValue = minValue;

                var vec = Vector2Int.zero; // save the results into the property!
                vec.x = (int)minValue;
                vec.y = (int)maxValue;
                property.vector2IntValue = vec;
            }

            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                float minValue = property.vector2Value.x; // the currently set minimum and maximum value
                float maxValue = property.vector2Value.y;
                float minLimit = minMax.MinLimit; // the limit for both min and max, min cant go lower than minLimit and max cant top maxLimit
                float maxLimit = minMax.MaxLimit;

                EditorGUI.MinMaxSlider(sliderRect, label, ref minValue, ref maxValue, minLimit, maxLimit);
                minValue = Mathf.Round(minValue * 1000f) / 1000f;
                maxValue = Mathf.Round(maxValue * 1000f) / 1000f;

                minValue = EditorGUI.FloatField(rect, minValue);
                rect.x += 60;
                maxValue = EditorGUI.FloatField(rect, maxValue);
                if (maxValue < minValue)
                    maxValue = minValue;

                var vec = Vector2.zero; // save the results into the property!
                vec.x = minValue;
                vec.y = maxValue;
                property.vector2Value = vec;
            }


        }
    }
}
