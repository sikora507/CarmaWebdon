namespace OpenC1Logic.Parsers.Funks
{
    public enum FunkActivationType
    {
        Constant,
        Distance
    }


    public enum FunkLoopType
    {
        None,
        Continuous
    }

    public abstract class BaseFunk
    {
        public string MaterialName { get; set; }
        public CMaterial Material { get; set; }
        public FunkActivationType Activation { get; set; }

        public virtual void BeforeRender() { }
        public virtual void AfterRender() { }
        public abstract void Update();

        public virtual void Resolve()
        {
            CMaterial cm = ResourceCache.GetMaterial(MaterialName);
            if (cm == null) return;
            cm.Funk = this;
            Material = cm;
        }
    }
}
