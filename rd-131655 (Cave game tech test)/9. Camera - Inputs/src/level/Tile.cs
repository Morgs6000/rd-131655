namespace RubyDung;

public class Tile {
    public static Tile tile = new Tile();

    public void OnLoad(Tesselator t) {
        float x0 = -0.5f;
        float y0 = -0.5f;

        float x1 = 0.5f;
        float y1 = 0.5f;

        float u0 = 0.0f;
        float v0 = (16.0f - 1.0f) / 16.0f;
        
        float u1 = u0 + (1.0f / 16.0f);
        float v1 = v0 + (1.0f / 16.0f);

        t.Tex(u0, v0);
        t.Vertex(x0, y0);
        t.Tex(u1, v0);
        t.Vertex(x1, y0);
        t.Tex(u1, v1);
        t.Vertex(x1, y1);
        t.Tex(u0, v1);
        t.Vertex(x0, y1);
    }
}