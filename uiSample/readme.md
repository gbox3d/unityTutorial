# UI sample

## bassic sample

## custom editor 만들기


MyCustomScript.cs 에 대한 커스텀 에디터를 만들고 싶다면 MyCustomScriptEditor.cs 파일을 만들고 아래와 같이 네임스페이스를 가져옵니다.  

```csharp
using UnityEditor;
using UnityEngine;
```

CustomEditor 어트리뷰트를 사용하여 대상 클래스를 지정합니다. 이 예제에서는 MyCustomScript라는 클래스를 대상으로 합니다.  

```csharp
[CustomEditor(typeof(MyCustomScript))]
```

OnInspectorGUI 메서드를 오버라이드하여 사용자 인터페이스(UI)를 정의합니다.  

```csharp
public override void OnInspectorGUI()
{
    // Draw the default inspector
    DrawDefaultInspector();

    // Get the object that the script is attached to
    MyCustomScript myScript = (MyCustomScript)target;

    // Display a button that will call the function when pressed
    if (GUILayout.Button("Do Something"))
    {
        myScript.DoSomething();
    }
}
```



## 참고자료
https://learnandcreate.tistory.com/657  
https://learn.unity.com/tutorial/editor-scripting#  


