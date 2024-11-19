## Basic 6주차 과제
Basic 6주차 과제 입니다.

## 학습 내용
> [🅾️❎퀴즈]
+  앵커와 피벗은 같은 기능을 한다. (X)
+ 피벗을 왼쪽 상단으로 설정하면, UI 요소는 화면의 왼쪽 상단을 기준으로 위치가 고정된다. (X)
+ 피벗을 UI 요소의 중심에 설정하면, 회전 시 UI 요소가 중심을 기준으로 회전한다. (O)

>[🤔 생각해보기]
+ 게임의 상단바와 같이 화면에 특정 영역에 꽉 차게 구성되는 UI와 
화면의 특정 영역에 특정한 크기로 등장하는 UI의 앵커 구성이 
어떻게 다른 지 설명해보세요.

→ 앵커의 좌표값에 따라 달라집니다. 특정 영역에 꽉 차게 구성되는 UI는
앵커 좌표가 0~1이 설정되지만 특정 영역에 특정한 크기로 등장하는 UI는
특정 영역에 맞게 앵커 좌표를 조절해줘야 합니다.

+ 돌아다니는 몬스터의 HP 바와 늘 고정되어있는 플레이어의 HP바는 Canvas 컴포넌트의 어떤 설정이 달라질 지 생각해보세요.

→ canvas에 render mode 설정이 달라집니다. 돌아다니는 몬스터의 HP 바는 실제 게임오브젝트 위에 있기 때문에
World Space를 사용하고 늘 고정되어있는 플레이어의 HP바는 위치가 고정되어야 하므로 Screen Space - Overlay를 사용합니다.

## 개발자 소개
+ 장병래 : 개발자
