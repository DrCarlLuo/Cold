using UnityEngine;

namespace Cold
{
    using TeamMask = Const.TeamMask;
    [RequireComponent(typeof(PawnController))]
    public class HeroController : MonoBehaviour
    {
        PawnController pawn;
        HeroState hero;
        ClawController claw;
        public Transform fireHeapPointerArrow;
        public float pointerArrowMinShowRange;
        void Start()
        {
            pawn = transform.GetComponent<PawnController>();
            hero = transform.GetComponent<HeroState>();
            claw = transform.GetComponentInChildren<ClawController>();
        }
        void Update()
        {
            if (hero.IsDead)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                claw.PickAndDrop();
            }
            Vector3 mov = new Vector3(
              Input.GetAxis(Const.Horizontal),
              Input.GetAxis(Const.Vertical),
              0f
            );
            pawn.MoveBy(mov);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            pawn.TargetAt(Camera.main.ScreenToWorldPoint(mousePos));

            Vector3 firePlaceVec = GameCore.I.fireHeap.transform.position - transform.position;
            firePlaceVec.z = 0f;
            fireHeapPointerArrow.rotation = Quaternion.Euler(0f, 0f, Vector3.SignedAngle(Vector3.up, firePlaceVec, Vector3.forward));

            float fireHeapDist = Vector3.Distance(transform.position, GameCore.I.fireHeap.transform.position);
            if (fireHeapDist > pointerArrowMinShowRange)
                fireHeapPointerArrow.gameObject.SetActive(true);
            else
                fireHeapPointerArrow.gameObject.SetActive(false);
        }
    }
}
