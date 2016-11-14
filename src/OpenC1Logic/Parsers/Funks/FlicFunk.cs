using System.Collections.Generic;

namespace OpenC1Logic.Parsers.Funks
{
    public class FlicFunk : BaseFunk
    {
        public FunkLoopType Loop { get; private set; }
        float _speed;
        //List<Texture2D> _frames;
        float _currentFrameTime;
        int _currentFrame;

        public FlicFunk(string fliname)
        {
            FliFile fli = ResourceCache.GetFliFile(fliname);
            //_frames = fli.Frames;
            _speed = (float)fli.FrameRate / 1000; // to seconds
        }


        public override void Update()
        {
            //if (_frames.Count == 0) return;

            //_currentFrameTime += Engine.ElapsedSeconds;
            //if (_currentFrameTime > _speed)
            //{
            //    _currentFrame++;
            //    if (_currentFrame == _frames.Count) _currentFrame = 0;
            //    _currentFrameTime = 0;

            //    Material.Texture = _frames[_currentFrame];
            //}
        }
    }
}
