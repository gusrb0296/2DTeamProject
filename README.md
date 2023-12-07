<div align="center">
<h1>🎈 PANG!</h1>



🥩 고기 4조 팀과제입니다. 🥩


[💭팀 노션 링크](https://www.notion.so/4-a085c4b31ce84484a60b3d391a565573)


[🎞시연 영상 링크](https://youtu.be/2llP04BCyWE)
</div>


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
- 공 시스템 - 고현규
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


   4-1. GameManager, UIManager, SoundManager, ObjectManager로 관리


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. GameManager에서 Player가 사망을 했는지 게임을 클리어했는지를 판단 가능, 게임 난이도에 따라 공을 다르게 생성


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. UIManager에서 Player의 체력 또는 스테이지에 공이 남아있는지를 판단해 게임 클리어/오버 창 활성화


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;점수는 클리어 한 시간, 공 파괴 시 랜덤 한 점수, 플레이어의 남은 체력을 이용해 계산하여 최종 점수를 출력


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;배경은 난이도에 따라 다르게 나올 수 있도록 배열로 지정한 뒤 해당 난이도에 따른 배경이 나오게 함
  

   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. SoundManager에서 난이도에 따른 배경음악 배열로 받아 재생


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;아이템 획득 시, 공이 분열할 때, 플레이어가 아이템을 먹었을 때, 플레이어가 공격 시, 플레이어와 공이 충돌 시, 게임 클리어/오버 시 효과음 추가


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iv. ObjectManager에서 사용이 많은 총알, 일회성 아이템에 오브젝트 풀링 이용


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;총알과 아이템을 미리 Instantiate하여 찍어두고 SetActive(false) 해두어 만듦


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;비활성화 된 오브젝트를 활성화시켜서 위치와 힘을 재지정 해주고 쏨


   4-2. 바운스 볼 시스템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. 큰 공은 스폰될 때 랜덤한 위치에서 등장, 단위 벡터를 갖고 좌 혹은 우로 이동


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. 공은 크기별로 3종류 존재, 크기가 큰 순서대로 플레이어에게 각각 3, 2, 1의 데미지를 가함


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. 공이 파괴되면 작은 공으로 쪼개지며 좌우로 이동, 일정 확률로 무기 아이템 드랍


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iv. 공이 생성될때마다 랜덤하게 세 스프라이트 중 하나로 정해짐


   4-3. 플레이어


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. 키보드의 A, D키 또는 방향키 ←, → 키를 이용하여 이동 가능


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. Space 키를 누를 때 공격하며 총알 발사 및 애니메이션 재생


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;공격 쿨타임 시 Space 키를 눌러도 공격 애니메이션이 재생되지 않음


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. Ctrl 키를 누르면 플레이어가 대쉬를 사용하며 고스팅 방식을 이용한 잔상 효과가 남음


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iv. 플레이어의 기본 체력은 10(하트 5개)이고, 하트는 반 개씩 감소할 수 있음


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v. 플레이어와 공과 부딪히면 공의 크기에 따라 체력이 깎이며 피격 애니메이션 재생


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vi. 플레이어의 체력이 0 이하로 떨어질 시 사망 애니메이션 재생



   4-4. 플레이어 공격


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. Space 키 입력이 발생하면 공격 로직 실행, 공격 시 쿨타임이 존재


   4-5. 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. 각 아이템은 5초 동안 지속되며 아이템이 바뀔 경우 다른 아이템 타입으로 다시 5초 스타트


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. Bullet Count Up(갯수 추가) 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;총알의 갯수가 2개로 나가고, Normal 총알보다 1.5배 빠름


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. Bullet Penetrate(관통) 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;총알이 공을 관통하고, Normal 총알보다 2배 빠름


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iv. Bullet Bounce(튕김) 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;공처럼 벽에 튕기며 공에 맞지 않을시 5번까지 튕기고 사라지고, Normal 총알보다 1.2배 빠름


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v. Bullet Guide(유도탄) 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;플레이어에게 가까운 공을 따라가는 총알을 발사, Normal 총알보다 1.5배 빠름


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vi. Ball Freezing(멈춤) 아이템


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5초동안 공만 움직임이 멈추고, 5초 뒤에 다시 공들이 움직임


   4-6. UI


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i. 화면 상단에 체력, 시간, 점수가 실시간으로 반영


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ii. 게임 클리어 및 오버 시 얻은 점수를 별로 표시한 판넬 활성화


   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iii. ESC키를 누르거나 Pause 버튼을 직접 누르면 이어하기, 다시하기, 게임 종료 버튼을 선택 가능한 판넬 활성화



