namespace Algorithm.Structures
{
    public class Vertex
    {
        public int Number { get; set; }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }
    }
}