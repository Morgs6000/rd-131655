namespace RubyDung;

public class Tile {
    // Instancia estatica da classe Tile para ser acessada globalmente
    public static Tile tile = new Tile();

    // Metodo chamado para carregar os dados do tile (bloco) no Tesselator
    public void OnLoad(Tesselator t, Level level, int x, int y, int z) {
        // Define as coordenadas minimas e maximas do cubo (bloco)
        float x0 = (float)x + 0.0f; // Coordenada x minima
        float y0 = (float)y + 0.0f; // Coordenada y minima
        float z0 = (float)z + 0.0f; // Coordenada z minima

        float x1 = (float)x + 1.0f; // Coordenada x maxima
        float y1 = (float)y + 1.0f; // Coordenada y maxima
        float z1 = (float)z + 1.0f; // Coordenada z maxima

        // Define as coordenadas de textura iniciais (u0, v0) e finais (u1, v1)
        // u0 e v0 representam o canto inferior esquerdo da textura no atlas
        float u0 = 0.0f; // Coordenada u inicial
        float v0 = (16.0f - 1.0f) / 16.0f; // Coordenada v inicial
        
        // u1 e v1 representam o canto superior direito da textura no atlas
        float u1 = u0 + (1.0f / 16.0f); // Coordenada u final
        float v1 = v0 + (1.0f / 16.0f); // Coordenada v final

        // Face x0 (lado esquerdo do cubo)
        if(!level.IsSolidTile(x - 1, y, z)) {
            t.Tex(u0, v0); // Define a coordenada de textura
            t.Vertex(x0, y0, z0); // Define o vertice 0
            t.Tex(u1, v0);
            t.Vertex(x0, y0, z1); // Define o vertice 1
            t.Tex(u1, v1);
            t.Vertex(x0, y1, z1); // Define o vertice 2
            t.Tex(u0, v1);
            t.Vertex(x0, y1, z0); // Define o vertice 3
        }

        // Face x1 (lado direito do cubo)
        if(!level.IsSolidTile(x + 1, y, z)) {
            t.Tex(u0, v0);
            t.Vertex(x1, y0, z1); // Define o vertice 4
            t.Tex(u1, v0);
            t.Vertex(x1, y0, z0); // Define o vertice 5
            t.Tex(u1, v1);
            t.Vertex(x1, y1, z0); // Define o vertice 6
            t.Tex(u0, v1);
            t.Vertex(x1, y1, z1); // Define o vertice 7
        }

        // Face y0 (base do cubo)
        if(!level.IsSolidTile(x, y - 1, z)) {
            t.Tex(u0, v0);
            t.Vertex(x0, y0, z0); // Define o vertice 8
            t.Tex(u1, v0);
            t.Vertex(x1, y0, z0); // Define o vertice 9
            t.Tex(u1, v1);
            t.Vertex(x1, y0, z1); // Define o vertice 10
            t.Tex(u0, v1);
            t.Vertex(x0, y0, z1); // Define o vertice 11
        }

        // Face y1 (topo do cubo)
        if(!level.IsSolidTile(x, y + 1, z)) {
            t.Tex(u0, v0);
            t.Vertex(x0, y1, z1); // Define o vertice 12
            t.Tex(u1, v0);
            t.Vertex(x1, y1, z1); // Define o vertice 13
            t.Tex(u1, v1);
            t.Vertex(x1, y1, z0); // Define o vertice 14
            t.Tex(u0, v1);
            t.Vertex(x0, y1, z0); // Define o vertice 15
        }

        // Face z0 (frente do cubo)
        if(!level.IsSolidTile(x, y, z - 1)) {
            t.Tex(u0, v0);
            t.Vertex(x1, y0, z0); // Define o vertice 16
            t.Tex(u1, v0);
            t.Vertex(x0, y0, z0); // Define o vertice 17
            t.Tex(u1, v1);
            t.Vertex(x0, y1, z0); // Define o vertice 18
            t.Tex(u0, v1);
            t.Vertex(x1, y1, z0); // Define o vertice 19
        }

        // Face z1 (tras do cubo)
        if(!level.IsSolidTile(x, y, z + 1)) {
            t.Tex(u0, v0);
            t.Vertex(x0, y0, z1); // Define o vertice 20
            t.Tex(u1, v0);
            t.Vertex(x1, y0, z1); // Define o vertice 21
            t.Tex(u1, v1);
            t.Vertex(x1, y1, z1); // Define o vertice 22
            t.Tex(u0, v1);
            t.Vertex(x0, y1, z1); // Define o vertice 23
        }
    }
}
