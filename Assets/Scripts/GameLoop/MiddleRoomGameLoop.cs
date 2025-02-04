using UnityEngine;

namespace GameLoop
{
    public class MiddleRoomGameLoop : MonoBehaviour
    {
        private Facade.MiddleRoom.Facade _facade;
        // Start is called before the first frame update
        private void Start()
        {
            _facade = new Facade.MiddleRoom.Facade();
        }

        // Update is called once per frame
        private void Update()
        {
            _facade.GameUpdate();
        }
    }
}