# 13Group-UnityProject FBWG

## 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀원소개](#팀원-소개)
3. [Git구성](##Git-구성)
4. [주요기능](#주요기능)
5. [개발기간](#개발기간)

<br>

---

<br>

# 프로젝트 소개
## 프로젝트 명 : FBWG
레퍼런스 게임 : Fire Boy & Water Girl  
- Coop(Local) - 혼자 두 플레이어블 캐릭터를 조종하거나 로컬 플레이로 2인 플레이
- Puzzle - 각 스테이지마다 레버, 버튼, 문, 장애물 등 다양한 퍼즐 요소들이 있고, 이를 해결해야 다음 단계로 진행
- 2D Platformer - 점프하고, 달리고, 함정을 밟지 않도록 조심해야 하는 2D 횡스크롤 스타일을 기반

개조를 하지 않고 주어진 목표를 모두 달성 하며 각 기능 하나씩 뜯어보며 디테일 하게 공부 하는것을 목표 <br>
결국 플레이어블 캐릭터, 맵, 오브젝트 등 디자인 관련된  부분만 직접 제작 하고 플레이 방식은 레퍼런스 게임을 차용 <br>
3개의 스테이지(맵) 으로 구성 하고 직접 테스트 해보며 난이도에 맞게 1,2,3 으로 구성 <br>

플레이 목표 : 최대한 빠른 시간안에 함정들을 피해 보석을 모두 획득 하고 탈출

구상 : https://www.figma.com/design/a9oW9nVaJ4vdqM4ypm0CRh/%ED%8C%8C%EC%9D%B4%EC%96%B4%EC%9B%8C%ED%84%B0%EA%B1%B8-%ED%8F%AC%EB%A0%88%EC%8A%A4%ED%8A%B8%ED%85%9C%ED%94%8C-?node-id=0-1&p=f&t=9nve6xKY5pV1dkGf-0

<br>

---

<br>

## 팀원 소개

### 오경민님
- 캐릭터 기본 이동(각 캐릭터 독립적인 이동 방식)
- 캐릭터 고유 능력 (각 캐릭터와 상반되는 속성의 함정을 밟으면 게임 오버)
- Git 관리 감독

### 이명은님
- 캐릭터 전용 오브젝트 추가(보석)
- 발판으로 사용하거나 버튼을 누를때 사용할 오브젝트
- 스위치, 버튼 등 이에 대응하는 플랫폼 요소들

### 김기태님
- 레벨 디자인 및 퍼즐 요소 구현
- 맵 구현
- 발표 PPT 제작 및 발표

### 정찬혁님
- 네트워크 동기화 담당의 이미지 제작
- 맵 구현
- 게임 테스트 관리

### 송성현
- UI 제작 , 폰트
- 점수 기능 구현
- 피그마 설계(기획)

<br>

---

<br>

# Git 구성

Github Repos<br>
-- master (root)<br>
---- feature<br>
------ feature/character<br>
------ feature/object (보석)<br>
------ feature/obstacle<br>
------ feature/map<br>
------ feature/input<br>
------ feature/data<br>
------ feature/sound<br>
------ feature/ui<br>
---- origin<br>
------ origin/develop<br>
------ origin/feature/management<br>
------ origin/hotfix/map<br>
---- resource (이미지, 음악)<br>
---- docs (README.md)<br>


<img width="537" height="652" alt="image" src="https://github.com/user-attachments/assets/66874611-0ed3-4b92-830d-062a5c852837" />
