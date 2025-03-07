# rd-131655 (Cave game tech test)
 
Este projeto tem como objetivo recriar o Minecraft usando a linguagem C# e a biblioteca OpenTK.

Vamos começar do começo, começando pela primeira versão do Minecraft, a rd-131655.

## Ferramentas e Tecnologias
<code><img height="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/vscode/vscode-original.svg" /></code> VS Code

<code><img height="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" /></code> C#

<code><img height="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/opengl/opengl-original.svg" /></code> OpenGL

<code><img height="30" src="https://avatars.githubusercontent.com/u/5914736?s=280&v=4" /></code> OpenTK

<code><img height="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/nuget/nuget-original.svg" /></code> StbImageSharp

## Recursos
### Blocos
<code><img height="30" src="https://github.com/user-attachments/assets/d614ae6c-69ef-41cd-af2e-4e4addff1e2e" /></code> Ar
- Não listado como um bloco no momento.

<code><img height="30" src="https://github.com/user-attachments/assets/23c120f7-7c37-4ff8-b1d6-e8d382cc78ce" /></code> Bloco de Grama

<code><img height="30" src="https://github.com/user-attachments/assets/ea7acd46-3658-4a10-a112-2886606729d1" /></code> Pedra
- Sua textura nessa época seria posteriormente reaproveitada para os Pedregulhos.

### Entidades não-mob
Jogador
- Atualmente não tem modelo.
- Tem uma altura de 1,8 blocos.

### Geração do mundo
Chunks
- Leva cerca de 0,1 segundo para gerar.
- O tamanho de cada blcoo é de 16x16 blocos.
  - Os blocos são de 16x16 blocos em vez de 8x8 porque 8x8 blocos diminuiria o desempenho.
- Os chunks são carregados em ordem de proximidade com o jogador.
- O jogador aparece em um mapa de 256 x 64 x 256 blocos.
  - O jogo leva 20 segundos para gerar um mapa de 256 x 64 x 256 blocos.
- Era possivel cair do mundo, mas não mataria o jogador.
- A geração de níveis era completamente plana, o que era semelhante a um mundo superplano.
- O mundo gerado é um cuboid de 256 x 42 x 256 blocos, com altura máxima de y64.
- O mundo está cheio de pedra até y41, apenas grama em y42 e nada para a parte restante.

### Geral
Luz
- O mecanismo de iluminação em Classic e Pre-Classic era simples, com apenas 2 niveis de luz, claro e escuro.
  - "Luz solar" é emitida pela borda superior do mapa e atinge qualquer bloco que esteja sob ela, independentemente da distância. Ele passa por blocos transparentes para blocos de luz por baixo.
  - Os blocos que não recebem luz estão em uma sombra fraca que permanece no mesmo nível de brilho, não importa o quão longe estejam de uma fonte de luz.
  - Os blocos escurecidos também têm uma camada de névoa preta espessa aplicada a eles, parecendo mais escuros quando vistos de distâncias maiores. Isso causou falhas visuais estranhas.

Modo criativo
- Esta foi uma versão extremamente básica dele. O jogador não podia voar ou colocar/remover blocos e não havia inventário ou barra de atalho para obtê-los.

World Spawn
- O jogador poderia reaparecer pressionando <code><img height="30" src="https://github.com/user-attachments/assets/e49e3d70-d887-45ef-856c-13bc9d837166" /></code>, teletransportando-os para o mundo em que estavam.

## Referências
- https://minecraft.wiki/w/Cave_game_tech_test
- https://opentk.net/learn/index.html

## To-Do
- ✅ Janela
  - Gerar uma Janela de 1024 x 768.
  - Definir a cor de fundo com r0.5f, g0.8f, b1.0f, a0.0f.
- ✅ Triangulo
  - Gerar um triangulo.
- ✅ Shader
  - Criar um shader para aplicar cor ao triangulo.
- ✅ Retangulo
  - Gerar um retangulo usando dois triangulos.
- ✅ Textura
  - Gerar uma textura a partir de um atlas de textura.
- ✅ Tile
  - Recortar um tile do atlas de textura.
- ✅ Icone de Janela
  - Gerar um icone de janela.
- ✅ Camera
  - Configurar as matrizes 4x4.
  - Movimentando a camera com as teclada W, A, S, D, Space e LeftShif.
  - Rotacioando a camera com o mouse.
- ✅ Bloco
  - Gerar um bloco.
- ✅ Chunk
  - Gerando um chunk de 16 x 16 x 16 blocos.
- ✅ Apagando Faces
  - Apagar faces não visiveis entre os blocos do chunk.
- ✅ SetPos
  - Definindo a posição inicial do jogador e respaw com a tecla R.
- ✅ Cor
  - Aplicando cor para gerar uma iluminação/sombra primitiva.
  - ❌ "Iluminação" mais complexa
- ✅ Layers
  - Gerando camadas de pedra, grama e ar.
- ✅ Mundo
  - Gerando um mundo de 256 x 64 x 256 blocos.
  - ❌ Carregar chunks com ordem de proximidade do jogador.
- ❌ Fisica
  - 🐞 AABB (Axis-Aligned Bounding Box)
    - Gerando um colisor AABB.
  - 🐞 Gravidade e pulo

## Progresso
### Gerando uma Janela
![Screenshot_439](https://github.com/user-attachments/assets/b92e0a74-9b51-4f55-9fe6-f256d95be919)

### Gerando um Triangulo
![Screenshot_440](https://github.com/user-attachments/assets/a897e3ed-f76a-4e99-a197-239f63f5abfa)

### Shader
![Screenshot_441](https://github.com/user-attachments/assets/e61e4daf-d4b2-46c9-8022-c3593ba196ef)

### Gerando um Retangulo
![Screenshot_442](https://github.com/user-attachments/assets/dc95487c-ca7b-4684-b53e-aadf16df6a4a)

![Screenshot_454](https://github.com/user-attachments/assets/6a48d8ed-dd31-4bc5-955f-46fb2ad36dec)

Wireframe

### Gerando uma Textura
![Screenshot_443](https://github.com/user-attachments/assets/63f02f65-3446-4a7f-9fa7-120b31181668)

![terrain](https://github.com/user-attachments/assets/00896d62-c014-4578-a88a-e68dce88e7c7)

terrain.png

### Recortando um Tile do Atlas te Textura
![Screenshot_444](https://github.com/user-attachments/assets/6315302e-bda6-4546-b890-bb562ceb74ed)

### Icone de Janela
![Screenshot_445](https://github.com/user-attachments/assets/7fecdfc1-480a-49bf-a30e-c408dd18a582)

![openTK_logo](https://github.com/user-attachments/assets/fa094034-f158-4ed4-b79e-8a1a7372e9dc)

openTK_logo.png

### Camera
![Screenshot_446](https://github.com/user-attachments/assets/77d76bec-9714-4a5d-ba19-2247cc26b7ce)

### Gerando um Bloco
![Screenshot_447](https://github.com/user-attachments/assets/2188c5aa-f2a0-45ab-880a-6c8bd9b985e6)

### Gerando uma Chunk
![Screenshot_448](https://github.com/user-attachments/assets/5abfe88a-84eb-4eab-b2f6-8dd2267ebb78)

### Apagando Faces
![Screenshot_449](https://github.com/user-attachments/assets/87cc83e7-8702-457e-ad93-13ba3680581d)

![Screenshot_450](https://github.com/user-attachments/assets/8307fdd6-3725-4c26-b4da-54a4182d34c9)

### Cor
![Screenshot_451](https://github.com/user-attachments/assets/18de7ea5-f055-4a71-b412-8e936489a6c8)

### Camadas
![Screenshot_452](https://github.com/user-attachments/assets/60445357-a92a-4894-a3b8-da019eb85da2)

### Gerando um Mundo
![Screenshot_453](https://github.com/user-attachments/assets/66c583d8-e79b-4fa2-8f2f-5259c104631d)
