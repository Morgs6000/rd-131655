using OpenTK.Graphics.OpenGL4; // Fornece acesso às funções do OpenGL 4

namespace RubyDung;

// Classe responsável por gerenciar a tesselação e o desenho de geometria
public class Tesselator {
    // Buffer de vértices contendo as coordenadas de um triângulo (x, y)
    private List<float> vertexBuffer = new List<float> {
        -0.5f, -0.5f, // Vértice 1 // inferior esquerdo
         0.5f, -0.5f, // Vértice 2 // inferior direito
         0.0f,  0.5f  // Vértice 3 // topo
    };

    // Identificadores para o Vertex Array Object (VAO) e Vertex Buffer Object (VBO)
    private int VAO;
    private int VBO;

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

        // Define o layout do buffer de vértices (atributo 0: 2 floats por vértice)
        GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
        // Habilita o atributo de vértice 0
        GL.EnableVertexAttribArray(0);
    }

    // Método chamado para renderizar a geometria
    public void OnRenderFrame() {
        // Vincula o VAO que contém os buffers e atributos de vértices
        GL.BindVertexArray(VAO);
        // Desenha o triângulo usando os vértices configurados
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }
}
