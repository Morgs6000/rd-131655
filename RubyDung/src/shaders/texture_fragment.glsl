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

// Funcao principal do fragment shader
void main() {
    // Aplica a textura usando as coordenadas de textura
    FragColor = texture(texture0, texCoord);
}
