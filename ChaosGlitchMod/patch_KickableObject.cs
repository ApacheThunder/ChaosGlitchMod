using System;
using System.Collections;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;
using ChaosGlitchMod;

// Custom Copy of KickableObject. Mainly to set RollingDestroysSafely to false as default.
// Future instances of objects spawned by ObjectRandomizer end up with their Object class being changed.
// In those cases, non drum objects like tables/locked doors that inherit this class can cause exceptions in the game log.
// This can cause frame drops. So this object class has been cloned and the break on roll property disabled by default.
// A few other bools that are null by default have also now been set to proper values.
public class CustomKickableObject : DungeonPlaceableBehaviour, IPlayerInteractable, IPlaceConfigurable {
	// Token: 0x06007894 RID: 30868 RVA: 0x002F1E68 File Offset: 0x002F0068
	public CustomKickableObject() {
        rollSpeed = 6f;
        goopFrequency = 0.05f;
        goopRadius = 1f;
        breakTimerLength = 3f;
        RollingDestroysSafely = false;
        triggersBreakTimer = false;
        AllowTopWallTraversal = true;
        RollingBreakAnim = "red_barrel_break";
        m_lastOutlineDirection = (DungeonData.Direction)(-1);
	}

	// Token: 0x06007895 RID: 30869 RVA: 0x002F1EC0 File Offset: 0x002F00C0
	private void Start() {
            SpeculativeRigidbody specRigidbody = base.specRigidbody;
        try {
            specRigidbody.OnRigidbodyCollision = (SpeculativeRigidbody.OnRigidbodyCollisionDelegate)Delegate.Combine(specRigidbody.OnRigidbodyCollision, new SpeculativeRigidbody.OnRigidbodyCollisionDelegate(OnPlayerCollision));
        } catch (Exception ex) {
            if (ChaosConsole.DebugExceptions) { 
                ETGModConsole.Log("Exception Caught at [GetDistanceToPoint] in CustomKickableObject class.", false);
                ETGModConsole.Log(ex.Message + ex.Source, false);
                ETGModConsole.Log(ex.StackTrace, false);
            }
            return;
        }
    }

	// Token: 0x06007896 RID: 30870 RVA: 0x002F1EEC File Offset: 0x002F00EC
	public void Update()
	{
		if (m_shouldDisplayOutline)
		{
			int num;
			DungeonData.Direction inverseDirection = DungeonData.GetInverseDirection(DungeonData.GetDirectionFromIntVector2(GetFlipDirection(m_lastInteractingPlayer.specRigidbody, out num)));
			if (inverseDirection != m_lastOutlineDirection || sprite.spriteId != m_lastSpriteId)
			{
				SpriteOutlineManager.RemoveOutlineFromSprite(sprite, false);
				SpriteOutlineManager.AddSingleOutlineToSprite<tk2dSprite>(sprite, DungeonData.GetIntVector2FromDirection(inverseDirection), Color.white, 0.25f, 0f);
			}
            m_lastOutlineDirection = inverseDirection;
            m_lastSpriteId = sprite.spriteId;
		}
		if (leavesGoopTrail && specRigidbody.Velocity.magnitude > 0.1f)
		{
            m_goopElapsed += BraveTime.DeltaTime;
			if (m_goopElapsed > goopFrequency)
			{
                m_goopElapsed -= BraveTime.DeltaTime;
				if (m_goopManager == null)
				{
                    m_goopManager = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopType);
				}
                m_goopManager.AddGoopCircle(sprite.WorldCenter, goopRadius + 0.1f, -1, false, -1);
			}
			if (AllowTopWallTraversal && GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(sprite.WorldCenter.ToIntVector2(VectorConversions.Floor)) && GameManager.Instance.Dungeon.data[sprite.WorldCenter.ToIntVector2(VectorConversions.Floor)].IsFireplaceCell)
			{
				MinorBreakable component = GetComponent<MinorBreakable>();
				if (component && !component.IsBroken)
				{
					component.Break(Vector2.zero);
					GameStatsManager.Instance.SetFlag(GungeonFlags.FLAG_ROLLED_BARREL_INTO_FIREPLACE, true);
				}
			}
		}
	}

	// Token: 0x06007897 RID: 30871 RVA: 0x002F20C5 File Offset: 0x002F02C5
	public void ForceDeregister()
	{
		if (m_room != null) { m_room.DeregisterInteractable(this); }
		RoomHandler.unassignedInteractableObjects.Remove(this);
	}

	// Token: 0x06007898 RID: 30872 RVA: 0x001611C7 File Offset: 0x0015F3C7
	protected override void OnDestroy() { base.OnDestroy(); }

	// Token: 0x06007899 RID: 30873 RVA: 0x002F20EC File Offset: 0x002F02EC
	public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
	{
		shouldBeFlipped = false;
		Vector2 inVec = interactor.CenterPosition - specRigidbody.UnitCenter;
		switch (BraveMathCollege.VectorToQuadrant(inVec))
		{
		case 0:
			return "tablekick_down";
		case 1:
			shouldBeFlipped = true;
			return "tablekick_right";
		case 2:
			return "tablekick_up";
		case 3:
			return "tablekick_right";
		default:
			Debug.Log("fail");
			return "tablekick_up";
		}
	}

	// Token: 0x0600789A RID: 30874 RVA: 0x002F2164 File Offset: 0x002F0364
	public void OnEnteredRange(PlayerController interactor)
	{
		if (!this) { return; }
        m_lastInteractingPlayer = interactor;
        m_shouldDisplayOutline = true;
	}

	// Token: 0x0600789B RID: 30875 RVA: 0x002F2180 File Offset: 0x002F0380
	public void OnExitRange(PlayerController interactor)
	{
		if (!this) { return; }
        ClearOutlines();
        m_shouldDisplayOutline = false;
	}

	// Token: 0x0600789C RID: 30876 RVA: 0x002F219C File Offset: 0x002F039C
	public float GetDistanceToPoint(Vector2 point)
	{
        // Table Tech Rockets used on tables converted to kickableObjects can cause a softlock of player input not working
        // When this occurs, return a default value and destroy the object.
        try {
            Bounds bounds = sprite.GetBounds();
            bounds.SetMinMax(bounds.min + sprite.transform.position, bounds.max + sprite.transform.position);
            float num = Mathf.Max(Mathf.Min(point.x, bounds.max.x), bounds.min.x);
            float num2 = Mathf.Max(Mathf.Min(point.y, bounds.max.y), bounds.min.y);
            return Mathf.Sqrt((point.x - num) * (point.x - num) + (point.y - num2) * (point.y - num2));
        } catch (Exception ex) {
            if (ChaosConsole.DebugExceptions) { ETGModConsole.Log("Exception Caught at [GetDistanceToPoint] in CustomKickableObject class." + ex.Message + ex.Source + ex.InnerException + ex.StackTrace + ex.TargetSite, false); }
            float defaultFloat = 0f;
            Destroy(this);
            return defaultFloat;
        }
	}

	// Token: 0x0600789D RID: 30877 RVA: 0x00028AFF File Offset: 0x00026CFF
	public float GetOverrideMaxDistance() { return -1f; }

	// Token: 0x0600789E RID: 30878 RVA: 0x002F2288 File Offset: 0x002F0488
	public void Interact(PlayerController player)
	{
		GameManager.Instance.Dungeon.GetRoomFromPosition(specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Round)).DeregisterInteractable(this);
		RoomHandler.unassignedInteractableObjects.Remove(this);
        Kick(player.specRigidbody);
		AkSoundEngine.PostEvent("Play_OBJ_table_flip_01", player.gameObject);
        ClearOutlines();
        m_shouldDisplayOutline = false;
		if (GameManager.Instance.InTutorial) { GameManager.BroadcastRoomTalkDoerFsmEvent("playerRolledBarrel"); }
	}

	// Token: 0x0600789F RID: 30879 RVA: 0x002F230C File Offset: 0x002F050C
	private void NoPits(SpeculativeRigidbody specRigidbody, IntVector2 prevPixelOffset, IntVector2 pixelOffset, ref bool validLocation)
	{
		if (!validLocation) { return; }
		Func<IntVector2, bool> func = delegate(IntVector2 pixel)
		{
			Vector2 v = PhysicsEngine.PixelToUnitMidpoint(pixel);
			if (!GameManager.Instance.Dungeon.CellSupportsFalling(v)) { return false; }
			List<SpeculativeRigidbody> platformsAt = GameManager.Instance.Dungeon.GetPlatformsAt(v);
			if (platformsAt != null) {
				for (int i = 0; i < platformsAt.Count; i++) {
					if (platformsAt[i].PrimaryPixelCollider.ContainsPixel(pixel)) { return false; }
				}
			}
			return true;
		};
		PixelCollider primaryPixelCollider = specRigidbody.PrimaryPixelCollider;
		if (primaryPixelCollider != null)
		{
			IntVector2 a = pixelOffset - prevPixelOffset;
			if (a == IntVector2.Down && func(primaryPixelCollider.LowerLeft + pixelOffset) && func(primaryPixelCollider.LowerRight + pixelOffset) && (!func(primaryPixelCollider.UpperRight + prevPixelOffset) || !func(primaryPixelCollider.UpperLeft + prevPixelOffset)))
			{
				validLocation = false;
			}
			else if (a == IntVector2.Right && func(primaryPixelCollider.LowerRight + pixelOffset) && func(primaryPixelCollider.UpperRight + pixelOffset) && (!func(primaryPixelCollider.UpperLeft + prevPixelOffset) || !func(primaryPixelCollider.LowerLeft + prevPixelOffset)))
			{
				validLocation = false;
			}
			else if (a == IntVector2.Up && func(primaryPixelCollider.UpperRight + pixelOffset) && func(primaryPixelCollider.UpperLeft + pixelOffset) && (!func(primaryPixelCollider.LowerLeft + prevPixelOffset) || !func(primaryPixelCollider.LowerRight + prevPixelOffset)))
			{
				validLocation = false;
			}
			else if (a == IntVector2.Left && func(primaryPixelCollider.UpperLeft + pixelOffset) && func(primaryPixelCollider.LowerLeft + pixelOffset) && (!func(primaryPixelCollider.LowerRight + prevPixelOffset) || !func(primaryPixelCollider.UpperRight + prevPixelOffset)))
			{
				validLocation = false;
			}
		}
		if (!validLocation) { StopRolling(true); }
	}

	// Token: 0x060078A0 RID: 30880 RVA: 0x002F2533 File Offset: 0x002F0733
	public void ConfigureOnPlacement(RoomHandler room) { m_room = room; }

	// Token: 0x060078A1 RID: 30881 RVA: 0x002F253C File Offset: 0x002F073C
	private void OnPlayerCollision(CollisionData rigidbodyCollision) {
		PlayerController component = rigidbodyCollision.OtherRigidbody.GetComponent<PlayerController>();
		if (RollingDestroysSafely && component != null && component.IsDodgeRolling)
		{
			MinorBreakable component2 = GetComponent<MinorBreakable>();
			component2.destroyOnBreak = true;
			component2.makeParallelOnBreak = false;
			component2.breakAnimName = RollingBreakAnim;
			component2.explodesOnBreak = false;
			component2.Break(-rigidbodyCollision.Normal);
		}
	}

	// Token: 0x060078A2 RID: 30882 RVA: 0x002F25B0 File Offset: 0x002F07B0
	private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		MinorBreakable component = otherRigidbody.GetComponent<MinorBreakable>();
		if (component && !component.onlyVulnerableToGunfire && !component.IsBig)
		{
			component.Break(specRigidbody.Velocity);
			PhysicsEngine.SkipCollision = true;
		}
		if (otherRigidbody && otherRigidbody.aiActor && !otherRigidbody.aiActor.IsNormalEnemy) { PhysicsEngine.SkipCollision = true; }
	}

	// Token: 0x060078A3 RID: 30883 RVA: 0x002F2630 File Offset: 0x002F0830
	private void OnCollision(CollisionData collision)
	{
		if (collision.collisionType == CollisionData.CollisionType.Rigidbody && collision.OtherRigidbody.projectile != null) { return; }
		if (((BraveMathCollege.ActualSign(specRigidbody.Velocity.x) != 0f && Mathf.Sign(collision.Normal.x) != Mathf.Sign(specRigidbody.Velocity.x)) || (BraveMathCollege.ActualSign(specRigidbody.Velocity.y) != 0f && Mathf.Sign(collision.Normal.y) != Mathf.Sign(specRigidbody.Velocity.y))) && ((BraveMathCollege.ActualSign(specRigidbody.Velocity.x) != 0f && Mathf.Sign(collision.Contact.x - specRigidbody.UnitCenter.x) == Mathf.Sign(specRigidbody.Velocity.x)) || (BraveMathCollege.ActualSign(specRigidbody.Velocity.y) != 0f && Mathf.Sign(collision.Contact.y - specRigidbody.UnitCenter.y) == Mathf.Sign(specRigidbody.Velocity.y))))
		{
            StopRolling(collision.collisionType == CollisionData.CollisionType.TileMap);
		}
	}

	// Token: 0x060078A4 RID: 30884 RVA: 0x002F27BC File Offset: 0x002F09BC
	private bool IsRollAnimation() {
		for (int i = 0; i < rollAnimations.Length; i++) {
			if (spriteAnimator.CurrentClip.name == rollAnimations[i]) { return true; }
		}
		return false;
	}

	// Token: 0x060078A5 RID: 30885 RVA: 0x002F2808 File Offset: 0x002F0A08
	private void StopRolling(bool bounceBack)
	{
		if (bounceBack && !m_isBouncingBack) {
            StartCoroutine(HandleBounceback());
		} else {
			spriteAnimator.Stop();
			if (IsRollAnimation()) {
				tk2dSpriteAnimationClip currentClip = spriteAnimator.CurrentClip;
				spriteAnimator.Stop();
				spriteAnimator.Sprite.SetSprite(currentClip.frames[currentClip.frames.Length - 1].spriteId);
			}
			base.specRigidbody.Velocity = Vector2.zero;
			MinorBreakable component = GetComponent<MinorBreakable>();
			if (component != null) { component.onlyVulnerableToGunfire = false; }
			SpeculativeRigidbody specRigidbody = base.specRigidbody;
			specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Remove(specRigidbody.OnCollision, new Action<CollisionData>(OnCollision));
			SpeculativeRigidbody specRigidbody2 = base.specRigidbody;
			specRigidbody2.MovementRestrictor = (SpeculativeRigidbody.MovementRestrictorDelegate)Delegate.Remove(specRigidbody2.MovementRestrictor, new SpeculativeRigidbody.MovementRestrictorDelegate(NoPits));
			RoomHandler.unassignedInteractableObjects.Add(this);
            m_isBouncingBack = false;
		}
	}

	// Token: 0x060078A6 RID: 30886 RVA: 0x002F2918 File Offset: 0x002F0B18
	private IEnumerator HandleBounceback()
	{
		if (m_lastDirectionKicked != null) {
            m_isBouncingBack = true;
			Vector2 dirToMove = m_lastDirectionKicked.Value.ToVector2().normalized * -1f;
			int quadrant = BraveMathCollege.VectorToQuadrant(dirToMove);
            specRigidbody.Velocity = rollSpeed * dirToMove;
			IntVector2? lastDirectionKicked = m_lastDirectionKicked;
            m_lastDirectionKicked = ((lastDirectionKicked == null) ? null : new IntVector2?(lastDirectionKicked.GetValueOrDefault() * -1));
			tk2dSpriteAnimationClip rollClip = spriteAnimator.GetClipByName(rollAnimations[quadrant]);
			if (rollClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.LoopSection) {
                spriteAnimator.PlayFromFrame(rollClip, rollClip.loopStart);
			} else {
                spriteAnimator.Play(rollClip);
			}
			float ela = 0f;
			float dura = 1.5f / specRigidbody.Velocity.magnitude;
			while (ela < dura && m_isBouncingBack) {
				ela += BraveTime.DeltaTime;
                specRigidbody.Velocity = rollSpeed * dirToMove;
				yield return null;
			}
			if (m_isBouncingBack) { StopRolling(false); }
		}
		yield break;
	}

	// Token: 0x060078A7 RID: 30887 RVA: 0x002F2933 File Offset: 0x002F0B33
	private void ClearOutlines()
	{
        m_lastOutlineDirection = (DungeonData.Direction)(-1);
        m_lastSpriteId = -1;
		SpriteOutlineManager.RemoveOutlineFromSprite(sprite, false);
	}

	// Token: 0x060078A8 RID: 30888 RVA: 0x002F2950 File Offset: 0x002F0B50
	private IEnumerator HandleBreakTimer()
	{
        m_timerIsActive = true;
		if (timerVFX != null) { timerVFX.SetActive(true); }
		yield return new WaitForSeconds(breakTimerLength);
        minorBreakable.Break();
		yield break;
	}

	// Token: 0x060078A9 RID: 30889 RVA: 0x002F296C File Offset: 0x002F0B6C
	private void RemoveFromRoomHierarchy()
	{
		Transform hierarchyParent = base.transform.position.GetAbsoluteRoom().hierarchyParent;
		Transform transform = base.transform;
		while (transform.parent != null) {
			if (transform.parent == hierarchyParent) {
				transform.parent = null;
				break;
			}
			transform = transform.parent;
		}
	}

	// Token: 0x060078AA RID: 30890 RVA: 0x002F29D0 File Offset: 0x002F0BD0
	private void Kick(SpeculativeRigidbody kickerRigidbody)
	{

        // if (BraveUtility.RandomBool()) { SelfDestructOnKick(); }
        Invoke("SelfDestructOnKick", UnityEngine.Random.Range(0.25f, 3f));

        try {
            if (base.specRigidbody && !base.specRigidbody.enabled) { return; }
            RemoveFromRoomHierarchy();
            List<SpeculativeRigidbody> overlappingRigidbodies = PhysicsEngine.Instance.GetOverlappingRigidbodies(base.specRigidbody.PrimaryPixelCollider, null, false);
            for (int i = 0; i < overlappingRigidbodies.Count; i++) {
                if (overlappingRigidbodies[i] && overlappingRigidbodies[i].minorBreakable && !overlappingRigidbodies[i].minorBreakable.IsBroken && !overlappingRigidbodies[i].minorBreakable.onlyVulnerableToGunfire && !overlappingRigidbodies[i].minorBreakable.OnlyBrokenByCode) {
                    overlappingRigidbodies[i].minorBreakable.Break();
                }
            }
            int value = ~CollisionMask.LayerToMask(CollisionLayer.PlayerCollider, CollisionLayer.PlayerHitBox);

            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(base.specRigidbody, new int?(value), false);

            SpeculativeRigidbody specRigidbody = base.specRigidbody;
            specRigidbody.MovementRestrictor = (SpeculativeRigidbody.MovementRestrictorDelegate)Delegate.Combine(specRigidbody.MovementRestrictor, new SpeculativeRigidbody.MovementRestrictorDelegate(NoPits));
            SpeculativeRigidbody specRigidbody2 = base.specRigidbody;
            specRigidbody2.OnCollision = (Action<CollisionData>)Delegate.Combine(specRigidbody2.OnCollision, new Action<CollisionData>(OnCollision));
            SpeculativeRigidbody specRigidbody3 = base.specRigidbody;
            specRigidbody3.OnPreRigidbodyCollision = (SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate)Delegate.Combine(specRigidbody3.OnPreRigidbodyCollision, new SpeculativeRigidbody.OnPreRigidbodyCollisionDelegate(OnPreCollision));
            int num;
            IntVector2 flipDirection = GetFlipDirection(kickerRigidbody, out num);
            if (AllowTopWallTraversal) { base.specRigidbody.AddCollisionLayerOverride(CollisionMask.LayerToMask(CollisionLayer.EnemyBlocker)); }
            base.specRigidbody.Velocity = rollSpeed * flipDirection.ToVector2();
            tk2dSpriteAnimationClip clipByName = spriteAnimator.GetClipByName(rollAnimations[num]);
            bool flag = false;
            if (m_lastDirectionKicked != null) {
                if (m_lastDirectionKicked.Value.y == 0 && flipDirection.y == 0) { flag = true; }
                if (m_lastDirectionKicked.Value.x == 0 && flipDirection.x == 0) { flag = true; }
            }
            if (clipByName != null && clipByName.wrapMode == tk2dSpriteAnimationClip.WrapMode.LoopSection && flag) {
                spriteAnimator.PlayFromFrame(clipByName, clipByName.loopStart);
            } else { spriteAnimator.Play(clipByName); }

            if (triggersBreakTimer && !m_timerIsActive) { StartCoroutine(HandleBreakTimer()); }
            MinorBreakable component = GetComponent<MinorBreakable>();
            if (component != null) { component.breakAnimName = impactAnimations[num]; component.onlyVulnerableToGunfire = true; }
            IntVector2 key = transform.PositionVector2().ToIntVector2(VectorConversions.Round);
            GameManager.Instance.Dungeon.data[key].isOccupied = false;
            m_lastDirectionKicked = new IntVector2?(flipDirection);

        } catch (Exception) {
            if (ChaosConsole.DebugExceptions) { ETGModConsole.Log("Exception Caught at [Kick] in CustomKickableObject class.", false); }
            return;
        }
	}

	// Token: 0x060078AB RID: 30891 RVA: 0x002F2CD8 File Offset: 0x002F0ED8
	public IntVector2 GetFlipDirection(SpeculativeRigidbody kickerRigidbody, out int quadrant) {
		Vector2 inVec = specRigidbody.UnitCenter - kickerRigidbody.UnitCenter;
		quadrant = BraveMathCollege.VectorToQuadrant(inVec);
		return IntVector2.Cardinals[quadrant];
	}

    private void SelfDestructOnKick()
    {
        int currentCurse = PlayerStats.GetTotalCurse();
        int currentCoolness = PlayerStats.GetTotalCoolness();
        float ExplodeOnKickChances = 0.25f;
        float ExplodeOnKickDamageToEnemies = 150f;
        bool ExplodeOnKickDamagesPlayer = BraveUtility.RandomBool();

        if (currentCoolness >= 3) {
            ExplodeOnKickDamagesPlayer = false;
            ExplodeOnKickDamageToEnemies = 175f;
        }
        if (currentCurse >= 3) {
            ExplodeOnKickChances = 0.35f;
            ExplodeOnKickDamageToEnemies = 200f;
        }

        if (UnityEngine.Random.value <= ExplodeOnKickChances && ChaosConsole.isUltraMode) {
            Exploder.DoDefaultExplosion(sprite.WorldCenter, sprite.WorldCenter, null, true, CoreDamageTypes.SpecialBossDamage);
            Exploder.DoRadialDamage(ExplodeOnKickDamageToEnemies, sprite.WorldCenter, 4.5f, ExplodeOnKickDamagesPlayer, true, true);
        }
        return;
    }

    // Token: 0x040079F8 RID: 31224
    public float rollSpeed;

	// Token: 0x040079F9 RID: 31225
	[CheckAnimation(null)]
	public string[] rollAnimations;

	// Token: 0x040079FA RID: 31226
	[CheckAnimation(null)]
	public string[] impactAnimations;

	// Token: 0x040079FB RID: 31227
	public bool leavesGoopTrail;

	// Token: 0x040079FC RID: 31228
	[ShowInInspectorIf("leavesGoopTrail", false)]
	public GoopDefinition goopType;

	// Token: 0x040079FD RID: 31229
	[ShowInInspectorIf("leavesGoopTrail", false)]
	public float goopFrequency;

	// Token: 0x040079FE RID: 31230
	[ShowInInspectorIf("leavesGoopTrail", false)]
	public float goopRadius;

	// Token: 0x040079FF RID: 31231
	public bool triggersBreakTimer;

	// Token: 0x04007A00 RID: 31232
	[ShowInInspectorIf("triggersBreakTimer", false)]
	public float breakTimerLength;

	// Token: 0x04007A01 RID: 31233
	[ShowInInspectorIf("triggersBreakTimer", false)]
	public GameObject timerVFX;

	// Token: 0x04007A02 RID: 31234
	public bool RollingDestroysSafely;

	// Token: 0x04007A03 RID: 31235
	public string RollingBreakAnim;

	// Token: 0x04007A04 RID: 31236
	private float m_goopElapsed;

	// Token: 0x04007A05 RID: 31237
	private DeadlyDeadlyGoopManager m_goopManager;

	// Token: 0x04007A06 RID: 31238
	private RoomHandler m_room;

	// Token: 0x04007A07 RID: 31239
	private bool m_isBouncingBack;

	// Token: 0x04007A08 RID: 31240
	private bool m_timerIsActive;

	// Token: 0x04007A09 RID: 31241
	[NonSerialized]
	public bool AllowTopWallTraversal;

	// Token: 0x04007A0A RID: 31242
	public IntVector2? m_lastDirectionKicked;

	// Token: 0x04007A0B RID: 31243
	private bool m_shouldDisplayOutline;

	// Token: 0x04007A0C RID: 31244
	private PlayerController m_lastInteractingPlayer;

	// Token: 0x04007A0D RID: 31245
	private DungeonData.Direction m_lastOutlineDirection;

	// Token: 0x04007A0E RID: 31246
	private int m_lastSpriteId;
}

