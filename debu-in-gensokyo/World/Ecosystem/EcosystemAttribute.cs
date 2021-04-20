namespace DebuInGensokyo.World.Ecosystem
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    sealed class EcosystemAttribute : System.Attribute
    {
        readonly EcosystemType type;
        readonly uint minWidth;
        readonly uint maxWidth;
        readonly uint maxHeight;
        readonly uint altitude;
        readonly bool single;
        public EcosystemAttribute(EcosystemType type, uint minWidth, uint maxWidth, uint maxHeight, uint altitude, bool single)
        {
            this.type = type;
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
            this.altitude = altitude;
            this.single = single;
        }
        public EcosystemType Type
        {
            get { return type; }
        }
        public uint MinWidth
        {
            get { return minWidth; }
        }
        public uint MaxWidth
        {
            get { return maxWidth; }
        }
        public uint MaxHeight
        {
            get { return maxHeight; }
        }
        public uint Altitude
        {
            get { return altitude; }
        }
        public bool Single
        {
            get { return single; }
        }
    }
}