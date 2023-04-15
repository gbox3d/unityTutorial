## **scene01**    
평면과의 거리 구하기 , 메트리얼 색상 바꾸기 기즈모 이용해서 와이어 프레임 그리기  

### **평면과의 거리 구하기**

gameobject 로 평면 구하기  

```csharp
 public void UpdatePlane()
{
    myPlane = new Plane(transform.up, transform.position);
}
```

평면과의 거리 구하기  

```csharp
public float DistanceToPlane(Vector3 point)
{
    return myPlane.GetDistanceToPoint(point);
}
```

### **기즈모 이용하기**
기즈모는 에디터에서만 보여지는 오브젝트입니다.  

기즈모로 볼륨 큐브 보여주기  

```csharp
public void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(transform.position, transform.localScale);
}
```
와이어 프레임 그리기  

```csharp
void OnDrawGizmos()
{
    //와이어 프레임 그리기
    // 평면의 크기를 정의합니다. 크기는 평면의 절반 길이를 나타냅니다.
    float size = 5.0f;

    // 평면의 각 변에 대한 방향 벡터를 정의합니다.
    Vector3 right = transform.right * size;
    Vector3 forward = transform.forward * size;

    // 평면의 네 모서리를 계산합니다.
    Vector3 topLeft = transform.position - right + forward;
    Vector3 topRight = transform.position + right + forward;
    Vector3 bottomLeft = transform.position - right - forward;
    Vector3 bottomRight = transform.position + right - forward;

    // 기즈모의 색상을 설정합니다.
    Gizmos.color = Color.yellow;

    // 와이어 프레임 평면의 네 변을 그립니다.
    Gizmos.DrawLine(topLeft, topRight);
    Gizmos.DrawLine(topRight, bottomRight);
    Gizmos.DrawLine(bottomRight, bottomLeft);
    Gizmos.DrawLine(bottomLeft, topLeft);


    //법선그리기
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + transform.up * 5.0f);
}
```


### **오브잭트 색상 바꾸기**

스크립트에서 오브젝트의 기본 머티리얼 색상을 변경하려면 다음과 같이 코드를 작성할 수 있습니다. 

```csharp
Renderer rend = GetComponent<Renderer>();

if (rend != null)
{
    rend.material.color = Color.red;
}

```
