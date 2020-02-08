using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Cold
{
    public class GameCore : MonoBehaviour
    {
        #region inspector
        [SerializeField] Transform pfHero = null;
        [SerializeField] Transform pfWood = null;
        [SerializeField] Transform pfEnemy = null;
        [SerializeField] Transform sceneRoot = null;
        [SerializeField] Transform exitMenu = null;
        [SerializeField] Transform failMenu = null;
        [SerializeField] int initWoodCount = 0;
        [SerializeField] float enemyGenRate = 1f;
        [SerializeField] int enemyGenLimit = 10;
        [SerializeField] int dayPeriod = 60;
        [Range(0f,1f)][SerializeField] float dayNightRate = 0.2f;
        [SerializeField] UnityEngine.UI.Text timerText = null;
        #endregion
        public static GameCore I { get; private set; }
        [HideInInspector] public HeroState hero = null;
        [HideInInspector] public Transform SceneRoot => sceneRoot;
        float enemyGenTimer = 0;
        List<EnemyState> enemyList = new List<EnemyState>();
        public float CurrentGameTimeElapse { get; private set; }
        void Awake()
        {
            //if (I is null)
            //{
            //    I = this;
            //}
            I = this;
            hero = pfHero.GetComponent<HeroState>();
            hero.EventDead += DestoryPawn;
            hero.EventDead += GameFailCallBack;
        }
        void Start()
        {
            CurrentGameTimeElapse = 0f;
            Time.timeScale = 1f;
            for (int i = 0; i < initWoodCount; i++)
            {
                var pos = RandomPlaceCircle(1f, 4f);
                var wood = Instantiate(pfWood, pos, Quaternion.identity);
                wood.SetParent(sceneRoot);
            }
        }
        void Update()
        {
            CurrentGameTimeElapse = CurrentGameTimeElapse + Time.deltaTime;
            timerText.text = string.Format("{0:t}", System.TimeSpan.FromSeconds(Mathf.FloorToInt(CurrentGameTimeElapse)));
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            
            if (IsNight()
            && enemyList.Count < enemyGenLimit)
            {
                enemyGenTimer += Time.deltaTime * enemyGenRate;
                while (enemyGenTimer > 1f)
                {
                    enemyGenTimer -= 1f;
                    var pos = RandomPlaceCircle(1, 5f);
                    var enemyObj = Instantiate(pfEnemy, pos, Quaternion.identity);
                    enemyObj.SetParent(sceneRoot);
                    var enemy = enemyObj.GetComponent<EnemyState>();
                    enemy.EventDead += DestoryPawn;
                    enemyList.Add(enemy);
                }
            }
        }
        bool IsNight(){
            float dayTime = Mathf.FloorToInt(CurrentGameTimeElapse)/dayPeriod;
            dayTime = CurrentGameTimeElapse - CurrentGameTimeElapse*dayTime;
            return dayTime/dayPeriod > dayNightRate;
        }
        Vector3 RandomPlaceCircle(float innerRadius, float outterRadius)
        {
            float p = innerRadius + (outterRadius - innerRadius) * Random.Range(0, 1f);
            float t = 360f * Random.Range(0, 1f);
            return new Vector3(p * Mathf.Cos(t), p * Mathf.Sin(t), 0);
        }
        public void DestoryPawn(PawnState pawn)
        {
            if (pawn is EnemyState)
            {
                var item = enemyList.Find(it => it == pawn);
                enemyList.Remove(item);
            }
            else
            if (pawn is HeroState)
            {
                hero = null;
            }
            GameObject.Destroy(pawn.gameObject);
        }
        public void OnExitOk()
        {
            Application.Quit();
        }
        public void OnExitCancel()
        {
            Time.timeScale = 1f;
            exitMenu.gameObject.SetActive(false);
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene(0);
            //I = null;
            Time.timeScale = 1f;
        }

        public void GameFailCallBack(PawnState _)
        {
            Time.timeScale = 0f;
            failMenu.gameObject.SetActive(true);
        }

    }
}
