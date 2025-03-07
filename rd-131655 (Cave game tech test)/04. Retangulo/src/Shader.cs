using OpenTK.Graphics.OpenGL4; // Fornece acesso às funções do OpenGL 4

namespace RubyDung;

// Classe responsável por carregar, compilar e gerenciar shaders
public class Shader {
    private int program; // Identificador do programa de shader

    // Construtor da classe Shader
    public Shader(string vertexPath, string fragmentPath) {
        // Lê o código-fonte dos shaders a partir dos arquivos
        string vertexShaderSource = File.ReadAllText(vertexPath);
        string fragmentShaderSource = File.ReadAllText(fragmentPath);

        // Cria e compila o vertex shader
        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);

        // Cria e compila o fragment shader
        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);

        // Compila os shaders
        CompileShader(vertexShader);
        CompileShader(fragmentShader);

        // Cria o programa de shader
        program = GL.CreateProgram();

        // Anexa os shaders ao programa
        GL.AttachShader(program, vertexShader);
        GL.AttachShader(program, fragmentShader);

        // Linka o programa
        LinkProgram();

        // Limpa os shaders após o link, pois eles não são mais necessários
        GL.DetachShader(program, vertexShader);
        GL.DetachShader(program, fragmentShader);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);
    }

    // Método para compilar um shader
    public void CompileShader(int shader) {
        GL.CompileShader(shader);

        // Verifica se a compilação foi bem-sucedida
        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if(success == 0) {
            // Se falhou, exibe o log de erro
            string infoLog = GL.GetShaderInfoLog(shader);
            Console.WriteLine(infoLog);
        }
    }

    // Método para linkar o programa de shader
    public void LinkProgram() {
        GL.LinkProgram(program);

        // Verifica se o link foi bem-sucedido
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int success);
        if(success == 0) {
            // Se falhou, exibe o log de erro
            string infoLog = GL.GetProgramInfoLog(program);
            Console.WriteLine(infoLog);
        }
    }

    // Método chamado antes de renderizar para usar o programa de shader
    public void OnRenderFrame() {
        GL.UseProgram(program);        
    }

    // Método para obter a localização de um atributo no shader
    public int GetAttribLocation(string name) {
        return GL.GetAttribLocation(program, name);
    }
}
