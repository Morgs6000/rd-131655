#version 330 core // Define a versao do GLSL (OpenGL Shading Language) como 3.30

// Define um atributo de entrada para o vertex shader
// 'layout(location = 0)' especifica que este atributo esta associado a localizacao 0
// 'in vec2 aPos' declara um vetor de 2 componentes (x, y) que representa a posicao do vertice
layout(location = 0) in vec2 aPos;

// Define um atributo de entrada para as coordenadas de textura
// 'layout(location = 1)' especifica que este atributo esta associado a localizacao 1
// 'in vec2 aTexCoord' declara um vetor de 2 componentes (s, t) que representa as coordenadas de textura
layout(location = 1) in vec2 aTexCoord;

// Define uma variavel de saida para as coordenadas de textura
// 'out vec2 texCoord' declara um vetor de 2 componentes que sera passado para o fragment shader
out vec2 texCoord;

// Funcao principal do vertex shader
void main() {
    // Define a posicao do vertice no espaco de clip (coordenadas normalizadas)
    // 'aPos' e um vec2 (x, y), e ele e convertido para vec4 (x, y, z, w)
    // z e definido como 0.0f (profundidade) e w como 1.0f (coordenada homogenea)
    gl_Position = vec4(aPos, 0.0f, 1.0f);

    // Passa as coordenadas de textura para o fragment shader
    texCoord = aTexCoord;
}
