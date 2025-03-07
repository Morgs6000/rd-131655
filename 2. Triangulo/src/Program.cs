using OpenTK.Mathematics; // Fornece funcionalidades matemáticas, como vetores e matrizes
using OpenTK.Windowing.Desktop; // Fornece funcionalidades para criar e gerenciar janelas

namespace RubyDung;

// Classe principal do programa
public class Program {
    // Método de entrada do programa
    private static void Main(string[] args) {
        Console.WriteLine("Hello, World!");

        // Configurações padrão para a janela do jogo
        GameWindowSettings gws = GameWindowSettings.Default;

        // Configurações personalizadas para a janela nativa
        NativeWindowSettings nws = NativeWindowSettings.Default;
        nws.ClientSize = new Vector2i(1024, 768); // Define o tamanho da janela como 1024x768 pixels
        nws.Title = "Game"; // Define o título da janela como "Game"

        // Cria uma instância da classe RubyDung (que herda de GameWindow) e inicia o loop principal do jogo
        new RubyDung(gws, nws).Run();
    }
}
