using OpenTK.Graphics.OpenGL4; // Fornece acesso às funções do OpenGL 4
using OpenTK.Windowing.Common; // Fornece funcionalidades comuns, como eventos de janela
using OpenTK.Windowing.Desktop; // Fornece funcionalidades para criar e gerenciar janelas
using OpenTK.Windowing.GraphicsLibraryFramework; // Fornece acesso ao GLFW para manipulação de entrada

namespace RubyDung;

// Classe principal do jogo, que herda de GameWindow
public class RubyDung : GameWindow {
    private Tesselator t; // Instância da classe Tesselator para gerenciar a renderização de geometria

    // Construtor da classe RubyDung
    public RubyDung(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) {
        // Centraliza a janela ao iniciar
        CenterWindow();
    }

    // Método chamado quando a janela é carregada
    protected override void OnLoad() {
        base.OnLoad();

        // Define a cor de fundo da tela (RGBA)
        GL.ClearColor(0.5f, 0.8f, 1.0f, 0.0f);

        // Inicializa a instância do Tesselator e configura os buffers de vértices
        t = new Tesselator();
        t.OnLoad();
    }

    // Método chamado a cada frame para atualizar a lógica do jogo
    protected override void OnUpdateFrame(FrameEventArgs args) {
        base.OnUpdateFrame(args);

        // Verifica se a tecla ESC foi pressionada para fechar a janela
        if(KeyboardState.IsKeyPressed(Keys.Escape)) {
            Close();
        }
    }

    // Método chamado a cada frame para renderizar o jogo
    protected override void OnRenderFrame(FrameEventArgs args) {
        base.OnRenderFrame(args);

        // Limpa o buffer de cor com a cor definida em OnLoad
        GL.Clear(ClearBufferMask.ColorBufferBit);

        // Renderiza a geometria usando o Tesselator
        t.OnRenderFrame();

        // Troca os buffers para exibir o que foi renderizado
        SwapBuffers();
    }

    // Método chamado quando o tamanho da janela é alterado
    protected override void OnFramebufferResize(FramebufferResizeEventArgs e) {
        base.OnFramebufferResize(e);

        // Ajusta o viewport para o novo tamanho da janela
        GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
    }
}
