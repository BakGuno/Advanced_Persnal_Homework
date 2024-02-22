# 게임개발 심화 개인 프로젝트 : 플래포머 게임 만들기
![image](https://github.com/BakGuno/Advanced_Persnal_Homework/assets/129590082/bbf917ed-e0bb-4612-8dbb-92c9ba3b9631)


## 소개
장애물에 부딪히지 않고 과일을 모으는 게입입니다.

## 사용 / 테스트 방법
- StartScene에서 Run 후 이리저리 테스트 해보면 됩니다.
## 시연 영상
- [Project : 곰 피하기](https://youtu.be/6yMxCCxOlJY)
## 개발 환경
  - Unity 3.2f

## 구현 내용 
1. DOTWeen을 이용해 UI가 이동하도록 해보았습니다.
2. UIManager를 활용해 필요에 따라 생성, 파괴하도록 하였습니다.
3. Tilemap을 이용하여 맵을 구성하였습니다.
4. Scriptable Object를 활용해 대화를 구성해보았습니다.

## 구현하지 못한 내용
1. FSM으로 Player의 상태를 구현하고자 생각했지만, 과하다고 생각하여 폐기하였습니다.
2. ObjectPooling으로 과일을 재사용하려 생각했지만 Stage를 씬 별로 구성하려 하였기에 불필요하다 판단하여 폐기했습니다.
3. 데이터 통신과 Json으로 대화를 구성해볼까 생각했지만, Json을 다운로드 받으면 LocalData를 처리하는 것과 별반 다르지 않아 Scriptable Object로 전환하였습니다.

## 문제사항
1. Stage1을 구성하고 Run했을 때 씬이 Not Load가 발생하며 Unity가 강제로 종료되는 현상

## 사용 패키지
1. Input System
2. TextMesh Pro
   
## 사용 에셋
1. [2D Background Kit](https://assetstore.unity.com/packages/2d/environments/2d-background-55095)
2. [2D Casual Game UI HD](https://assetstore.unity.com/packages/2d/gui/2d-casual-game-ui-hd-259245)
3. [Pixel Adventure 1](https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360)
4. [DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
