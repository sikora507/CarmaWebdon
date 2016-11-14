using OpenC1Logic.Xna;

namespace OpenC1Logic
{
    public class CWheelActor
    {
        public CActor Actor;
        public bool IsDriven;
        public Vector3 Position;
        public bool IsSteerable;

        public CWheelActor(CActor actor, bool driven, bool steerable)
        {
            Actor = actor;
            IsDriven = driven;
            IsSteerable = steerable;
        }

        public bool IsFront { get { return Actor.Name.StartsWith("F"); } }
        public bool IsLeft { get { return Actor.Name[1] == 'L'; } }
    }
}
