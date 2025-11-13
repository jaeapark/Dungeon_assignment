# Dungeon_assignment

1. 이동 및 점프

WASD 이동
마우스 룩
Spacebar 점프
Rigidbody + ForceMode.Impulse 사용

2. health / hunger UI 시스템

hunger값이 0이 되면 체력 감소
health 0 시 게임 씬 재시작

3. JumpPad

OnCollisionEnter + AddForce 사용

4. 동적 환경 조사 (Raycast)

Raycast로 플레이어 전방 오브젝트 탐지
조사 가능한 오브젝트(IInteractable)만 UI에 정보 표시
E 키로 상호작용

5. 아이템 시스템 (ScriptableObject)

ItemData ScriptableObject로 아이템 정보 관리
일반사과 사용 시 Hunger 회복
빨간사과 사용 시 게임 종료

6. 아이템 상호작용 (IInteractable)

아이템은 Interaction 사용해서 소비
먹으면 ItemObject → Player 로 아이템 데이터 전달
아이템 오브젝트는 자동 삭제

+추락시 게임 재시작

7.트러블슈팅
7-1) 플레이어가 공중에 뜨는 문제

CapsuleCollider와 지면 충돌이 겹쳐 있었음
Collider 위치 & Player Y수정으로 해결
ground에 mesh collider 생성

7-2) 체력 0 이지만 게임 종료 안 되는 문제

조건문 < 0 → <= 0 으로 수정

7-3) 아이템 설명/효과가 적용되지 않음

→ 아이템 Layer에 Interactable 레이어 설정 누락. 설정
