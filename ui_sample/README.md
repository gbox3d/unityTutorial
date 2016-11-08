##예제 1
캔버스를 게임오브잭트 자식으로 집어넣어서 게임오브잭트와 같이 변환하기
캔버스의 랜더모드 "world space" 이용

##예제2


##예제3


##예제4
기본이밴트처리

##예제5
uniRx를 활용 버튼 클릭 처리.

##예제6
uniRx를 활용한 인풋텍스트 예제. 

##예제7
uniRx를 활용한 여러가지 인풋 컴포넌트처리 예제. 

##예제 8
버튼 이외의 UI객체를 마우스로 클릭하는 효과 만들기
빈 게임오브잭트에 박스콜리더를 추가하고 자식으로 Canvas를 집어 넣어서 실제 마우스 체킹은 게임오브잭트가 함

##예제 9
GUI객체 인스턴싱예제 

##예제 10
RectTransform에 대한 마우스 드레그 효과 예제 

##예제 11
rectTransform 의 bound를 구하여 2디 충동검사에 응용하는 예제.
collusion2d 컴포넌트 없이 직접 충돌을 구할때 사용.
mybound = RectTransformUtility.CalculateRelativeRectTransformBounds(transform)


##예제 14
RectTransformUtility 사용 예제

1. ScreenPointToWorldPointInRectangle
gameobject.position에 넣을 좌표로 만들어 주기 위한 함수. 
마우스 좌표를 유니티의 recttransform 처리 하는 2d  좌표 맞게 바궈주는 예제
 마우스좌표를 ScreenPointToWorldPointInRectangle 로 변환하여 나온 결과를 원하는 오브잭트(recttransform)의 position에 넣어주면
 마우스 커서의 위치에 오게된다.

2. RectangleContainsScreenPoint 
현재의 마우스 좌표가 해당 영역(RectTransform)안에 있는지 검사한다