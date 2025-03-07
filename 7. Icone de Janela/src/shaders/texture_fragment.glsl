#version 330 core // Define a versao do GLSL (OpenGL Shading Language) como 3.30

// Define uma variavel de saida para o fragment shader
// 'out vec4 FragColor' declara um vetor de 4 componentes (RGBA) que representa a cor do fragmento
out vec4 FragColor;

// Define uma variavel de entrada para as coordenadas de textura
// 'in vec2 texCoord' declara um vetor de 2 componentes (s, t) que representa as coordenadas de textura
in vec2 texCoord;

// Define um uniform para a textura
// 'uniform sampler2D texture0' declara um sampler2D que representa uma textura 2D
uniform sampler2D texture0;

// Define um uniform para verificar se a textura deve ser usada
// 'uniform bool hasTexture' declara um booleano que indica se a textura deve ser aplicada
uniform bool hasTexture;

// Funcao principal do fragment shader
void main() {
    // Define a cor do fragmento como um vetor RGBA
    // vec4(1.0f, 0.5f, 0.2f, 1.0f) representa:
    // - R = 1.0 (vermelho no maximo)
    // - G = 0.5 (verde na metade)
    // - B = 0.2 (azul em 20%)
    // - A = 1.0 (totalmente opaco)
    FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);

    // Verifica se a textura deve ser usada
    if(hasTexture) {
        // Aplica a textura usando as coordenadas de textura
        FragColor = texture(texture0, texCoord);
    }
}
