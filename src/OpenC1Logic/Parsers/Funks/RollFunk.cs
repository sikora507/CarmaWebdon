using OpenC1Logic.Xna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic.Parsers.Funks
{
    public class RollFunk : BaseFunk
    {
        public Vector2 Speed;
        Vector2 _uvOffset;
        //TextureAddressMode _lastMode;

        public RollFunk()
        {

        }

        public override void BeforeRender()
        {
            //_lastMode = Engine.Device.SamplerStates[0].AddressU;
            //if (_lastMode != TextureAddressMode.Wrap)
            //    Engine.Device.SamplerStates[0].AddressU = Engine.Device.SamplerStates[0].AddressV = TextureAddressMode.Wrap;

            //GameVars.CurrentEffect.TexCoordsOffset = _uvOffset;
            //GameVars.CurrentEffect.CommitChanges();
        }

        public override void AfterRender()
        {
            //if (_lastMode != TextureAddressMode.Wrap)
            //    Engine.Device.SamplerStates[0].AddressU = Engine.Device.SamplerStates[0].AddressV = _lastMode;

            //GameVars.CurrentEffect.TexCoordsOffset = Vector2.Zero;
            //GameVars.CurrentEffect.CommitChanges();
        }

        public override void Update()
        {
            //_uvOffset += Speed * 0.8f * Engine.ElapsedSeconds;
            //if (_uvOffset.X > 1) _uvOffset.X = 1 - _uvOffset.X;
            //if (_uvOffset.Y > 1) _uvOffset.Y = 1 - _uvOffset.Y;
        }
    }
}
