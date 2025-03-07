using OpenTK.Mathematics; // Fornece funcionalidades matemáticas, como vetores e matrizes

namespace RubyDung;

// Classe que representa o jogador e suas propriedades relacionadas à câmera
public class Player {
    // Posição do jogador no espaço 3D
    // private Vector3 postion = Vector3.Zero; // Posição inicial no centro (0, 0, 0)
    private Vector3 postion = new Vector3(0.0f, 0.0f, -3.0f); // Posição inicial em (0, 0, -3)

    // Vetores que definem a orientação da câmera
    private Vector3 horizontal = Vector3.UnitX; // Vetor horizontal (eixo X)
    private Vector3 vertical = Vector3.UnitY;   // Vetor vertical (eixo Y)
    private Vector3 direction = Vector3.UnitZ;  // Vetor de direção (eixo Z)

    // Método para criar uma matriz de visualização (LookAt)
    public Matrix4 LookAt() {
        // Define o ponto de observação (olho) como a posição do jogador
        Vector3 eye = postion;

        // Define o ponto de destino (alvo) como a posição do jogador mais a direção
        Vector3 target = postion + direction;

        // Define o vetor "up" como o vetor vertical
        Vector3 up = vertical;

        // Retorna a matriz de visualização (LookAt) que define como a cena é vista
        return Matrix4.LookAt(eye, target, up);
    }

    // Método para criar uma matriz de projeção em perspectiva
    public Matrix4 CreatePerspectiveFieldOfView(Vector2i clientSize) {
        // Define o campo de visão vertical (fovy) em radianos
        float fovy = MathHelper.DegreesToRadians(70.0f);

        // Define a proporção da tela (aspect ratio) como largura dividida pela altura
        float aspect = (float)clientSize.X / (float)clientSize.Y;

        // Define a distância do plano de corte próximo (depthNear)
        float depthNear = 0.05f;

        // Define a distância do plano de corte distante (depthFar)
        float depthFar = 1000.0f;

        // Retorna a matriz de projeção em perspectiva
        return Matrix4.CreatePerspectiveFieldOfView(fovy, aspect, depthNear, depthFar);
    }
}
