using OpenTK.Graphics.OpenGL4; // Fornece acesso às funções do OpenGL 4

namespace RubyDung;

// Classe responsável por gerenciar a tesselação e o desenho de geometria
public class Tesselator {
    private Shader shader; // Instância do shader que será usado para renderizar a geometria

    // Buffer de vértices contendo as coordenadas de um quadrado (x, y)
    private List<float> vertexBuffer = new List<float> {
        -0.5f, -0.5f, // Vértice 1 - inferior esquerdo
         0.5f, -0.5f, // Vértice 2 - inferior direito
         0.5f,  0.5f, // Vértice 3 - superior direito
        -0.5f,  0.5f  // Vértice 4 - superior esquerdo
    };

    // Buffer de índices que define como os vértices são conectados para formar triângulos
    private List<int> indiceBuffer = new List<int> {
        0, 1, 2, // Primeiro triângulo (vértices 0, 1, 2)
        0, 2, 3  // Segundo triângulo (vértices 0, 2, 3)
    };

    // Buffer de coordenadas de textura (s, t) para mapear a textura no quadrado
    private List<float> texCoordBuffer = new List<float> {
        0.0f, 0.0f, // Coordenada de textura para o vértice 1
        1.0f, 0.0f, // Coordenada de textura para o vértice 2
        1.0f, 1.0f, // Coordenada de textura para o vértice 3
        0.0f, 1.0f  // Coordenada de textura para o vértice 4
    };

    // Identificadores para o Vertex Array Object (VAO), Vertex Buffer Object (VBO) e Element Buffer Object (EBO)
    private int VAO; // VAO armazena a configuração dos buffers e atributos de vértices
    private int VBO; // VBO armazena os dados dos vértices na GPU
    private int EBO; // EBO armazena os índices que definem como os vértices são conectados
    private int TBO; // TBO armazena as coordenadas de textura na GPU

    // Construtor da classe Tesselator
    public Tesselator(Shader shader) {
        this.shader = shader; // Recebe o shader que será usado para renderizar
    }

    // Método chamado para configurar os buffers e atributos de vértices
    public void OnLoad() {
        /* ..:: Vertex Array Object ::.. */

        // Gera um VAO e o vincula
        VAO = GL.GenVertexArray();
        GL.BindVertexArray(VAO);

        /* ..:: Vertex Buffer Object ::.. */

        // Gera um VBO e o vincula
        VBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
        // Envia os dados do buffer de vértices para a GPU
        GL.BufferData(BufferTarget.ArrayBuffer, vertexBuffer.Count * sizeof(float), vertexBuffer.ToArray(), BufferUsageHint.StaticDraw);

        // Obtém a localização do atributo "aPos" no shader
        int aPos = shader.GetAttribLocation("aPos");
        // Define o layout do buffer de vértices (atributo "aPos": 2 floats por vértice)
        GL.VertexAttribPointer(aPos, 2, VertexAttribPointerType.Float, false, 0, 0);
        // Habilita o atributo de vértice "aPos"
        GL.EnableVertexAttribArray(aPos);

        /* ..:: Element Buffer Object ::.. */

        // Gera um EBO e o vincula
        EBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
        // Envia os dados do buffer de índices para a GPU
        GL.BufferData(BufferTarget.ElementArrayBuffer, indiceBuffer.Count * sizeof(int), indiceBuffer.ToArray(), BufferUsageHint.StaticDraw);

        /* ..:: Texture Buffer Object ::.. */

        // Gera um TBO e o vincula
        TBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, TBO);
        // Envia os dados do buffer de coordenadas de textura para a GPU
        GL.BufferData(BufferTarget.ArrayBuffer, texCoordBuffer.Count * sizeof(float), texCoordBuffer.ToArray(), BufferUsageHint.StaticDraw);

        // Obtém a localização do atributo "aTexCoord" no shader
        int aTexCoord = shader.GetAttribLocation("aTexCoord");
        // Define o layout do buffer de coordenadas de textura (atributo "aTexCoord": 2 floats por vértice)
        GL.VertexAttribPointer(aTexCoord, 2, VertexAttribPointerType.Float, false, 0, 0);
        // Habilita o atributo de vértice "aTexCoord"
        GL.EnableVertexAttribArray(aTexCoord);
    }

    // Método chamado para renderizar a geometria
    public void OnRenderFrame() {
        // Vincula o VAO que contém os buffers e atributos de vértices
        GL.BindVertexArray(VAO);
        // Desenha os triângulos usando os índices configurados
        GL.DrawElements(PrimitiveType.Triangles, indiceBuffer.Count, DrawElementsType.UnsignedInt, 0);
    }
}
