namespace RubyDung;

public class Chunk {
    // Coordenadas mínimas do chunk (início do bloco)
    public readonly int x0;
    public readonly int y0;
    public readonly int z0;

    // Coordenadas máximas do chunk (fim do bloco)
    public readonly int x1;
    public readonly int y1;
    public readonly int z1;

    // Instância da classe Tesselator para gerenciar a renderização de geometria
    private Tesselator t;

    private int radius = 10;

    // Construtor da classe Chunk
    public Chunk(Shader shader) {
        // Inicializa o Tesselator com o shader fornecido
        t = new Tesselator(shader);

        this.x0 = -radius;
        this.y0 = 0;
        this.z0 = -radius;

        this.x1 = radius;
        this.y1 = 0;
        this.z1 = radius;
    }

    // Método chamado para carregar os dados do chunk
    public void OnLoad() {
        float radiusSquared = radius * radius + radius * 0.8f;
        
        // Itera sobre todas as coordenadas (x, y, z) dentro do chunk
        for(int x = x0; x <= x1; x++) {
            for(int y = y0; y <= y1; y++) {
                for(int z = z0; z <= z1; z++) {
                    int distSquared = x * x + z * z;

                    if(distSquared <= radiusSquared) {
                        // Configura os vértices e texturas de cada tile (bloco) no chunk
                        Tile.tile.OnLoad(t, x, 0, z);
                    }
                }            
            }            
        }

        // Configura os buffers e atributos de vértices na GPU
        t.OnLoad();
    }

    // Método chamado para renderizar o chunk
    public void OnRenderFrame() {
        // Renderiza a geometria do chunk usando o Tesselator
        t.OnRenderFrame();
    }
}
