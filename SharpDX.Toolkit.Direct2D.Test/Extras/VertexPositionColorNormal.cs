using System;
using SharpDX.Toolkit.Graphics;

namespace SharpDX.Toolkit.Direct2D.Test.Extras {
    public struct VertexPositionColorNormal //: IEquatable<VertexPositionColorNormal>
        : IEquatable<VertexPositionColorNormal> {
        /// <summary>
        /// Defines structure byte size.
        /// 
        /// </summary>
        public static readonly int Size = 28;
        /// <summary>
        /// XYZ position.
        /// 
        /// </summary>
        [VertexElement("SV_Position")]
        public Vector3 Position;
        /// <summary>
        /// The vertex color.
        /// 
        /// </summary>
        [VertexElement("COLOR")]
        public Color Color;
        /// <summary>
        /// The vertex normal.
        /// 
        /// </summary>
        [VertexElement("NORMAL")]
        public Vector3 Normal;

        static VertexPositionColorNormal()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="T:SharpDX.Toolkit.Graphics.VertexPositionColor"/> instance.
        /// 
        /// </summary>
        /// <param name="position">The position of this vertex.</param><param name="color">The color of this vertex.</param>
        public VertexPositionColorNormal(Vector3 position, Vector3 normal, Color color)
        {
            this = new VertexPositionColorNormal(); 
            this.Position = position;
            Normal = normal;
            this.Color = color;
        }

        public bool Equals(VertexPositionColorNormal other) {
            return Position.Equals(other.Position) && Color.Equals(other.Color) && Normal.Equals(other.Normal);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VertexPositionColorNormal && Equals((VertexPositionColorNormal) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Position.GetHashCode();
                hashCode = (hashCode*397) ^ Color.GetHashCode();
                hashCode = (hashCode*397) ^ Normal.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(VertexPositionColorNormal left, VertexPositionColorNormal right) {
            return left.Equals(right);
        }

        public static bool operator !=(VertexPositionColorNormal left, VertexPositionColorNormal right) {
            return !left.Equals(right);
        }
    }
}