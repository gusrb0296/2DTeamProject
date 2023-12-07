# 🎈 PANG!


고기 4조 팀과제입니다. 


[💭팀 노션 링크](https://www.notion.so/4-a085c4b31ce84484a60b3d391a565573)


[🎞시연 영상 링크(추가 예정)]()


---
## ❓ 우리 게임은요

- 닷지, 벽돌 부수기 게임을 응용했습니다.
- [나롱이 공피하기 게임](https://youtu.be/zXnNV9PcvH0?si=TPXeWjl2l2GFIewq)과 [고전 게임 Pang](https://youtu.be/UyhP6uLk9Fg?si=drdIqZ_-1C-Yd-6V)에서 아이디어를 얻었습니다.
- 총 3가지의 게임 모드(Easy, Normal, Hard)가 존재합니다. 
- 각 모드마다 생성되는 공의 개수가 다르고, 공을 총알로 맞추면 공이 파괴되면서 2개로 분열합니다.
- 공을 총알로 맞추면 일정 확률로 아이템을 획득할 수 있습니다. 
- 다양한 아이템이 존재하여 사용자의 플레이 경험을 보다 풍성하게 만들어 줍니다. 
- 플레이어가 대쉬 기능을 써서 공격하거나 공을 피할 수 있습니다.


---
## 🎮 게임 플레이 방법


1. 캐릭터 이동은 키보드 A, D키 또는 방향키 ←, →로 가능합니다. 
2. 대쉬는 Ctrl, 공격은 SPACE BAR를 눌러 주세요.
3. 모든 공을 파괴하면 게임을 클리어할 수 있습니다!
4. 플레이어의 목숨이 다 사라지면 게임 오버가 됩니다.




---
## 🙋🏻‍♀️ 역할 분담

- 캐릭터, 피격 - 장성규
- 공 - 고현규
- 공격 시스템, 아이템 - 이준호
- 시작 씬, 게임&UI 매니저 - 박정혁
- 메인 씬 UI - 변정민


---
## 📚 기술 스택

### Environment
1. Visual Studio
2. Git
3. GitHub


### Development
1. C#


### Communication
1. Zep
2. Slack
3. Notion




---
## ⭐ Scene별 구현 사항


1. IntroScene


   1-1. 고기 4조 로고 애니메이션, 효과음 추가


2. StartScene


   2-1. 게임 시작, 설정, 게임 설명, 게임 종료 버튼 존재

   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. 게임 시작 버튼 클릭 시 난이도를 고를 수 있음, 난이도는 PlayerPrefs에 저장


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. 설정에서는 배경음악의 볼륨과 음소거 여부를 설정할 수 있음


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. 게임 종료 버튼 클릭 시 Application.Quit()를 이용하여 실제 앱에서 버튼을 누르면 종료됨

   
3. LoadingScene

   
   3-1. 오브젝트 풀링에 걸리는 시간을 로딩 화면으로 대체


4. MainScene


   4-1. 



---
### 🔗 참고
1. 
