using OpenTK.Graphics.OpenGL4; // Fornece acesso às funções do OpenGL 4

namespace RubyDung;

// Classe responsável por gerenciar a tesselação e o desenho de geometria
public class Tesselator {
    private Shader shader; // Instância do shader que será usado para renderizar a geometria

    // Buffer de vértices contendo as coordenadas de um quadrado (x, y)
    private List<float> vertexBuffer = new List<float> {};

    // Buffer de índices que define como os vértices são conectados para formar triângulos
    private List<int> indiceBuffer = new List<int> {};

    // Buffer de coordenadas de textura (s, t) para mapear a textura no quadrado
    private List<float> texCoordBuffer = new List<float> {};

    private int vertices = 0; // Contador de vértices adicionados

    private float u; // Coordenada U da textura
    private float v; // Coordenada V da textura

    private bool hasTexture = false; // Indica se a textura deve ser usada

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

        if(hasTexture) {
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
    }

    // Método chamado para renderizar a geometria
    public void OnRenderFrame() {
        // Define se a textura deve ser usada no shader
        shader.SetBool("hasTexture", hasTexture);

        // Vincula o VAO que contém os buffers e atributos de vértices
        GL.BindVertexArray(VAO);
        // Desenha os triângulos usando os índices configurados
        GL.DrawElements(PrimitiveType.Triangles, indiceBuffer.Count, DrawElementsType.UnsignedInt, 0);
    }

    // Método para adicionar um vértice ao buffer de vértices
    public void Vertex(float x, float y) {
        // Adiciona as coordenadas do vértice ao buffer de vértices
        vertexBuffer.Add(x);
        vertexBuffer.Add(y);

        // Se a textura estiver habilitada, adiciona as coordenadas de textura ao buffer de coordenadas de textura
        if(hasTexture) {
            texCoordBuffer.Add(u);
            texCoordBuffer.Add(v);
        }

        // Incrementa o contador de vértices
        vertices++;

        // Se 4 vértices foram adicionados, define os índices para formar dois triângulos
        if(vertices % 4 == 0) {
            int indices = vertices - 4;

            // Primeiro triângulo (vértices 0, 1, 2)
            indiceBuffer.Add(0 + indices);
            indiceBuffer.Add(1 + indices);
            indiceBuffer.Add(2 + indices);

            // Segundo triângulo (vértices 0, 2, 3)
            indiceBuffer.Add(0 + indices);
            indiceBuffer.Add(2 + indices);
            indiceBuffer.Add(3 + indices);
        }
    }

    // Método para definir as coordenadas de textura
    public void Tex(float u, float v) {
        // Habilita o uso de textura
        hasTexture = true;

        // Define as coordenadas de textura
        this.u = u;
        this.v = v;
    }
}
