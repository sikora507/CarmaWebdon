namespace WebApplication1.Services.Data { 
    public struct PixDir
    {
        public PixFile[] Files { get; internal set; }
        public string Name { get; internal set; }
        public string Path { get; set; }
    }
}
