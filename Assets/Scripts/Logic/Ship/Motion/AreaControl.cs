using UnityEngine;
using static UnityEngine.Camera;

namespace Logic.Ship.Motion
{
    public class AreaControl
    {
        private const float Retreat = 100;
        private const float RetreatTeleportation = 0.1f;
        
        private readonly Vector2 _borders;
        private Vector3 _scale;

        public AreaControl() => 
            _borders = new Vector2(Screen.width, Screen.height);

        public void CheckPositionInArea(GameObject obj)
        {
            var objPosition = obj.transform.position;
            Vector2 positionToScreenPoint = main!.WorldToScreenPoint(objPosition);
            Vector3 position = objPosition;
            
            if (positionToScreenPoint.x > _borders.x + Retreat)
            {
                position.x = -position.x + RetreatTeleportation;
            }
            else if (positionToScreenPoint.x < -Retreat)
            {
                position.x = -position.x - RetreatTeleportation;
            }
            else if (positionToScreenPoint.y > _borders.y + Retreat)
            {
                position.y = -position.y + RetreatTeleportation;
            }
            else if(positionToScreenPoint.y < -Retreat)
            {
                position.y = -position.y - RetreatTeleportation;
            }
            
            obj.transform.position = position;
        }
    }
}