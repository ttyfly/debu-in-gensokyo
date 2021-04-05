using System;
using Microsoft.Xna.Framework;

namespace DebuInGensokyo.Utility
{
    class Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        private Transform parent;
        public Transform(Vector2 position, float rotation, Vector2 scale, Transform parent)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.parent = parent;
        }
        public Vector2 absolutePostion
        {
            get { return parent.position + Vector2.Transform(position, Matrix.CreateRotationZ(rotation)); }
        }
        public float absoluteRotation
        {
            get { return parent.rotation + rotation; }
        }
        public Vector2 absoluteScale
        {
            get { return parent.scale * Vector2.Transform(scale, Matrix.CreateRotationZ(rotation)); }
        }
    }
}